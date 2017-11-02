using System.Collections.Generic;
using System.Linq;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Api.Renderers
{
    public interface IRenderWordPage
    {
        PageView<WordView> Render(PageRendererArgs<WordModel> source);
    }

    public class PageRenderer : RendrerBase, IRenderWordPage
    {
        private readonly IRenderWord _wordIndexRenderer;

        public PageRenderer(IRenderLink linkRenderer, IRenderWord wordIndexRenderer)
            : base(linkRenderer)
        {
            _wordIndexRenderer = wordIndexRenderer;
        }

        public PageView<WordView> Render(PageRendererArgs<WordModel> source)
        {
            var page = new PageView<WordView>(source.Page.PageCount, source.RouteArguments.PageSize, source.RouteArguments.PageNumber)
            {
                Data = source.Page.Data.Select(x => _wordIndexRenderer.Render(x))
            };

            var links = new List<LinkView>
            {
                LinkRenderer.Render(source.RouteName, RelTypes.Self,CreateRouteParameters(source, page.CurrentPageIndex, page.PageSize))
            };

            if (page.CurrentPageIndex < page.PageCount)
            {
                links.Add(LinkRenderer.Render(source.RouteName, RelTypes.Next, CreateRouteParameters(source, page.CurrentPageIndex + 1, page.PageSize)));
            }

            if (page.CurrentPageIndex > 1)
            {
                links.Add(LinkRenderer.Render(source.RouteName, RelTypes.Previous, CreateRouteParameters(source, page.CurrentPageIndex - 1, page.PageSize)));
            }

            page.Links = links;

            return page;
        }

        private object CreateRouteParameters(PageRendererArgs<WordModel> source, int pageNumber, int pageSize)
        {
            var args = source.RouteArguments ?? new PagedRouteArgs();
            args.PageNumber = pageNumber;
            args.PageSize = pageSize;
            return args;
        }
    }

    public class PageRendererArgs<T>
    {
        public string RouteName { get; set; }

        public PageModel<T> Page { get; set; }

        public PagedRouteArgs RouteArguments { get; set; }
    }
    public class PagedRouteArgs
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}