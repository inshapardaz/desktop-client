using System.Collections.Generic;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Api.Renderers
{
    public interface IRenderTranslation
    {
        TranslationView Render(TranslationModel source, int dictionaryId);
    }

    public class TranslationRenderer : RendrerBase, IRenderTranslation
    {
        private readonly IRenderEnum _enumRenderer;

        public TranslationRenderer(IRenderLink linkRenderer, IRenderEnum enumRenderer)
            : base(linkRenderer)
        {
            _enumRenderer = enumRenderer;
        }

        public TranslationView Render(TranslationModel source, int dictionaryId)
        {
            if (source == null)
            {
                return null;
            }

            var result = source.Map<TranslationModel, TranslationView>();

            result.Language = _enumRenderer.Render((LanguageType)source.LanguageId);

            var links = new List<LinkView>
            {
                LinkRenderer.Render("GetTranslationById", RelTypes.Self, new { id = dictionaryId, translationId  = source.Id }),
                LinkRenderer.Render("GetWordById", RelTypes.Word, new { id = dictionaryId, wordId = source.WordId })
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