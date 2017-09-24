namespace Inshapardaz.Desktop.Common
{
    public interface IProvideUserSettings
    {
        string UserDataFolder { get;  }
        string DictionariesFolder { get; }
    }
}
