using System.Collections.Generic;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.API.Renderers
{
    public class RelationRenderer : RendrerBase,
        IRenderResponseFromObject<RelationshipModel, RelationshipView>
    {
        private readonly IRenderEnum _enumRenderer;

        public RelationRenderer(IRenderLink linkRenderer, IRenderEnum enumRenderer)
            : base(linkRenderer)
        {
            _enumRenderer = enumRenderer;
        }

        public RelationshipView Render(RelationshipModel source)
        {
            var result = source.Map<RelationshipModel, RelationshipView>();
            result.RelationType = _enumRenderer.Render(source.RelationType);

            var links = new List<LinkView>
            {
                LinkRenderer.Render("GetRelationById", RelTypes.Self, new { id = source.Id }),
                LinkRenderer.Render("GetWordById", "source-word", new { id = source.SourceWordId }),
                LinkRenderer.Render("GetWordById", "related-word", new { id = source.RelatedWordId })
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