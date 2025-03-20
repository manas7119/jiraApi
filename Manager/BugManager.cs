//using jiraApi.Model;

//namespace jiraApi.Manager
//{
//	public class BugManager
//	{
//		void GenerateBugReport(List<Issue> issues)
//		{
//			var categorizedIssues = CategorizeIssues(issues, TeamLabelMap);

//			foreach (var category in categorizedIssues)
//			{
//				Console.WriteLine($"\nTeam: {category.Key}");

//				var bugs = category.Value
//					.Where(issue => issue.fields.issuetype.name.Equals("Bug", StringComparison.OrdinalIgnoreCase) &&
//									(issue.fields.status.name.Equals("Resolved", StringComparison.OrdinalIgnoreCase) ||
//									 issue.fields.status.name.Equals("Closed", StringComparison.OrdinalIgnoreCase)))
//					.ToList();

//				Console.WriteLine($"  Number of Resolved or Closed Bugs: {bugs.Count}");

//				foreach (var bug in bugs)
//				{
//					Console.WriteLine($"    Bug ID: {bug.key}");
//				}
//			}
//		}

//		void GenerateBugsFixedByDevsReport(List<Issue> issues)
//		{
//			var qaIssues = issues
//				.Where(issue => issue.fields != null &&
//								issue.fields.assignee != null &&
//								issue.fields.status != null &&
//								QaAccountIds.ContainsValue(issue.fields.assignee.accountId) &&
//								(issue.fields.status.name.Equals("closed", StringComparison.OrdinalIgnoreCase) ||
//								 issue.fields.status.name.Equals("resolved", StringComparison.OrdinalIgnoreCase)))
//				.ToList();

//			Console.WriteLine("Generating QA Bug Report...");
//			Console.WriteLine($"Total Issues Fixed by QA: {qaIssues.Count}");

//			foreach (var issue in qaIssues)
//			{
//				Console.WriteLine($"Issue Key: {issue.key}, Assignee: {issue.fields.assignee.displayName}, Status: {issue.fields.status.name}");
//			}
//		}

//		void GenerateBugsRaisedByQAReport(List<Issue> issues)
//		{
//			var nonDraftStatuses = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
//			{
//				"Open", "In Progress", "Resolved", "Under Resolution", "Waiting for Resolution", "Waiting for Verification"
//			};

//			var qaIssues = issues
//				.Where(issue => QaAccountIds.ContainsValue(issue.fields.reporter.accountId) &&
//								nonDraftStatuses.Contains(issue.fields.status.name))
//				.ToList();

//			Console.WriteLine("Generating Bugs Raised by QA Report...");
//			Console.WriteLine($"Total Bugs Raised by QA: {qaIssues.Count}");

//			foreach (var issue in qaIssues)
//			{
//				Console.WriteLine($"Issue ID: {issue.key}");
//			}
//		}
//	}
//}
