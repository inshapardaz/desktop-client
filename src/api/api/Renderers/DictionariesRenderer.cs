using System.Collections.Generic;
using System.Linq;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Api.Renderers
{
    public interface IRenderDictionaries
    {
        DictionariesView Render(DictionariesModel source);
    }

    public class DictionariesRenderer : RendrerBase, IRenderDictionaries
    {
        private readonly IRenderDictionary _dictionaryRenderer;

        public DictionariesRenderer(IRenderLink linkRenderer, IRenderDictionary dictionaryRenderer)
            : base(linkRenderer)
        {
            _dictionaryRenderer = dictionaryRenderer;
        }

        public DictionariesView Render(DictionariesModel source)
        {
            var links = new List<LinkView>
            {
                LinkRenderer.RenderOrReRoute(source.Links, "GetDictionaries", RelTypes.Self)
            };


            var view = source.Map<DictionariesModel, DictionariesView>();
            view.Links = links;
            view.Items = source.Items.Select(d => _dictionaryRenderer.Render(d));
            return view;
        }
    }
}