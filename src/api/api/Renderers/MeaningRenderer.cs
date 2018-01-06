using System.Collections.Generic;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Api.Renderers
{
    public interface IRenderMeaning
    {
        MeaningView Render(MeaningModel source, int dictionaryId);
    }

    public class MeaningRenderer : RendrerBase, IRenderMeaning
    {
        public MeaningRenderer(IRenderLink linkRenderer)
            : base(linkRenderer)
        {
        }

        public MeaningView Render(MeaningModel source, int dictionaryId)
        {
            var result = source.Map<MeaningModel, MeaningView>();

            var links = new List<LinkView>
            {
                LinkRenderer.Render("GetMeaningById", RelTypes.Self, new { id = dictionaryId, meaningId = source.Id }),
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