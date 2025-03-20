
using jiraApi.HttpService.IHttpService;

namespace jiraApi.HttpService
{
    public class standardHttpClient : IHttpClient
	{
		private readonly HttpClient _client;

		public standardHttpClient()
		{
			_client = new HttpClient();
		}
		public async Task<string> GetAsync(string url)
		{
			var response = await _client.GetAsync(url);
			return await response.Content.ReadAsStringAsync();
		}
	}
}
