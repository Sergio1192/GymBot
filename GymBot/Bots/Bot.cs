// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.11.1

using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GymVideosGetter.Models;
using GymVideosGetter.Services;

namespace GymBot.Bots
{
    public class Bot : ActivityHandler
    {
        private readonly IGymVideosGetterService _webScrapperService;

        public Bot(IGymVideosGetterService webScrapperService)
        {
            _webScrapperService = webScrapperService ?? throw new ArgumentNullException(nameof(webScrapperService));
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var intialText = $"Voy a intentar recuperar los vídeos de {GymVideosGetter.Web.Webs.GYM_VIRTUAL.Name} para hoy";
            await turnContext.SendActivityAsync(MessageFactory.Text(text: intialText, ssml: intialText), cancellationToken);

            IEnumerable<VideoModel> videos = new List<VideoModel>();
            try
            {
                videos = await _webScrapperService.GetVideosByWebNameAsync(GymVideosGetter.Web.Webs.GYM_VIRTUAL.Name);
            }
            catch { }

            var attachments = new List<Attachment>();
            foreach (var video in videos)
            {
                var attachment = new VideoCard(
                    title: video.Title,
                    text: video.Text,
                    media: new[] { new MediaUrl(video.Url) }
                ).ToAttachment();

                attachments.Add(attachment);
            }

            var textOk = $"Aquí tienes los vídeos de {GymVideosGetter.Web.Webs.GYM_VIRTUAL.Name} para hoy";
            var textKo = $"Lo siento, no he podido recuperar ningun vídeo de {GymVideosGetter.Web.Webs.GYM_VIRTUAL.Name} para hoy";           
            var text = attachments.Any() ? textOk : textKo;

            var videoMsg = MessageFactory.Carousel(attachments, text: text, ssml: text);

            await turnContext.SendActivityAsync(videoMsg, cancellationToken);
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
