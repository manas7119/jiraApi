namespace jiraApi.HttpService.IHttpService
{
    public interface IHttpClient
    {
        Task<string> GetAsync(string url);
    }
}
