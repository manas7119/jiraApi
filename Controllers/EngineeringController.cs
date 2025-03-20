using jiraApi.Model;
using jiraApi.Model.ResponseModel;
using jiraApi.Utility;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace jiraApi.Controllers
{
	[ApiController]
	[Route("api/Engineering")]
	public class EngineeringController : ControllerBase
	{
		private readonly IUtility _utility;
		private readonly ILogger<EngineeringController> _logger;

		public EngineeringController(ILogger<EngineeringController> logger, IUtility utility)
		{
			_logger = logger;
			_utility = utility;
		}

		[EnableCors("AnotherPolicy")]
		[HttpGet("EpicList")]
		public async Task<List<EpicList>> GetEpicList([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
		{
			return await _utility.MergedEpicList(startDate, endDate);
		}

		[EnableCors("AnotherPolicy")]
		[HttpGet("IndependentStory")]
		public async Task<List<Story>> GetIndependentStory([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
		{
			return await _utility.MergedIndependentStoryList(startDate, endDate);
		}

		[EnableCors("AnotherPolicy")]
		[HttpGet("TechnicalTask")]
		public async Task<List<Techtask>> GetTechnicalTaskCreated([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
		{
			return await _utility.MergedTechnicalTaskList(startDate, endDate);
		}

		[EnableCors("AnotherPolicy")]
		[HttpGet("Automation")]
		public async Task<List<Automation>> GetAutomationList([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
		{
			return await _utility.MergedAutomationList(startDate, endDate);
		}

		[EnableCors("AnotherPolicy")]
		[HttpGet("AutomationCount")]
		public async Task<int> GetAutomationListCount([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
		{
			var count = (await _utility.MergedAutomationList(startDate, endDate)).Count();
			return count;
		}

		[EnableCors("AnotherPolicy")]
		[HttpGet("BugsRaised")]
		public async Task<List<Bug>> GetBugRaised([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
		{
			return await _utility.MergedBugsCreated(startDate, endDate);
		}

		[EnableCors("AnotherPolicy")]
		[HttpGet("BugsDelivered")]
		public async Task<List<Bug>> GetBugsDelivered([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
		{
			return await _utility.MergedBugsDelivered(startDate, endDate);
		}

		[EnableCors("AnotherPolicy")]
		[HttpGet("TicketsWorked")]
		public async Task<List<Ticket>> GetTicketsWorkedUpon([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
		{
			return await _utility.MergedTicketsWorkedUpon(startDate, endDate);
		}

		[EnableCors("AnotherPolicy")]
		[HttpGet("TicketsResolved")]
		public async Task<List<Ticket>> GetTicketsResolved([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
		{
			return await _utility.MergedTicketsResolved(startDate, endDate);
		}

		//[EnableCors("AnotherPolicy")]
		//[HttpGet("SupportTicket")]
		//public async Task<List<SupportTicket>> GetSupportTicket([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
		//{
		//	return await _supportManager.GetSupportTickets(startDate, endDate);
		//}
	}
}
