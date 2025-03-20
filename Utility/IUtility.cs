using jiraApi.Model.ResponseModel;

namespace jiraApi.Utility
{
	public interface IUtility
	{
		Task<List<Bug>> MergedBugsDelivered(DateTime startDate, DateTime endDate);
		Task<List<EpicList>> MergedEpicList(DateTime startDate, DateTime endDate);
		Task<List<Automation>> MergedAutomationList(DateTime startDate, DateTime endDate);
		Task<List<Techtask>> MergedTechnicalTaskList(DateTime startDate, DateTime endDate);
		Task<List<Story>> MergedIndependentStoryList(DateTime startDate, DateTime endDate);
		Task<List<Bug>> MergedBugsCreated(DateTime startDate, DateTime endDate);
		Task<List<Ticket>> MergedTicketsWorkedUpon(DateTime startDate, DateTime endDate);
		Task<List<Ticket>> MergedTicketsResolved(DateTime startDate, DateTime endDate);
	}
}
