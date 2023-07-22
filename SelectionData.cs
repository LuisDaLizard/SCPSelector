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

        public SelectionData()
        {
            PlayerSelections = new Dictionary<int, int>();
        }

        public void Reset()
        {
            PlayerSelections = new Dictionary<int, int>();
        }

        public bool PlayerCanMakeChange(Player player)
        {
            int id = player.PlayerId;
            if (!PlayerSelections.ContainsKey(id))
                PlayerSelections[id] = 0;

            if (PlayerSelections[id] >= Plugin.Instance.Config.MaxChanges)
                return false;
            return true;
        }

        public void PlayerMakeChange(Player player, RoleTypeId role)
        {
            int id = player.PlayerId;
            if (!PlayerSelections.ContainsKey(id))
                PlayerSelections[id] = 0;
            PlayerSelections[id]++;

            player.SetRole(role);
        }
    }
}
