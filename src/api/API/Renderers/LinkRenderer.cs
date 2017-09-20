using System.Collections.Generic;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using LinkView = Inshapardaz.Desktop.Api.Model.LinkView;

namespace Inshapardaz.Desktop.Api.Renderers
{
    public class LinkRenderer : IRenderLink
    {
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly ILogger<LinkRenderer> _log;
        private readonly IUrlHelper _urlHelper;

        public LinkRenderer(IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor, ILogger<LinkRenderer> log)
        {
            _actionContextAccessor = actionContextAccessor;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
            _log = log;
        }

        private string Scheme => _actionContextAccessor.ActionContext.HttpContext.Request.Scheme;
        
        public LinkView Render(string methodName, string rel, object data = null)
        {
            _log.LogTrace("Rendering link for {0}, with rel {1} and data", methodName, rel, data);
            return new LinkView { Href = _urlHelper.RouteUrl(methodName, data, Scheme).ToUri(), Rel = rel };
        }
        

        public LinkView RenderOrReRoute(IEnumerable<LinkModel> source, string methodName, string rel, object data = null)
        {
            var linkModel = source.WithRel(rel);

            if (linkModel != null)
            {
                return ReRoute(linkModel);
            }

            return Render(methodName, rel, data);
        }

        public LinkView ReRoute(LinkModel model)
        {
            if (model == null)
                return null;

            _log.LogTrace("Rerouting link for {0}, with rel {1}", model.Href, model.Rel);
            var host = _actionContextAccessor.ActionContext.HttpContext.Request.Host;
            return new LinkView { Href = model.Href.ChangeHost(host.Host, host.Port) , Rel = model.Rel };
        }
    }
}