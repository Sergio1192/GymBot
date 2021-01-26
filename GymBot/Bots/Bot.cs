// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.11.1

using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GymBot.Bots
{
    public class Bot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var replyText = $"Echo: {turnContext.Activity.Text}";
            var textMsg = MessageFactory.Text(replyText, replyText);
            //await turnContext.SendActivityAsync(, cancellationToken);

            ///
            /*var videoMsg = MessageFactory.Attachment(
                new VideoCard(
                    title: "My Video",
                    subtitle: "a subtitle", 
                    text: "some text",
                    autostart: true,
                    media: new[] 
                    { 
                        new MediaUrl(@"https://www.youtube.com/watch?v=S8tjd5oNtQk"),
                        new MediaUrl(@"https://www.youtube.com/watch?v=BjO7DpOxPRs")
                    }
                ).ToAttachment()
            );*/

            var videoMsg = MessageFactory.Carousel(
                new Attachment[]
                {
                    new VideoCard(
                        title: "My Video",
                        subtitle: "a subtitle",
                        text: "some text",
                        autostart: true,
                        media: new[]
                        {
                            new MediaUrl(@"https://www.youtube.com/watch?v=S8tjd5oNtQk"),
                        }
                    ).ToAttachment(),
                    new VideoCard(
                        title: "My Video",
                        subtitle: "a subtitle",
                        text: "some text",
                        autostart: false,
                        media: new[]
                        {
                            new MediaUrl(@"https://www.youtube.com/watch?v=BjO7DpOxPRs")
                        }
                    ).ToAttachment()
                }
            );

            //await turnContext.SendActivityAsync(videoMsg, cancellationToken);

            await turnContext.SendActivitiesAsync(
                new IActivity[]
                {
                    textMsg,
                    videoMsg
                }, cancellationToken
            );
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Hello and welcome!";
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }
    }
}
