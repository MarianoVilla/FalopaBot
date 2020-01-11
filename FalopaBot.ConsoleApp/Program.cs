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
        public static Task Main(string[] args)
            => Startup.RunAsync(args);
    }
}
