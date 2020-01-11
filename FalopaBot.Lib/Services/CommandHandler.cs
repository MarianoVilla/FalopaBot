using Discord;
using Discord.Commands;
using Discord.WebSocket;
using FalopaBot.Lib.TypeReaders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FalopaBot.Lib.Services
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient Client;
        private readonly CommandService Commands;
        private readonly IConfigurationRoot Config;
        private readonly IServiceProvider Provider;

        public CommandHandler(DiscordSocketClient Client, CommandService Commands, 
            IConfigurationRoot Config, IServiceProvider Provider)
        {
            this.Client = Client;
            this.Commands = Commands;
            this.Config = Config;
            this.Provider = Provider;
            SetupAsync();
        }
        public async Task SetupAsync()
        {
            Client.MessageReceived += OnMessageReceivedAsync;
            Commands.CommandExecuted += OnCommandExecutedAsync;

            Commands.AddTypeReader(typeof(bool), new BooleanTypeReader());
        }

        async Task OnMessageReceivedAsync(SocketMessage Arg)
        {
            if (!(Arg is SocketUserMessage Message)) return;

            int ArgPos = 0;
            if (InvalidMessage(Message, ref ArgPos))
                return;
            var Context = new SocketCommandContext(Client, Message);

            await Commands.ExecuteAsync(
                context: Context, 
                argPos: ArgPos, 
                services: Provider);
        }
        #region Message validation.
        bool InvalidMessage(SocketUserMessage Message, ref int ArgPos)
        {
            return !HasPrefix(Message, '!', ref ArgPos)||
                SelfMention(Message, ref ArgPos) ||
                    Message.Author.IsBot;
        }
        bool HasPrefix(SocketUserMessage Message, char Prefix, ref int ArgPos)
            => Message.HasCharPrefix(Prefix, ref ArgPos);
        bool SelfMention(SocketUserMessage Message, ref int ArgPos)
            => Message.HasMentionPrefix(Client.CurrentUser, ref ArgPos);
        #endregion

        public async Task OnCommandExecutedAsync(Optional<CommandInfo> Command, ICommandContext Context, IResult Result)
        {
            await TryAlertErrorReason(Result?.ErrorReason, Context);

            //TODO: do something with FalopaRuntimeResult.

            var CommandName = Command.IsSpecified ? Command.Value.Name : "A command";
            //TODO: replace dependency in favor of LoggingService.
            await Logger.Log($"{CommandName} was executed at {DateTime.UtcNow}.", "CommandExecution");
        }
        async Task TryAlertErrorReason(string ErrorReason, ICommandContext Context)
        {
            if (string.IsNullOrWhiteSpace(ErrorReason))
                return;
            await Context.Channel.SendMessageAsync(ErrorReason);
        }
    } 
}
