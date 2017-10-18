using System;
using Inshapardaz.Desktop.Common.Models;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Domain.Command
{
    public class DownloadDictionaryCommand : IRequest
    {
        public int DictionaryId { get; set; }

        public string DownloadLink { get; set; }

        public bool IsUpdate { get; set; }

        public Guid Id { get; set; }

        public DictionaryModel Result { get; set; }
    }
}