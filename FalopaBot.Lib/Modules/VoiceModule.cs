using Discord;
using Discord.Audio;
using Discord.Commands;
using FalopaBot.Lib.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FalopaBot.Lib.Modules
{
    public class VoiceModule : ModuleBase<SocketCommandContext>
    {
        const string NoChannelError = "User must be in a voice channel, or a voice channel must be passed as an argument.";
        private static Dictionary<ulong, IAudioClient> Connections = new Dictionary<ulong, IAudioClient>();

        // The command's Run Mode MUST be set to RunMode.Async, otherwise, being connected to a voice channel will block the gateway thread.
        [Command("join", RunMode = RunMode.Async)]
        public async Task JoinChannel(IVoiceChannel Channel = null)
        {
            // Get the audio channel
            Channel = Channel ?? (Context.User as IGuildUser)?.VoiceChannel;
            if (Channel == null) 
            {
                await Context.Channel.SendMessageAsync(NoChannelError);
                return;
            }
            // For the next step with transmitting audio, you would want to pass this Audio Client in to a service.
            var audioClient = await Channel.ConnectAsync();
            Connections.Add(Channel.Guild.Id, audioClient);
        }
        [Command("leave", RunMode = RunMode.Async)]
        public async Task LeaveChannel(IVoiceChannel Channel = null)
        {
            Channel = Channel ?? (Context.User as IGuildUser)?.VoiceChannel;
            if (Channel == null)
            {
                await Context.Channel.SendMessageAsync(NoChannelError);
                return;
            }
            await Channel.DisconnectAsync();
            Connections.Remove(Channel.Guild.Id);
        }
        //TODO: play command.
        [Command("randomsound", RunMode = RunMode.Async)]
        public async Task RandomSoundAsync()
        {
            var GuildId = (Context.User as IGuildUser).GuildId;
            var client = Connections.GetValueOrDefault(GuildId);
            await RandomSound(client);
        }
        private async Task RandomSound(IAudioClient connection)
        {
            await Say(connection, FalopaSound.RandomSound());
        }

        private async Task Say(IAudioClient connection, FalopaSound sound)
        {
            try
            {
                await connection.SetSpeakingAsync(true); // send a speaking indicator

                var psi = new ProcessStartInfo
                {
                    FileName = @"F:\Source\FalopaBot\FalopaBot.Lib\Modules\ffmpeg.exe",
                    Arguments = $@"-i ""{sound.Filename}"" -ac 2 -f s16le -ar 48000 pipe:1",
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                };
                var ffmpeg = Process.Start(psi);

                var output = ffmpeg.StandardOutput.BaseStream;
                var discord = connection.CreatePCMStream(AudioApplication.Voice);
                await output.CopyToAsync(discord);
                await discord.FlushAsync();

                await connection.SetSpeakingAsync(false); // we're not speaking anymore
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"- {ex.StackTrace}");
            }
        }
    }
}
