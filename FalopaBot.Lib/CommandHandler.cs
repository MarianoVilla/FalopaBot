using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FalopaBot.Lib
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient Client;
        private readonly CommandService Commands;

        public CommandHandler(DiscordSocketClient Client, CommandService Commands)
        {
            this.Client = Client;
            this.Commands = Commands;
        }

        public async Task InstallCommandsAsync()
        {
            Client.MessageReceived += HandleCommandAsync;
            //TODO: configure Dependency Injection.
            await Commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null);
        }

        async Task HandleCommandAsync(SocketMessage Arg)
        {
            var Message = Arg as SocketUserMessage;
            if (Message == null) return;
            int ArgPos = 0;
            if (InvalidMessage(Message, ref ArgPos))
                return;
            var Context = new SocketCommandContext(Client, Message);

            await Commands.ExecuteAsync(
                context: Context, 
                argPos: ArgPos, 
                services: null);
        }

        bool InvalidMessage(SocketUserMessage Message, ref int ArgPos)
        {
            return !HasPrefix(Message, '!', ref ArgPos) ||
                SelfMention(Client.CurrentUser, Message, ref ArgPos) ||
                    Message.Author.IsBot;
        }
        bool HasPrefix(SocketUserMessage Message, char Prefix, ref int ArgPos)
            => Message.HasCharPrefix(Prefix, ref ArgPos);
        bool SelfMention(SocketSelfUser User, SocketUserMessage Message, ref int ArgPos)
            => Message.HasMentionPrefix(Client.CurrentUser, ref ArgPos);
    } 
}
