using System.Collections.Generic;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Api.Renderers
{
    public interface IRenderEntry
    {
        EntryView Render(EntryModel model);
    }

    public class EntryRenderer : RendrerBase, IRenderEntry
    {
        public EntryRenderer(IRenderLink linkRenderer)
            : base(linkRenderer)
        {
        }

        public EntryView Render(EntryModel model)
        {
            if (model == null)
            {
                var links = new List<LinkView>
                {
                    LinkRenderer.Render("Entry", RelTypes.Self),
                    LinkRenderer.Render("GetDictionaries", RelTypes.Dictionaries),
                    LinkRenderer.Render("GetLanguages", RelTypes.Languages),
                    LinkRenderer.Render("GetAttributes", RelTypes.Attributes),
                    LinkRenderer.Render("GetRelationTypes", RelTypes.RelationshipTypes),
                    LinkRenderer.Render("GetWordAlternatives", RelTypes.Thesaurus, new {word = "word"})
                };
                return new EntryView {Links = links};
            }

            return new EntryView
            {
                Links = new List<LinkView>
                {
                    LinkRenderer.RenderOrReRoute(model.Links, "Entry", RelTypes.Self),
                    LinkRenderer.RenderOrReRoute(model.Links,"GetDictionaries", RelTypes.Dictionaries),
                    LinkRenderer.RenderOrReRoute(model.Links,"GetLanguages", RelTypes.Languages),
                    LinkRenderer.RenderOrReRoute(model.Links,"GetAttributes", RelTypes.Attributes),
                    LinkRenderer.RenderOrReRoute(model.Links,"GetRelationTypes", RelTypes.RelationshipTypes),
                    LinkRenderer.RenderOrReRoute(model.Links,"GetWordAlternatives", RelTypes.Thesaurus, new {word = "word"})
                }
            };
        }
    }
}