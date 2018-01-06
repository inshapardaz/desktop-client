using System.Collections.Generic;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Api.Renderers
{
    public interface IRenderWord
    {
        WordView Render(WordModel source);
    }

    public class WordRenderer : RendrerBase, IRenderWord
    {
        public WordRenderer(IRenderLink linkRenderer)
            : base(linkRenderer)
        {
        }

        public WordView Render(WordModel source)
        {
            var result = source.Map<WordModel, WordView>();

            var links = new List<LinkView>
            {
                LinkRenderer.RenderOrReRoute(source.Links, "GetWordById", RelTypes.Self , new {id = source.DictionaryId, wordId = result.Id}),
                LinkRenderer.RenderOrReRoute(source.Links, "GetWordMeaningByWordId", RelTypes.Meanings, new {id = source.DictionaryId, wordId = result.Id}),
                LinkRenderer.RenderOrReRoute(source.Links, "GetWordTranslationsById", RelTypes.Translations, new {id = source.DictionaryId, wordId = result.Id}),
                LinkRenderer.RenderOrReRoute(source.Links, "GetWordRelationsById", RelTypes.Relationships, new {id = source.DictionaryId, wordId = result.Id}),
                LinkRenderer.RenderOrReRoute(source.Links, "GetDictionaryById", RelTypes.Dictionary, new {id = source.DictionaryId})
            };

            var link = LinkRenderer.ReRoute(source.Links.WithRel(RelTypes.Update));
            if (link != null)
                links.Add(link);
            link = LinkRenderer.ReRoute(source.Links.WithRel(RelTypes.Delete));
            if (link != null)
                links.Add(link);

            link = LinkRenderer.ReRoute(source.Links.WithRel(RelTypes.AddMeaning));
            if (link != null)
                links.Add(link);

            link = LinkRenderer.ReRoute(source.Links.WithRel(RelTypes.AddTranslation));
            if (link != null)
                links.Add(link);

            link = LinkRenderer.ReRoute(source.Links.WithRel(RelTypes.AddRelation));
            if (link != null)
                links.Add(link);

            result.Links = links;
            return result;
        }
    }
}