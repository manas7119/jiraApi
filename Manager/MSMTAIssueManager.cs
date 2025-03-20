using jiraApi.Constants;
using jiraApi.Manager.IManager;
using jiraApi.Model;
using jiraApi.Model.ResponseModel;
using jiraApi.Repository.IRepository;
using System.Runtime.CompilerServices;

namespace jiraApi.Manager
{
	public class MSMTAIssueManager : IMSMTAIssueManager
	{
		private readonly IIssueRepository _issueRepository;
		public MSMTAIssueManager(IIssueRepository issueRepository)
		{
			_issueRepository = issueRepository;
		}

		public async Task<List<Automation>> GetAutomationList(DateTime startDate, DateTime endDate)
		{
			List<Issue> automationList = await _issueRepository.GetAutomationList(startDate, endDate, "PREP");

			List<Automation> automation = new List<Automation>();
			foreach (Issue issue in automationList)
			{
				var _automation = new Automation
				{
					key = issue.Key,
					summary = issue.Fields.Summary,
					teams = issue.Fields.CustomField_10057?.Select(cf => cf.Value).ToList() ?? new List<string>(),
					visualizedData = $"{issue.Key} : {issue.Fields.Summary}"
				};
				automation.Add(_automation);
			}
			return automation;
		}

		public async Task<List<Bug>> GetBugsCreated(DateTime startDate, DateTime endDate)
		{
			List<Issue> bugsCreated = await _issueRepository.GetBugsCreated(startDate, endDate, "PREP");
			var filteredBugsCreated = bugsCreated
				.Where(issue => (issue.Fields.Creator != null) ||
					(issue.Fields.Reporter != null) &&
					(Constant.QAAccountId.ContainsValue(issue.Fields.Creator.AccountId) ||
					Constant.QAAccountId.ContainsValue(issue.Fields.Creator.AccountId)))
					.ToList();

			List<Bug> bugs = new List<Bug>();
			foreach (Issue issue in bugsCreated)
			{
				var listString = new List<String>
				{
					Constant.GetTeamForAssignee(issue.Fields.Assignee.AccountId)
				};
				var bug = new Bug
				{
					key = issue.Key,
					summary = issue.Fields.Summary,
					teams = listString,
					visualizedData = $"{issue.Key} : {issue.Fields.Summary}"
				};
				bugs.Add(bug);
			}
			return bugs;
		}

		public async Task<List<Bug>> GetBugsFixedByDev(DateTime startDate, DateTime endDate)
		{
			List<Issue> bugsFixed = await _issueRepository.GetBugDelivered(startDate, endDate, "PREP");
			var filteredBugs = bugsFixed
				.Where(issue => issue.Fields.Assignee != null && Constant.QAAccountId.ContainsValue(issue.Fields.Assignee.AccountId))
				.ToList();

			List<Bug> bugs = new List<Bug>();
			foreach (var issue in filteredBugs)
			{
				var listString = new List<String>
				{
					Constant.GetTeamForAssignee(issue.Fields.Assignee.AccountId)
				};
				var bug = new Bug
				{
					key = issue.Key,
					summary = issue.Fields.Summary,
					teams = listString,
					visualizedData = $"{issue.Key} : {issue.Fields.Summary}"
				};

				bugs.Add(bug);
			}
			return bugs;
		}

		public async Task<List<EpicList>> GetEpicList(DateTime startDate, DateTime endDate)
		{
			return await _issueRepository.GetEpicList(startDate, endDate, "PREP");
		}

		public async Task<List<Story>> GetIndependentStoryList(DateTime startDate, DateTime endDate)
		{
			List<Issue> storyList = await _issueRepository.GetIndependentStoryList(startDate, endDate, "PREP");

			List<Story> stories = new List<Story>();
			foreach (Issue issue in storyList)
			{
				var story = new Story
				{
					key = issue.Key,
					summary = issue.Fields.Summary,
					teams = issue.Fields.CustomField_10057?.Select(cf => cf.Value).ToList() ?? new List<string>(),
					visualizedData = $"{issue.Key} : {issue.Fields.Summary}"
				};
				stories.Add(story);
			}
			return stories;
		}

		public async Task<List<Techtask>> GetTechtaskList(DateTime startDate, DateTime endDate)
		{
			List<Issue> techTasks = await _issueRepository.GetTechTaskList(startDate, endDate, "PREP");
			var filteredtechTasks = techTasks
				.Where(issue => issue.Fields.Assignee != null && Constant.QAAccountId.ContainsValue(issue.Fields.Assignee.AccountId))
				.ToList();

			List<Techtask> techTasklist = new List<Techtask>();
			foreach (Issue issue in filteredtechTasks)
			{
				var listString = new List<String>
				{
					Constant.GetTeamForAssignee(issue.Fields.Assignee.AccountId)
				};
				var techTask = new Techtask
				{
					key = issue.Key,
					summary = issue.Fields.Summary,
					teams = listString,
					visualizedData = $"{issue.Key} : {issue.Fields.Summary}"
				};
				techTasklist.Add(techTask);
			}
			return techTasklist;
		}

		public async Task<List<Ticket>> GetTicketsWorkedUpon(DateTime startDate, DateTime endDate)
		{
			List<Issue> tickets = await _issueRepository.GetTicketsWorkedUpon(startDate, endDate, "PREP");
			var filteredTickets = tickets
				.Where(issue => issue.Fields.Assignee != null && Constant.QAAccountId.ContainsValue(issue.Fields.Assignee.AccountId))
				.ToList();

			List<Ticket> ticketlist = new List<Ticket>();
			foreach (Issue issue in filteredTickets)
			{
				var ticket = new Ticket
				{
					key = issue.Key,
					summary = issue.Fields.Summary,
					teams = issue.Fields.CustomField_10057?.Select(cf => cf.Value).ToList() ?? new List<string>(),
					visualizedData = $"{issue.Key} : {issue.Fields.Summary}",
					type = issue.Fields.IssueType.Name,
					status = issue.Fields.Status.Name,
				};
				ticketlist.Add(ticket);
			}
			return ticketlist;
		}

		public async Task<List<Ticket>> GetTicketsResolved(DateTime startDate, DateTime endDate)
		{
			List<Issue> tickets = await _issueRepository.GetTicketsResolved(startDate, endDate, "PREP");
			var filteredTickets = tickets
				.Where(issue => issue.Fields.Assignee != null && Constant.QAAccountId.ContainsValue(issue.Fields.Assignee.AccountId))
				.ToList();

			List<Ticket> ticketlist = new List<Ticket>();
			foreach (Issue issue in filteredTickets)
			{
				var ticket = new Ticket
				{
					key = issue.Key,
					summary = issue.Fields.Summary,
					teams = issue.Fields.CustomField_10057?.Select(cf => cf.Value).ToList() ?? new List<string>(),
					visualizedData = $"{issue.Key} : {issue.Fields.Summary}",
					type = issue.Fields.IssueType.Name,
					status = issue.Fields.Status.Name,
				};
				ticketlist.Add(ticket);
			}
			return ticketlist;
		}
	}
}
