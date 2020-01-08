using Alpha.Utilidades.General;
using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
