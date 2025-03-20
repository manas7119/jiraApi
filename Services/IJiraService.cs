namespace jiraApi.Services
{
	public interface IJiraService
	{
		Task<string> GetStringAsync(string uri);
	}
}
