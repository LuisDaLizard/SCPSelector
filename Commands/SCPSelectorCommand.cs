using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using RemoteAdmin;
using PluginAPI.Core;
using PlayerRoles;

namespace SCPSelector.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class SCPSelectorCommand : ParentCommand
    {
        public SCPSelectorCommand() => LoadGeneratedCommands();

        public override string Command => "scpselect";

        public override string[] Aliases { get; } = { "select", "scp" };

        public override string Description => "Base command for ScpSelect";

        public override void LoadGeneratedCommands()
        {
            //RegisterCommand(new Restore());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            if (player == null)
            {
                response = "Unknown player.";
                return false;
            }

            if (!Round.IsRoundStarted)
            {
                response = "Round has not started.";
                return false;
            }

            if (Round.Duration > TimeSpan.FromSeconds(Plugin.Instance.Config.SelectionTimer))
            {
                response = "Cannot select scp after start period has ended.";
                return false;
            }

            if (!player.IsSCP)
            {
                response = "You must be an SCP to access this command.";
                return false;
            }

            if (!Plugin.Instance.Data.ReachedMaxChanges(player))
            {
                response = "You've reached the maximum number of scp changes.";
                return false;
            }

            return CheckValidArgument(player, arguments, out response);
        }

        private bool CheckValidArgument(Player player, ArraySegment<string> arguments, out string response)
        {
            if (arguments.IsEmpty())
            {
                response = $"Usage: .{Command} <scp number>\n173 - peanut\n939 - with many voices\n79 - computer\n106 - old man\n96 - shy guy\n49 - doctor\n492 - zombie";
                return false;
            }

            RoleTypeId role;

            switch(arguments.At(0))
            {
                case "173":
                    role = RoleTypeId.Scp173;
                    break;
                case "939":
                    role = RoleTypeId.Scp939;
                    break;
                case "79":
                    role = RoleTypeId.Scp079;
                    break;
                case "106":
                    role = RoleTypeId.Scp106;
                    break;
                case "96":
                    role = RoleTypeId.Scp096;
                    break;
                case "49":
                    role = RoleTypeId.Scp049;
                    break;
                case "492":
                    role = RoleTypeId.Scp0492;
                    break;
                default:
                    response = $"Invalid scp number. Use {Command} to see usage.";
                    return false;
            }

            if (Plugin.Instance.Config.Blacklist.Contains(role))
            {
                response = "That SCP is blacklisted.";
                return false;
            }

            if (Plugin.Instance.Data.IsDuplicate(role))
            {
                response = "That SCP already taken.";
                return false;
            }

            if (player.Role == role)
            {
                response = "Cannot change to current scp.";
                return false;
            }

            Plugin.Instance.Data.ChangeRole(player, role);

            response = "Valid scp selected.";
            return true;
        }
    }
}
