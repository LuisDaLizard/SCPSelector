﻿using PlayerRoles;
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
        public bool Debug { get; set; } = false;

        [Description("Time at the beginning of the round for players to strategize before starting")]
        public int RoundStartTimer { get; set; } = 15;

        [Description("SCPs that cannot be chosen at the beginning of a round")]
        public RoleTypeId[] Blacklist { get; set; } =
        {
            RoleTypeId.Scp0492
        };
    }
}