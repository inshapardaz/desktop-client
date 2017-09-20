﻿using System.Collections.Generic;
using System.Linq;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Api.Renderers
{
    public class WordIndexPageRenderer : RendrerBase, IRenderResponseFromObject<PageRendererArgs<WordModel>, PageView<WordView>>
    {
        private readonly IRenderResponseFromObject<WordModel, WordView> _wordIndexRenderer;

        public WordIndexPageRenderer(IRenderLink linkRenderer, IRenderResponseFromObject<WordModel, WordView> wordIndexRenderer)
            : base(linkRenderer)
        {
            _wordIndexRenderer = wordIndexRenderer;
        }

        public PageView<WordView> Render(PageRendererArgs<WordModel> source)
        {
            var page = new PageView<WordView>(source.Page.TotalCount, source.Page.PageSize, source.Page.PageNumber) { 
                Data = source.Page.Data.Select(x => _wordIndexRenderer.Render(x))
            };

            var links = new List<LinkView>
            {
                LinkRenderer.Render(source.RouteName, RelTypes.Self,
                                    CreateRouteParameters(source, page.CurrentPageIndex, page.PageSize))
            };

            if (page.CurrentPageIndex < page.PageCount)
            {
                links.Add(LinkRenderer.Render(source.RouteName, RelTypes.Next,
                                              CreateRouteParameters(source, page.CurrentPageIndex + 1, page.PageSize)));
            }

            if (page.CurrentPageIndex > 1)
            {
                links.Add(LinkRenderer.Render(source.RouteName, RelTypes.Previous,
                                              CreateRouteParameters(source, page.CurrentPageIndex - 1, page.PageSize)));
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