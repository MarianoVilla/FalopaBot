using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FalopaBot.Lib.Modules
{
    [Group("admin")]
    public class AdminModule : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Bans a user.
        /// ~admin ban foxbot#0282
        /// </summary>
        /// <param name="User">The user you want to build</param>
        [Command("ban")]
        public Task BanAsync(IGuildUser User)
            => Context.Guild.AddBanAsync(User);
    }
}
