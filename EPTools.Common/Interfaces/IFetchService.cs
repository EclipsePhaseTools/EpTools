namespace EPTools.Common.Interfaces
{
    public interface IFetchService
    {
        Task<T> GetTFromEPFileAsync<T>(string filename) where T : new();
        Task<T> GetTFromFileAsync<T>(string filename) where T : new();
    }
}