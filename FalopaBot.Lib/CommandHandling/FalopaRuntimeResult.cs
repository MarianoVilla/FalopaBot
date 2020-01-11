using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalopaBot.Lib.CommandHandling
{
    public class FalopaRuntimeResult : RuntimeResult
    {
        public FalopaRuntimeResult(CommandError? Error, string Reason)
            : base(Error, Reason) { }

        public static FalopaRuntimeResult FromError(string Reason)
            => new FalopaRuntimeResult(CommandError.Unsuccessful, Reason);
        public static FalopaRuntimeResult FromSuccess(string Reason = null)
            => new FalopaRuntimeResult(null, Reason);
    }
}
