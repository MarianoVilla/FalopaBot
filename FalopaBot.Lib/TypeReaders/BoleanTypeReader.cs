using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FalopaBot.Lib.TypeReaders
{
    public class BooleanTypeReader : TypeReader
    {
        public override Task<TypeReaderResult> ReadAsync(ICommandContext context, string input, IServiceProvider services)
        {
            if (bool.TryParse(input, out bool Result))
                return Task.FromResult(TypeReaderResult.FromSuccess(Result));

            return Task.FromResult(TypeReaderResult.FromError(CommandError.ParseFailed,
                "Input could not be parsed as a boolean"));
        }
    }
}
