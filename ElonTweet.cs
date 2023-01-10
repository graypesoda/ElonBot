using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity.Extensions;
using ElonBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonBot
{
    public class ElonTweet : BaseCommandModule
    {
        [Command("test")]
        private async Task Response(CommandContext context)
        {
            await context.Channel.SendMessageAsync("ADVENTURE TIME IS FUCKIN' GAY!");
            var interactivity = context.Client.GetInteractivity();
            var rawMessage = await interactivity.WaitForMessageAsync(x => true);
            var message = rawMessage.Result.Content;

            string[] triggerWords = new string[] { "elon", "elon musk", "musk", "grimes", "tesla", "spacex", "space x" };
            string[] videoGameNames = new string[] {"Bloodborne", "Zelda", "Dark Souls"};
            string[] socialMediaNames = new string[] {"Twitter", "Reddit", "Instagram"};

            if (triggerWords.Contains(message.ToLower().Trim()))
            {
                //assign random name for each value in string array
                Random rng = new Random();
                string socialMediaName = socialMediaNames[rng.Next(socialMediaNames.Length)];
                string videoGameName = videoGameNames[rng.Next(videoGameNames.Length)];

                await context.Channel.SendMessageAsync(socialMediaName + " is the " + videoGameName + " of social media");
            }
        }
    }
}
