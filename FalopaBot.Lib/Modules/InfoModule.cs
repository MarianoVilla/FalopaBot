using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FalopaBot.Lib.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Echoes the given string.
        /// ~say hello => hello
        /// </summary>
        /// <param name="Echo">The string to echo</param>
        [Command("say")]
        public Task SayAsync([Remainder] string Echo)
            => ReplyAsync('\u200B' + Echo);

        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync($"👋 pong, {Context.User.Mention}!");
        }

        /// <summary>
        /// Gives the user info for the given SocketUser, or the CurrentUser.
        /// ~userinfo => FalopaBot#1234
        /// ~userinfo Dager => Dager#5678
        /// ~userinfo @Dager => Dager#5678
        /// ~userinfo Dager#5678 => Dager#5678
        /// ~userinfo 1234567891011 => Dager#5678
        /// ~whois 1234567891011 => Dager#5678
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [Command("userinfo")]
        [Alias("user", "whois", "comosellama")]
        public async Task UserInfoAsync(SocketUser User = null)
        {
            var UserInfo = User ?? Context.Client.CurrentUser;
            await ReplyAsync($"{UserInfo.Username}#{UserInfo.Discriminator}");
        }
    }
}
