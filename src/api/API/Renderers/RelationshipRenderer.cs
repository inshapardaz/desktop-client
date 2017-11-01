using System.Collections.Generic;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Api.Renderers
{
    public interface IRenderRelationship
    {
        RelationshipView Render(RelationshipModel source, int dictionaryId);
    }

    public class RelationshipRenderer : RendrerBase, IRenderRelationship
    {
        private readonly IRenderEnum _enumRenderer;

        public RelationshipRenderer(IRenderLink linkRenderer, IRenderEnum enumRenderer)
            : base(linkRenderer)
        {
            _enumRenderer = enumRenderer;
        }

        public RelationshipView Render(RelationshipModel source, int dictionaryId)
        {
            var result = source.Map<RelationshipModel, RelationshipView>();
            result.RelationType = _enumRenderer.Render(source.RelationType);

            var links = new List<LinkView>
            {
                LinkRenderer.Render("GetRelationById", RelTypes.Self, new { id = dictionaryId, relationshipId = source.Id }),
                LinkRenderer.Render("GetWordById",  RelTypes.SourceWord, new { id = dictionaryId, wordId = source.SourceWordId }),
                LinkRenderer.Render("GetWordById", RelTypes.RelatedWord, new { id = dictionaryId, wordId = source.RelatedWordId })
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