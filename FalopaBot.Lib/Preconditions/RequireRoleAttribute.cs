using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalopaBot.Lib.Preconditions
{
    public class RequireRoleAttribute : PreconditionAttribute
    {
        private readonly string Name;

        public RequireRoleAttribute(string Name)
            => this.Name = Name;

        public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext Context, CommandInfo command, IServiceProvider services)
        {
            if (!(Context.User is SocketGuildUser GUser))
                return Task.FromResult(PreconditionResult.FromError("You mus be in a guild to use this command"));

            if (GUser.Roles.Any(r => r.Name == Name))
                return Task.FromResult(PreconditionResult.FromSuccess());
            
            return Task.FromResult(PreconditionResult.FromError($"You must have the {Name} role to use this command."));
        }
    }
}
