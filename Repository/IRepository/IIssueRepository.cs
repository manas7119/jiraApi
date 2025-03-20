using jiraApi.Model;
using jiraApi.Model.ResponseModel;

namespace jiraApi.Repository.IRepository
{
    public interface IIssueRepository
    {
        Task<List<Issue>> GetAutomationList(DateTime startDate, DateTime endDate, string ProjectKey);
        Task<List<Issue>> GetBugDelivered(DateTime startDate, DateTime endDate, string ProjectKey);
        Task<List<Issue>> GetIndependentStoryList(DateTime startDate, DateTime endDate, string ProjectKey);
        Task<List<Issue>> GetTechTaskList(DateTime startDate, DateTime endDate, string ProjectKey);
        Task<List<Issue>> GetBugsCreated(DateTime startDate, DateTime endDate, string ProjectKey);
        Task<List<EpicList>> GetEpicList(DateTime startDate, DateTime endDate, string ProjectKey);
        Task<List<Issue>> GetTicketsWorkedUpon(DateTime startDate, DateTime endDate, string ProjectKey);
        Task<List<Issue>> GetTicketsResolved(DateTime startDate, DateTime endDate, string ProjectKey);

	}
}
