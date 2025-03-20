using System.Collections;
using static jiraApi.UrlManager;

namespace jiraApi
{
	public class UrlManager
	{
		public static class Constants
		{
			public static string ApiServer { get; } = "https://grapeseed.atlassian.net";
		}
		public static class Jql
		{
			public static string AutomationList { get; } = "project%20%3D%20\"{projectKey}\"%0AAND%20labels%20%3D%20Automation%0AAND%20statuscategorychangeddate%20>%3D%20\"{startDate}\"%0AAND%20statuscategorychangeddate%20<%3D%20\"{endDate}\"%0AAND%20status%20NOT%20IN%20%28Draft%2C%20Open%29";
			public static string IndependentStory { get; } = "project%20%3D%20\"{projectKey}\"%20AND%20type%20%3D%20Story%20AND%20resolved%20>%3D%20\"{startDate}\"%20AND%20resolved%20<%3D%20\"{endDate}\"%0AORDER%20BY%20created%20DESC";
			public static string BugsDelivered { get; } = "project%20%3D%20\"{projectKey}\"%0AAND%20type%20%3D%20Bug%0AAND%20resolved%20>%3D%20\"{startDate}\"%0AAND%20resolved%20<%3D%20\"{endDate}\"%0AAND%20status%20IN%20%28Done%2C%20Resolved%2C%20Closed%29%0AORDER%20BY%20created%20DESC";
			public static string BugsRaised { get; } = "project%20%3D%20\"{projectKey}\"%20AND%20type%20%3D%20Bug%20AND%20created%20>%3D%20\"{startDate}\"%20AND%20created%20<%3D%20\"{endDate}\"";
			public static string TechTask { get; } = "project%20%3D%20\"{projectKey}\"%20AND%20type%20%3D%20\"Technical%20Task\"%20AND%20created%20>%3D%20\"{startDate}\"%20AND%20created%20<%3D%20\"{endDate}\"%0AORDER%20BY%20created%20DESC";
			public static string EpicList { get; } = "project%20%3D%20\"{projectKey}\"%20AND%20type%20%3D%20Epic%20AND%20status%20%21%3D%20Draft";
			public static string EpicWithStory { get; } = "project%20%3D%20\"{projectKey}\"%0AAND%20type%20IN%20%28Epic%2C%20Story%29%0AAND%20status%20%21%3D%20Draft%0AAND%20statuscategorychangeddate%20>%3D%20\"{startDate}\"%0AAND%20statuscategorychangeddate%20<%3D%20\"{endDate}\"\r\n";
			public static string TicketWorkedUpon { get; } = "project%20%3D%20\"{projectKey}\"%20AND%0A%28%0A%28worklogDate%20>%3D%20\"{startDate}\"%20AND%20worklogDate%20<%3D%20\"{endDate}\"%29%20OR%20%28updated%20>%3D%20\"{startDate}\"%20AND%20updated%20<%3D%20\"{endDate}\"%29%0A%29AND%0Aissuetype%20IN%20%28Story%2C%20Improvement%2C%20Epic%29%20AND%20status%20NOT%20IN%20%28Draft%29%0AORDER%20BY%20assignee%20DESC";
			public static string TicketsDelivered { get; } = "project%20%3D%20\"{projectKey}\"%20AND%20status%20changed%20to%20resolved%20during%20%28\"{startDate}\"%2C\"{endDate}\"%29%20AND%0Aissuetype%20IN%20%28Story%2C%20Improvement%2C%20Epic%29%20ORDER%20BY%20cf%5B10057%5D%20ASC%2C%20assignee%20DESC";

		}
		public static string url(string functionType, DateTime startDate, DateTime endDate, string projectKey) 
		{
			string startDateString = startDate.ToString("yyyy-MM-dd");
			string endDateString = endDate.ToString("yyyy-MM-dd");

			string JqlTemplate = JqlFetch(functionType);
			string Jql = JqlTemplate.Replace("{projectKey}", projectKey).Replace("{startDate}", startDateString).Replace("{endDate}", endDateString);

			string baseUrl = $"{Constants.ApiServer}/rest/api/3/search?jql={Jql}";
			return baseUrl;
		}

		public static string JqlFetch(string functionType)
		{
			switch (functionType)
			{
				case "Automation":
					return Jql.AutomationList;
				case "IndependentStory":
					return Jql.IndependentStory;
				case "BugsDelivered":
					return Jql.BugsDelivered;
				case "BugsRaised":
					return Jql.BugsRaised;
				case "TechTask":
					return Jql.TechTask;
				case "EpicList":
					return Jql.EpicList;
				case "EpicWithStory":
					return Jql.EpicWithStory;
				case "TicketWorkedUpon":
					return Jql.TicketWorkedUpon;
				case "TicketsDelivered":
					return Jql.TicketsDelivered;
				default:
					return "";
			}
		}
	}
}
