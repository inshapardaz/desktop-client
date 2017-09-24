using System.Collections.Generic;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.API.Renderers
{
    public class MeaningRenderer : RendrerBase,
        IRenderResponseFromObject<MeaningModel, MeaningView>
    {
        public MeaningRenderer(IRenderLink linkRenderer)
            : base(linkRenderer)
        {
        }

        public MeaningView Render(MeaningModel source)
        {
            var result = source.Map<MeaningModel, MeaningView>();

            var links = new List<LinkView>
            {
                LinkRenderer.Render("GetMeaningById", RelTypes.Self, new { id = source.Id }),
                LinkRenderer.Render("GetDetailsById", "worddetail", new { id = source.WordDetailId })
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