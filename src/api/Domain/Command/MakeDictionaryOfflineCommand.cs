namespace Inshapardaz.Desktop.Domain.Command
{
    public class MakeDictionaryOfflineCommand : Command
    {
        public int DictionaryId { get; set; }

        public string DownloadLink { get; set; }

        public bool IsUpdate { get; set; }
    }
}