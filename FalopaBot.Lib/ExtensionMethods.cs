using Alpha.Utilidades.General;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalopaBot.Lib
{
    public static class ExtensionMethods
    {
        public static TipoLogEnum SeverityToTipoLog(this LogMessage Message)
        {
            switch (Message.Severity)
            {
                case LogSeverity.Critical: return TipoLogEnum.Fatal;
                case LogSeverity.Debug: return TipoLogEnum.Debug;
                case LogSeverity.Error: return TipoLogEnum.Error;
                case LogSeverity.Info: return TipoLogEnum.Info;
                case LogSeverity.Warning: return TipoLogEnum.Warning;
                default: throw new ArgumentException("No known conversion.");
            }
        }
    }
}
