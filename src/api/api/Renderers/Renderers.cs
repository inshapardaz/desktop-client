using System.Collections.Generic;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Api.Renderers
{
    public interface IRenderLink
    {
        LinkView Render(string methodName, string rel, object data = null);

        LinkView RenderOrReRoute(IEnumerable<LinkModel> source, string methodName, string rel, object data = null);

        LinkView ReRoute(LinkModel model);
    }

    public interface IRenderEnum
    {
        string Render<T>(string source);

        string Render<T>(T source);

        string RenderFlags<T>(T source);
    }
}
