using Alpha.Utilidades.General;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalopaBot.Lib
{
    public static class ExtensionMethods
    {
        public static TipoLogEnum SeverityToTipoLog(this LogMessage Message)
        {
            return Message.Severity switch
            {
                LogSeverity.Critical => TipoLogEnum.Fatal,
                LogSeverity.Debug => TipoLogEnum.Debug,
                LogSeverity.Error => TipoLogEnum.Error,
                LogSeverity.Info => TipoLogEnum.Info,
                LogSeverity.Warning => TipoLogEnum.Warning,
                _ => throw new ArgumentException("No known conversion."),
            };
        }
        public static async Task AddExternalModulesAsync(this CommandService Commands, string LibName, IServiceProvider Provider)
        {
            var LibAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName.Contains(LibName));
            if (LibAssembly != null)
                await Commands.AddModulesAsync(LibAssembly, Provider);
        }
        public static T Random<T>(this IList<T> Items) =>
            Items[new Random().Next(Items.Count)];
    }
}
