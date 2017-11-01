using System.Collections.Generic;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.API.Renderers
{
    public class TranslationRenderer : RendrerBase,
        IRenderResponseFromObject<TranslationModel, TranslationView>
    {
        private readonly IRenderEnum _enumRenderer;

        public TranslationRenderer(IRenderLink linkRenderer, IRenderEnum enumRenderer)
            : base(linkRenderer)
        {
            _enumRenderer = enumRenderer;
        }

        public TranslationView Render(TranslationModel source)
        {
            if (source == null)
            {
                return null;
            }

            var result = source.Map<TranslationModel, TranslationView>();

            result.Language = _enumRenderer.Render((LanguageType)source.LanguageId);

            var links = new List<LinkView>
            {
                LinkRenderer.Render("GetTranslationById", "self", new { id = source.Id }),
                LinkRenderer.Render("GetWordById", "word", new { id = source.WordId })
            };

            var link = LinkRenderer.ReRoute(source.Links.WithRel(RelTypes.Update));
            if (link != null)
                links.Add(link);
            link = LinkRenderer.ReRoute(source.Links.WithRel(RelTypes.Delete));
            if (link != null)
                links.Add(link);

            result.Links = links;
            return result;
        }
    }
}