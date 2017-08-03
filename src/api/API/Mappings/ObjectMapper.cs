using System.Diagnostics;
using AutoMapper;

namespace Inshapardaz.Desktop.Api.Mappings
{
    public static class ObjectMapper
    {
        [DebuggerStepThrough]
        public static TDestination Map<TSource, TDestination>(this TSource source) where TSource : class
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        [DebuggerStepThrough]
        public static TDestination Map<TSource, TDestination>(this TSource source, TDestination target) where TSource : class
        {
            return Mapper.Map(source, target);
        }
    }
}
