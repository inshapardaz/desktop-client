using System.Collections.Generic;
using Inshapardaz.Data.Entities;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.API.Renderers
{
    public class WordDetailRenderer : RendrerBase,
        IRenderResponseFromObject<WordDetailModel, WordDetailView>
    {
        private readonly IRenderEnum _enumRenderer;

        public WordDetailRenderer(IRenderLink linkRenderer, IRenderEnum enumRenderer)
            : base(linkRenderer)
        {
            _enumRenderer = enumRenderer;
        }

        public WordDetailView Render(WordDetailModel source)
        {
            if (source == null)
            {
                return null;
            }
            WordDetailView result = source.Map<WordDetailModel, WordDetailView>();
            result.Language = _enumRenderer.Render((Languages)source.LanguageId);
            var links = new List<LinkView>
            {
                LinkRenderer.Render("GetWordDetailsById", RelTypes.Self, new {id = source.Id}),
                LinkRenderer.Render("GetWordById", "word", new {id = source.WordId}),
                LinkRenderer.Render("GetWordTranslationsByDetailId", "translations", new {id = source.Id}),
                LinkRenderer.Render("GetWordMeaningByWordDetailId", "meanings", new {id = source.Id})
            };

            var link = LinkRenderer.ReRoute(source.Links.WithRel(RelTypes.Update));
            if (link != null)
                links.Add(link);
            link = LinkRenderer.ReRoute(source.Links.WithRel(RelTypes.Delete));
            if (link != null)
                links.Add(link);
            link = LinkRenderer.ReRoute(source.Links.WithRel(RelTypes.AddTranslation));
            if (link != null)
                links.Add(link);
            link = LinkRenderer.ReRoute(source.Links.WithRel(RelTypes.AddMeaning));
            if (link != null)
                links.Add(link);

            result.Links = links;
            return result;
        }
    }
}