using System.Collections.Generic;
using System.Linq;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Api.Renderers
{
    public class DictionaryRenderer : RendrerBase, IRenderResponseFromObject<DictionaryModel, DictionaryView>
    {
        private readonly string[] _indexes =
        {
            "آ", "ا", "ب", "پ", "ت", "ٹ", "ث", "ج", "چ", "ح", "خ", "د", "ڈ", "ذ", "ر", "ڑ", "ز", "ژ", "س", "ش", "ص",
            "ض", "ط", "ظ", "ع", "غ", "ف", "ق", "ک", "گ", "ل", "م", "ن", "و", "ہ", "ء", "ی"
        };


        public DictionaryRenderer(IRenderLink linkRenderer)
            : base(linkRenderer)
        {
        }

        public DictionaryView Render(DictionaryModel source)
        {
            var links = new List<LinkView>
            {
                LinkRenderer.RenderOrReRoute(source.Links, "GetDictionaryById", RelTypes.Self, new {id = source.Id}),
                LinkRenderer.RenderOrReRoute(source.Links, "GetWords", RelTypes.Index, new {id = source.Id}),
                LinkRenderer.RenderOrReRoute(source.Links, "SearchDictionary", RelTypes.Search, new {id = source.Id}),
            };

            if (source.IsPublic)
            {
                links.Add(LinkRenderer.RenderOrReRoute(source.Links, "DownloadDictionary", RelTypes.Download, new { id = source.Id, format = "dat" }));
            }

            var indexes = new List<LinkView>(_indexes.Select(i => LinkRenderer.RenderOrReRoute(source.Indexes, "GetWordsListStartWith", i,
                                                                                      new { id = source.Id, startingWith = i })));

            var result = source.Map<DictionaryModel, DictionaryView>();
            result.Links = links;
            result.Indexes = indexes;
            return result;
        }
    }
}