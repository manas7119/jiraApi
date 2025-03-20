using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Numerics;
using System.Threading.Tasks;
using jiraApi.HttpService.IHttpService;
using jiraApi.Model;
using jiraApi.Model.ResponseModel;
using jiraApi.Repository.IRepository;
using jiraApi.Constants;

namespace jiraApi.Repository
{
	public class IssueRepository : IIssueRepository
	{
		//public IssueRepository(IHttpClient httpClient)
		//{
		//	_httpClient = httpClient;
		//}

		public async Task<List<Issue>> GetAutomationList(DateTime startDate, DateTime endDate, string ProjectKey)
		{
			// Construct the base URL
			string baseUrl = UrlManager.url("Automation", startDate, endDate, ProjectKey);

			// Fetch the total number of issues matching the JQL
			int totalIssues = await FetchTotalIssuesCount(baseUrl);

			//this --FetchTotalIssuesCount can be called inside the below function call --FetchAllIssues

			// Fetch all issues where bugs were fixed by developers within the date range
			List<Issue> automationScripts = await FetchAllIssues(totalIssues, baseUrl);

			// Return the list of issues
			return automationScripts;
		}

		public async Task<List<Issue>> GetTicketsWorkedUpon(DateTime startDate, DateTime endDate, string ProjectKey)
		{
			// Construct the base URL
			string baseUrl = UrlManager.url("TicketWorkedUpon", startDate, endDate, ProjectKey);

			// Fetch the total number of issues matching the JQL
			int totalIssues = await FetchTotalIssuesCount(baseUrl);

			//this --FetchTotalIssuesCount can be called inside the below function call --FetchAllIssues

			// Fetch all issues where bugs were fixed by developers within the date range
			List<Issue> tickets = await FetchAllIssues(totalIssues, baseUrl);

			// Return the list of issues
			return tickets;
		}

		public async Task<List<Issue>> GetTicketsResolved(DateTime startDate, DateTime endDate, string ProjectKey)
		{
			// Construct the base URL
			string baseUrl = UrlManager.url("TicketsDelivered", startDate, endDate, ProjectKey);

			// Fetch the total number of issues matching the JQL
			int totalIssues = await FetchTotalIssuesCount(baseUrl);

			//this --FetchTotalIssuesCount can be called inside the below function call --FetchAllIssues

			// Fetch all issues where bugs were fixed by developers within the date range
			List<Issue> tickets = await FetchAllIssues(totalIssues, baseUrl);

			// Return the list of issues
			return tickets;
		}

		public async Task<List<Issue>> GetBugDelivered(DateTime startDate, DateTime endDate, string ProjectKey)
		{
			string baseUrl = UrlManager.url("BugsDelivered", startDate, endDate, ProjectKey);

			// Fetch the total number of issues matching the JQL
			int totalIssues = await FetchTotalIssuesCount(baseUrl);

			// Fetch all issues where bugs were fixed by developers within the date range
			List<Issue> issuesFixedByDevs = await FetchAllIssues(totalIssues, baseUrl);

			// Return the list of issues
			return issuesFixedByDevs;
		}

		public async Task<List<Issue>> GetIndependentStoryList(DateTime startDate, DateTime endDate, string ProjectKey)
		{
			string baseUrl = UrlManager.url("IndependentStory", startDate, endDate, ProjectKey);

			// Fetch the total number of issues (call the API once to get total count)
			int totalIssues = await FetchTotalIssuesCount(baseUrl);

			// Fetch all issues
			List<Issue> allIssues = await FetchAllIssues(totalIssues, baseUrl);

			// filter and return standalone stories
			return GetStandaloneStories(allIssues);
		}

		public async Task<List<Issue>> GetBugsCreated(DateTime startDate, DateTime endDate, string ProjectKey)
		{
			string baseUrl = UrlManager.url("BugsRaised", startDate, endDate, ProjectKey);

			Console.WriteLine($"Bugs Raised : {baseUrl}");

			int totalIssues = await FetchTotalIssuesCount(baseUrl);

			List<Issue> allIssues = await FetchAllIssues(totalIssues, baseUrl);

			return allIssues;
		}

