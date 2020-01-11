using Discord.Commands;
using FalopaBot.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FalopaBot.Lib.TypeReaders
{
    public class DrugTypeReader : TypeReader
    {
        public override Task<TypeReaderResult> ReadAsync(ICommandContext context, string input, IServiceProvider services)
        {
            if(Enum.TryParse(typeof(Drug), input, ignoreCase: true, out object Result))
                return Task.FromResult(TypeReaderResult.FromSuccess(Result));
               
            return Task.FromResult(TypeReaderResult.FromError(CommandError.ParseFailed,
                "Input could not be parsed as a fafa"));
        }
    }
}
