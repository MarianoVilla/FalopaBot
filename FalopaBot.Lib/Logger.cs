using Alpha.Utilidades.General;
using Discord;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace FalopaBot.Lib
{
    public class Logger
    {
        public static Task Configure()
        {
            ConfiguracionLog ConfiguracionLog = new ConfiguracionLog
            {
                LoguearWebApi = false,
                NombreArchivoLog = "FalopaBotLog",
                ProyectoOrigen = "FalopaBot.ConsoleApp"
            };
            LogsUtils.Configuracion = ConfiguracionLog;
            if (ConfigurationManager.AppSettings["Debug"] == "1")
                LogsUtils.Configuracion.Debug = true;

            else if (ConfigurationManager.AppSettings["Debug"] == "0")
                LogsUtils.Configuracion.Debug = false;

            LogsUtils.Configuracion.RutaCarpetaLogs = ConfigurationManager.AppSettings["RutaCarpetaLogs"];
            return Task.CompletedTask;
        }

        #region Log overloads.
        public static Task Log(string message)
        {
            return Log(new LogMessage(LogSeverity.Info, "Logger", message));
        }
        public static Task Log(string message, string source)
        {
            return Log(new LogMessage(LogSeverity.Info, source, message));
        }
        public static Task Log(string message, string source, LogSeverity severity)
        {
            return Log(new LogMessage(severity, source, message));
        }
        public static Task Log(LogMessage message)
        {
            LogsUtils.Loguear(message.Message, message.SeverityToTipoLog(), $"Source: {message.Source}");
            return Task.CompletedTask;
        }
        #endregion
    }
}