		public async Task<List<Issue>> GetTechTaskList(DateTime startDate, DateTime endDate, string ProjectKey)
		{
			string baseUrl = UrlManager.url("TechTask", startDate, endDate, ProjectKey);

			int totalIssues = await FetchTotalIssuesCount(baseUrl);

			List<Issue> allIssues = await FetchAllIssues(totalIssues, baseUrl);

			return allIssues;
		}

		List<Issue> GetStandaloneStories(List<Issue> issues)
		{
			var standaloneStories = new List<Issue>();

			foreach (var issue in issues)
			{
				// Check if the issue is a Story and does not have a parent (i.e., it's not part of an Epic)
				if (issue.Fields.IssueType.Name == "Story" && (issue.Fields.Parent) == null)
				{
					standaloneStories.Add(issue);
				}
			}

			return standaloneStories;
		}

		async Task<int> FetchTotalIssuesCount(string baseUrl)
		{
			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("Authorization", $"Basic {Constant.UrlConstant.encodedCredentials}");
				client.DefaultRequestHeaders.Add("Accept", "application/json");

				int batchSize = 100;
				int startAt = 0;

				string totalCountUrl = $"{baseUrl}&startAt={startAt}&maxResults={batchSize}";
				Console.WriteLine(totalCountUrl);

				try
				{
					HttpResponseMessage response = await client.GetAsync(totalCountUrl);
					if (response.IsSuccessStatusCode)
					{
						string responseBody = await response.Content.ReadAsStringAsync();
						RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(responseBody);
						return rootObject.Total;
					}
					else
					{
						Console.WriteLine($"Failed to fetch total issues count. Status Code: {response.StatusCode}");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"An error occurred while fetching total issues count: {ex.Message}");
				}
			}
			return 0;
		}

		// Method to fetch all issues in batches
		async Task<List<Issue>> FetchAllIssues(int totalIssues, string baseUrl)
		{
			List<Issue> allIssues = new List<Issue>();
			int batchSize = 100;
			int startAt = 0;

			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("Authorization", $"Basic {Constant.UrlConstant.encodedCredentials}");
				client.DefaultRequestHeaders.Add("Accept", "application/json");

				int numberOfRequests = (totalIssues + batchSize - 1) / batchSize;

				for (int i = 0; i < numberOfRequests; i++)
				{
					string paginatedUrl = $"{baseUrl}&startAt={startAt}&maxResults={batchSize}";

					try
					{
						HttpResponseMessage response = await client.GetAsync(paginatedUrl);
						if (response.IsSuccessStatusCode)
						{
							string responseBody = await response.Content.ReadAsStringAsync();
							RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(responseBody);

							if (rootObject != null && rootObject.Issues != null)
							{
								allIssues.AddRange(rootObject.Issues);
								startAt += batchSize;
							}
						}
						else
						{
							Console.WriteLine($"Failed to fetch issues. Status Code: {response.StatusCode}");
							break;
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine($"An error occurred: {ex.Message}");
						break;
					}
				}
			}

			return allIssues;
		}

		public async Task<List<EpicList>> GetEpicList(DateTime startDate, DateTime endDate, string projectKey)
		{
			List<EpicList> epicList = await FetchEpicsWithStoriesAsync(startDate, endDate, projectKey);

			var missingSummaryEpics = epicList.Where(e => e.summary == "Epic summary not available").ToList();

			if (missingSummaryEpics.Any())
			{
				// Extract epic keys with missing summaries
				var missingEpicKeys = missingSummaryEpics.Select(e => e.key).ToList();

				// Fetch epic details
				var epicsWithDetails = await FetchEpicDetailsAsync(startDate, endDate, projectKey);

				// Update the dictionary with the fetched summaries
				foreach (var epicWithDetail in epicsWithDetails)
				{
					var epicToUpdate = missingSummaryEpics.FirstOrDefault(e => e.key == epicWithDetail.key);
					if (epicToUpdate != null)
					{
						epicToUpdate.summary = epicWithDetail.summary;
						epicToUpdate.visualizedData = $"{epicToUpdate.key} : {epicToUpdate.summary}";
					}
				}
			}

			return epicList;
		}

