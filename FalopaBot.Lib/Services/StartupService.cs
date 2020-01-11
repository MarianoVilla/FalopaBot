using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using FalopaBot.Lib.TypeReaders;
using FalopaBot.Lib.Models;

namespace FalopaBot.Lib.Services
{
    public class StartupService
    {
        private readonly IServiceProvider Provider;
        private readonly DiscordSocketClient Discord;
        private readonly CommandService Commands;
        private readonly IConfigurationRoot Config;

        public StartupService(IServiceProvider Provider, DiscordSocketClient Discord, CommandService Commands, IConfigurationRoot Config)
        {
            this.Provider = Provider;
            this.Discord = Discord;
            this.Commands = Commands;
            this.Config = Config;
        }

        public async Task StartAsync()
        {
            string Token = Environment.GetEnvironmentVariable("FalopaBotToken");
            if (string.IsNullOrWhiteSpace(Token))
                throw new Exception("Please enter your bot's token into the `_configuration.json` file found in the applications root directory.");

            await Discord.LoginAsync(TokenType.Bot, Token);
            await Discord.StartAsync();

            await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), Provider);
            await Commands.AddExternalModulesAsync("FalopaBot.Lib", Provider);
            Commands.AddTypeReader(typeof(bool), new BooleanTypeReader());
            Commands.AddTypeReader(typeof(Drug), new DrugTypeReader());
        }
    }
}