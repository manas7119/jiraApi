using jiraApi.Controllers;
using jiraApi.Manager.IManager;
using jiraApi.Model.ResponseModel;

namespace jiraApi.Utility
{
	public class Utility : IUtility
	{
		private readonly IGLIssueManager _glIssueManager;
		private readonly IMSMTAIssueManager _msmtaIssueManager;
		private readonly ILogger<EngineeringController> _logger;

		public Utility(IGLIssueManager glIssueManager, IMSMTAIssueManager msmtaIssueManager, ILogger<EngineeringController> logger)
		{
			_glIssueManager = glIssueManager;
			_msmtaIssueManager = msmtaIssueManager;
			_logger = logger;
		}

		public async Task<List<Automation>> MergedAutomationList(DateTime startDate, DateTime endDate)
		{
			List<Automation> mergedlist = new List<Automation>();

			var glTask = _glIssueManager.GetAutomationList(startDate, endDate);
			var msmtaTask = _msmtaIssueManager.GetAutomationList(startDate, endDate);

			await Task.WhenAll(glTask, msmtaTask);

			mergedlist.AddRange(glTask.Result);
			mergedlist.AddRange(msmtaTask.Result);

			return mergedlist;
		}

		public async Task<List<Bug>> MergedBugsCreated(DateTime startDate, DateTime endDate)
		{
			List<Bug> mergedlist = new List<Bug>();

			var glTask = _glIssueManager.GetBugsCreated(startDate, endDate);
			var msmtaTask = _msmtaIssueManager.GetBugsCreated(startDate, endDate);

			await Task.WhenAll(glTask, msmtaTask);

			mergedlist.AddRange(glTask.Result);
			mergedlist.AddRange(msmtaTask.Result);

			return mergedlist;
		}

		public async Task<List<Bug>> MergedBugsDelivered(DateTime startDate, DateTime endDate)
		{
			List<Bug> mergedlist = new List<Bug>();

			var glTask = _glIssueManager.GetBugsFixedByDev(startDate, endDate);
			var msmtaTask = _msmtaIssueManager.GetBugsFixedByDev(startDate, endDate);

			await Task.WhenAll(glTask, msmtaTask);

			mergedlist.AddRange(glTask.Result);
			mergedlist.AddRange(msmtaTask.Result);

			return mergedlist;
		}

		public async Task<List<EpicList>> MergedEpicList(DateTime startDate, DateTime endDate)
		{
			List<EpicList> mergedlist = new List<EpicList>();

			var glTask = _glIssueManager.GetEpicList(startDate, endDate);
			var msmtaTask = _msmtaIssueManager.GetEpicList(startDate, endDate);

			await Task.WhenAll(glTask, msmtaTask);

			mergedlist.AddRange(glTask.Result);
			mergedlist.AddRange(msmtaTask.Result);

			return mergedlist;
		}

		public async Task<List<Story>> MergedIndependentStoryList(DateTime startDate, DateTime endDate)
		{
			List<Story> mergedlist = new List<Story>();

			var glTask = _glIssueManager.GetIndependentStoryList(startDate, endDate);
			var msmtaTask = _msmtaIssueManager.GetIndependentStoryList(startDate, endDate);

			await Task.WhenAll(glTask, msmtaTask);

			mergedlist.AddRange(glTask.Result);
			mergedlist.AddRange(msmtaTask.Result);

			return mergedlist;
		}

		public async Task<List<Techtask>> MergedTechnicalTaskList(DateTime startDate, DateTime endDate)
		{
			List<Techtask> mergedlist = new List<Techtask>();

			var glTask = _glIssueManager.GetTechtaskList(startDate, endDate);
			var msmtaTask = _msmtaIssueManager.GetTechtaskList(startDate, endDate);

			await Task.WhenAll(glTask, msmtaTask);

			mergedlist.AddRange(glTask.Result);
			mergedlist.AddRange(msmtaTask.Result);

			return mergedlist;
		}

		public async Task<List<Ticket>> MergedTicketsWorkedUpon(DateTime startDate, DateTime endDate)
		{
			List<Ticket> mergedlist = new List<Ticket>();

			var glTask = _glIssueManager.GetTicketsWorkedUpon(startDate, endDate);
			var msmtaTask = _msmtaIssueManager.GetTicketsWorkedUpon(startDate, endDate);

			await Task.WhenAll(glTask, msmtaTask);

			mergedlist.AddRange(glTask.Result);
			mergedlist.AddRange(msmtaTask.Result);

			return mergedlist;
		}

		public async Task<List<Ticket>> MergedTicketsResolved(DateTime startDate, DateTime endDate)
		{
			List<Ticket> mergedlist = new List<Ticket>();

			var glTask = _glIssueManager.GetTicketsResolved(startDate, endDate);
			var msmtaTask = _msmtaIssueManager.GetTicketsResolved(startDate, endDate);

			await Task.WhenAll(glTask, msmtaTask);

			mergedlist.AddRange(glTask.Result);
			mergedlist.AddRange(msmtaTask.Result);

			return mergedlist;
		}
	}
}
