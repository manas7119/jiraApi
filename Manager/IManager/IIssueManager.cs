using jiraApi.Model.ResponseModel;

namespace jiraApi.Manager.IManager
{
	public interface IIssueManager
	{
		Task<List<Bug>> GetBugsFixedByDev(DateTime startDate, DateTime endDate);
		Task<List<EpicList>> GetEpicList(DateTime startDate, DateTime endDate);
		Task<List<Automation>> GetAutomationList(DateTime startDate, DateTime endDate);
		Task<List<Techtask>> GetTechtaskList(DateTime startDate, DateTime endDate);
		Task<List<Story>> GetIndependentStoryList(DateTime startDate, DateTime endDate);
		Task<List<Bug>> GetBugsCreated(DateTime startDate, DateTime endDate);
		Task<List<Ticket>> GetTicketsWorkedUpon(DateTime startDate, DateTime endDate);
		Task<List<Ticket>> GetTicketsResolved(DateTime startDate, DateTime endDate);
	}
}
  