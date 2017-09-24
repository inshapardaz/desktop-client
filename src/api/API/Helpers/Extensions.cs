using System;
using System.Collections.Generic;
using System.Linq;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Api.Helpers
{
    public static class Extensions
    {
        public static Uri ToUri(this string url)
        {
            return new Uri(url);
        }

        public static Uri ChangeHost(this Uri url, string host, int? port)
        {
            var builder = new UriBuilder(url) { Host = host};
            if (port.HasValue)
                builder.Port = port.Value;
            return builder.Uri;
        }

        public static LinkModel WithRel(this IEnumerable<LinkModel> links, string relType)
        {
            return links?.SingleOrDefault(l => l.Rel == relType);
        }

        public static bool HasLinkWithRel(this IEnumerable<LinkModel> links, string relType)
        {
            return links?.SingleOrDefault(l => l.Rel == relType) != null;
        }
    }
}
