namespace EPTools.Common.Interfaces
{
    public interface IFetchService
    {
        Task<T> GetTFromEPFileAsync<T>(string filename);
        Task<T> GetTFromFileAsync<T>(string filename);
    }
}