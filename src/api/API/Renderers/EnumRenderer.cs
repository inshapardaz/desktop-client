using System;
using System.Collections.Generic;
using System.Text;
using Inshapardaz.Desktop.Api.Helpers;

namespace Inshapardaz.Desktop.Api.Renderers
{
    public class EnumRenderer : IRenderEnum
    {
        public string Render<T>(string source)
        {
            return EnumHelper.GetEnumDescription<T>(source);
        }

        public string Render<T>(T source)
        {
            return EnumHelper.GetEnumDescription<T>(source);
        }

        public string RenderFlags<T>(T source)
        {
            return EnumHelper.GetFlagDescription<T>(source);
        }
    }
}
