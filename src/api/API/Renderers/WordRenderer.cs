using System.Collections.Generic;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Api.Renderers
{
    public class WordRenderer : RendrerBase, IRenderResponseFromObject<WordModel, WordView>
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
                LinkRenderer.RenderOrReRoute(source.Links, "GetWordById", "self", new {id = result.Id}),
                LinkRenderer.RenderOrReRoute(source.Links, "GetWordRelationsById", "relations", new {id = result.Id}),
                LinkRenderer.RenderOrReRoute(source.Links, "GetWordDetailsById", "details", new {id = result.Id}),
                LinkRenderer.RenderOrReRoute(source.Links, "GetDictionaryById", "dictionary", new {id = source.DictionaryId})
            };

            var link = LinkRenderer.ReRoute(source.Links.WithRel(RelTypes.Update));
            if (link != null)
                links.Add(link);
            link = LinkRenderer.ReRoute(source.Links.WithRel(RelTypes.Delete));
            if (link != null)
                links.Add(link);

            link = LinkRenderer.ReRoute(source.Links.WithRel(RelTypes.AddDetail));
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