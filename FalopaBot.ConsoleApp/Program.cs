using Alpha.Utilidades.General;
using Discord;
using Discord.WebSocket;
using FalopaBot.Lib;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace FalopaBot.ConsoleApp
{
    class Program
    {
        private DiscordSocketClient Client;

        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            try
            {
                await Logger.Configure();
                await SetupClient();
                await Client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("FalopaBotToken"));
                await Client.StartAsync();
                await Task.Delay(-1);
            }
            catch (Exception ex)
            {
                LogsUtils.Loguear($"{ex.Message}\n{ex.StackTrace}", TipoLogEnum.Error);
            }
        }

        Task SetupClient()
        {
            Client = new DiscordSocketClient();
            Client.Log += Logger.Log;
            Client.Ready += () => Logger.Log("Ready");
            return Task.CompletedTask;
        }

    }
}