		async Task<List<Epic>> FetchEpicDetailsAsync(DateTime startDate, DateTime endDate, string ProjectKey)
		{
			string baseUrl = UrlManager.url("TicketsWorkedUpon", startDate, endDate, ProjectKey);

			// Fetch the total number of issues (call the API once to get total count)
			int totalIssues = await FetchTotalIssuesCount(baseUrl);

			// Fetch the epic issues
			List<Issue> epicIssues = await FetchAllIssues(totalIssues, baseUrl);

			// Convert to list of Epic objects
			return epicIssues.Select(
				issue => new Epic {
					key = issue.Key, 
					summary = issue.Fields.Summary,
					teams = issue.Fields.CustomField_10057?.Select(cf => cf.Value).ToList() ?? new List<string>(),
					visualizedData = $"{issue.Key} : {issue.Fields.Summary}"
				}).ToList();
		}

		async Task<List<EpicList>> FetchEpicsWithStoriesAsync(DateTime startDate, DateTime endDate, string ProjectKey)
		{
			string baseUrl = UrlManager.url("TicketsWorkedUpon", startDate, endDate, ProjectKey);

			// Fetch the total number of issues (call the API once to get total count)
			int totalIssues = await FetchTotalIssuesCount(baseUrl);

			// Fetch all issues
			List<Issue> allIssues = await FetchAllIssues(totalIssues, baseUrl);

			// Group stories by epics
			return GroupStoriesByEpic(allIssues);
		}

		bool IsEpic(Issue issue)
		{
			return issue.Fields.IssueType.Name == "Epic";
		}

		List<EpicList> GroupStoriesByEpic(List<Issue> issues)
		{
			var epicList = new List<EpicList>();
			List<String> EpicKey = new List<string>();
			// First pass: Populate the dictionary with all epics
			foreach (var issue in issues)
			{
				if (issue.Fields.Parent == null && issue.Fields.IssueType.Name == "Epic")
				{
					if(!EpicKey.Contains(issue.Key))
					{
						EpicKey.Add(issue.Key);
						var _epic = new EpicList {
							key = issue.Key,
							summary = issue.Fields.Summary,
							teams = issue.Fields.CustomField_10057?.Select(cf => cf.Value).ToList() ?? new List<string>(),
							visualizedData = $"{issue.Key} : {issue.Fields.Summary}",
							stories = new List<Story>()
						};
						epicList.Add(_epic);
					}
				}
			}

			// Second pass: Process stories and associate them with the corresponding epic
			foreach (var issue in issues)
			{
				if (issue.Fields != null && issue.Fields.Parent != null)
				{
					var parentKey = issue.Fields.Parent.Key;

					// Find the epic by key in the dictionary
					var epic = epicList.FirstOrDefault(e => e.key == parentKey);
					//var epic = epicStoriesDict.Keys.FirstOrDefault(e => e.key == parentKey);

					if (epic != null)
					{
						var story = new Story { 
							key = issue.Key, 
							summary = issue.Fields.Summary,
							teams = issue.Fields.CustomField_10057?.Select(cf => cf.Value).ToList() ?? new List<string>(),
							visualizedData = $"{issue.Key} : {issue.Fields.Summary}"
						};
						epic.stories.Add(story);
					}
					else
					{
						var story = new Story
						{
							key = issue.Key,
							summary = issue.Fields.Summary,
							teams = issue.Fields.CustomField_10057?.Select(cf => cf.Value).ToList() ?? new List<string>(),
							visualizedData = $"{issue.Key} : {issue.Fields.Summary}"
						};
						var newEpic = new EpicList
						{
							key = parentKey,
							summary = "Epic summary not available",
							stories = new List<Story> { story }
						};
						// Add the new epic to the dictionary with the story
						epicList.Add(newEpic);
					}
				}
			}

			return epicList;
		}
	}
}
