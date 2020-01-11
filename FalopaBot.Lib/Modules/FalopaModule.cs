using Discord.Commands;
using FalopaBot.Lib.CommandHandling;
using FalopaBot.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FalopaBot.Lib.Modules
{
    public class FalopaModule : ModuleBase<SocketCommandContext>
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        [Command("gethigh")]
        [Alias("falopeate", "take", "datecon")]
        public async Task<RuntimeResult> GetHighAsync(Drug TheDrug)
        {
            switch (TheDrug)
            {
                case Drug.Fafafa:
                case Drug.Falopa:
                case Drug.FasoRico:
                case Drug.LSD:
                case Drug.Merluza: return FalopaRuntimeResult.FromSuccess($"¿Tenés {TheDrug.ToString()}? ¡Al toque, Roque!");
                default: return FalopaRuntimeResult.FromError("Nah, paso.");
            }
        }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    }
}
