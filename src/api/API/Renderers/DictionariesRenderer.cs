using System.Collections.Generic;
using System.Linq;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Api.Renderers
{
    public class DictionariesRenderer : RendrerBase, IRenderResponseFromObject<DictionariesModel, DictionariesView>
    {
        private readonly IRenderResponseFromObject<DictionaryModel, DictionaryView> _dictionaryRenderer;

        public DictionariesRenderer(IRenderLink linkRenderer,
                                    IRenderResponseFromObject<DictionaryModel, DictionaryView> dictionaryRenderer)
            : base(linkRenderer)
        {
            _dictionaryRenderer = dictionaryRenderer;
        }

        public DictionariesView Render(DictionariesModel source)
        {
            var links = new List<LinkView>
            {
                LinkRenderer.RenderOrReRoute(source.Links, "GetDictionaries", RelTypes.Self, null)
            };


            var view = source.Map<DictionariesModel, DictionariesView>();
            view.Links = links;
            view.Items = source.Items.Select(d => _dictionaryRenderer.Render(d));
            return view;
        }
    }
}