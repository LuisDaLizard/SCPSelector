using CommandSystem;
using PluginAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSelector.Commands
{
    public class Restore : ICommand
    {
        public string Command => "restore";

        public string[] Aliases { get; }

        public string Description => "Restore your original scp";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            if (player == null)
            {
                response = "Unkown player sender.";
                return false;
            }

            response = "Reset to original scp.";
            return true;
        }
    }
}
