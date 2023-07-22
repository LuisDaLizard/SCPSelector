using PlayerRoles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSelector
{
    public class Config
    {
        public bool Enabled { get; set; } = true;

        [Description("Maximum number of changes an scp can make")]
        public int MaxChanges { get; set; } = 2;

        [Description("Time at the beginning of the round for players to strategize before starting")]
        public int SelectionTimer { get; set; } = 15;

        [Description("SCPs that cannot be chosen at the beginning of a round")]
        public RoleTypeId[] Blacklist { get; set; } =
        {
            RoleTypeId.Scp0492
        };
    }
}
