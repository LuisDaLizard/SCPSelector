using PlayerRoles;
using PluginAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSelector
{
    public class SelectionData
    {
        private Dictionary<int, int> PlayerSelections;
        private Dictionary<int, RoleTypeId> PlayerRoles;

        public SelectionData()
        {
            PlayerSelections = new Dictionary<int, int>();
            PlayerRoles = new Dictionary<int, RoleTypeId>();
        }

        public void Reset()
        {
            PlayerSelections = new Dictionary<int, int>();
            PlayerRoles = new Dictionary<int, RoleTypeId>();
        }

        public void RegisterSCPPlayer(Player player, RoleTypeId role)
        {
            int id = player.PlayerId;
            PlayerSelections[id] = 0;
            PlayerRoles[id] = role;
        }

        public bool ReachedMaxChanges(Player player)
        {
            int id = player.PlayerId;
            if (!PlayerSelections.ContainsKey(id))
                PlayerSelections[id] = 0;

            if (PlayerSelections[id] >= Plugin.Instance.Config.MaxChanges)
                return false;
            return true;
        }

        public bool IsDuplicate(RoleTypeId role)
        {
            return PlayerRoles.ContainsValue(role);
        }

        public void ChangeRole(Player player, RoleTypeId role)
        {
            int id = player.PlayerId;

            if (!PlayerSelections.ContainsKey(id))
                PlayerSelections[id] = 0;

            PlayerSelections[id]++;
            PlayerRoles[id] = role;

            player.SetRole(role);
        }
    }
}
