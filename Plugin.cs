using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;
using PluginAPI.Events;
using PlayerRoles;
using System;
using System.Collections;

namespace SCPSelector
{
    public class Plugin
    {
        [PluginConfig]
        public Config Config;

        public static Plugin Instance { get; private set; }

        public SelectionData Data { get; private set; }


        [PluginEntryPoint("SCP Selector", "1.0", "Allows player chosen as the scp to select their scp", "Luis T. Sanchez")]
        void OnEntryPoint()
        {
            if (!Config.Enabled) return;

            Instance = this;
            Data = new SelectionData();
            EventManager.RegisterEvents(this);
        }

        [PluginReload]
        void OnReload()
        {
            Data.Reset();
        }

        [PluginEvent(ServerEventType.PlayerSpawn)]
        void OnPlayerSpawn(Player player, RoleTypeId role)
        {
            if (player == null) return;
            if (!player.IsSCP || Round.Duration.TotalSeconds >= Config.SelectionTimer) return;

            Data.RegisterSCPPlayer(player, role);
            player.SendBroadcast("<color=yellow><b>You have 20 seconds from the start of the round to change scp. Type .scpselect (scp number) to change scp.</b></color>", (ushort)Config.SelectionTimer, Broadcast.BroadcastFlags.Normal, true);
        }

        [PluginEvent(ServerEventType.RoundStart)]
        void OnRoundStart()
        {
            Data.Reset();
        }


    }
}
