using jiraApi.HttpService.IHttpService;

namespace jiraApi.Services
{
	public class JiraService : IJiraService
	{
		private readonly IHttpClient _httpClient;

		public JiraService(IHttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<string> GetStringAsync(string uri)
		{
			return await _httpClient.GetAsync(uri);
		}
	}
}
