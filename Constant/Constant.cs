using System.Collections.Generic;

namespace jiraApi.Constants
{
	public class Constant
	{
		public static class UrlConstant
		{
			public static string ApiServer { get; } = "https://grapeseed.atlassian.net";
			public static string Email { get; } = "amit.srivastava@grapecity.com";
			public static string BearerToken { get; } = "ATATT3xFfGF0miL90udE4rt7sHSLbLdBQilECl40lbLYYaidAqSIODYAWOBk_ZdHkBXIyblmnPvRq5EhuG-iwZTrWC-24nDWYQF6Cw23MFFGOLAxsVSrruEQCM4tJBOOjnUJjfknb4nkd8tj6QSLbUzxemg1vKO_v_jaLRh9otCnMr49GyPyW0k=73FA85C4";
			public static string encodedCredentials { get; } = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{UrlConstant.Email}:{UrlConstant.BearerToken}"));
		}

		public static Dictionary<string, List<string>> TeamLabelMap { get; } = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
		{
			{ "Common&Content", new List<string> 
			{
				"712020:694e9394-ed3f-4730-9c2e-881eb9c0aacd",
				"712020:41868ac8-c52e-48b2-9b8b-71a6ec7b0fa7", 
				"638efaef9960988ef6c21329",
				"62380ee81c7f6a00704801ee",
				"5e71ea019500480c35a68aa7"
			} },
			{ "GrapeLeaf", new List<string> 
			{
				"712020:e7d76c68-f77a-4127-b8e1-95c04e9d10f6",
				"712020:880d2c34-708e-4669-978b-15502985d55e",
				"712020:651e9159-5578-474d-b9aa-d8302a361bd5",
				"712020:126cb695-5a60-46c0-9ab9-0a7e375a0add",
				"712020:05bd01ca-cb23-4a6b-b4cc-d139fffb3398",
				"62380ee78d8b9c0068b6c9f2",
				"5da58dfe3c95d00c3c648d30"
			} },
			{ "Mobile", new List<string> 
			{
				"712020:f53a97d7-69a6-48cb-a7de-f34ec99adf23",
				"712020:189712e6-abfb-4659-9c94-6248404637ac",
				"62380f4801f8660070b51bc2",
				"6203d21af5d29a0068fb9a3f",
				"62380f47761efb0069cc1c3c",
				"712020:02b6e4ca-cd81-4689-ba96-21db205607ba"
			} }
		};

		public static Dictionary<string, string> QAAccountId { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
		{
			{ "Ruchi Khanduri", "5da58dfe3c95d00c3c648d30" },
			{ "Somya Saluja", "5e71ea019500480c35a68aa7" },
			{ "Varun Maheshwari", "616f9a24702bd0006a640013" },
			{ "Kiran.Kawadkar", "619dd6756d002b006b784cfa" },
			{ "Anjali.Chander", "62380f47761efb0069cc1c3c" },
			{ "Chandan Shukla", "712020:01a6f354-7b42-437f-85d9-fa2c008c4695" },
			{ "Arpit Gupta", "712020:02b6e4ca-cd81-4689-ba96-21db205607ba" },
			{ "Lavanya Gautam", "712020:58fdcb4b-ece2-4e03-a823-ac1c42c641d0" },
			{"Praveen Kumar" , "712020:f53a97d7-69a6-48cb-a7de-f34ec99adf23" },
			{ "Kanika Kamboj", "712020:694e9394-ed3f-4730-9c2e-881eb9c0aacd" },
			{ "Manas Anand", "712020:41868ac8-c52e-48b2-9b8b-71a6ec7b0fa7" },
			{ "indar.rajput", "638efaef9960988ef6c21329" },
			{ "Sagar Bansal", "62380ee81c7f6a00704801ee" },
			{ "Aryan Yadav", "712020:e7d76c68-f77a-4127-b8e1-95c04e9d10f6" },
			{ "Piyush Garg", "712020:880d2c34-708e-4669-978b-15502985d55e" },
			{ "Amit Srivastava", "712020:651e9159-5578-474d-b9aa-d8302a361bd5" },
			{ "Prabhakar Mishra", "712020:126cb695-5a60-46c0-9ab9-0a7e375a0add" },
			{ "Prateek Mittal", "712020:05bd01ca-cb23-4a6b-b4cc-d139fffb3398" },
			{ "Hardik Jain", "62380ee78d8b9c0068b6c9f2" },
			{ "Neeraj", "712020:189712e6-abfb-4659-9c94-6248404637ac" },
			{ "Sagar Monga", "62380f4801f8660070b51bc2" },
			{ "Abhay Singh", "6203d21af5d29a0068fb9a3f" }
		};

		public static Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>
		{
			{ "Content", new List<string> { "Student App", "Talktime", "Student Site", "GS Baby", "GrapeSEED App", "LittleSEED App" } },
			{ "GrapeLeaf", new List<string> { "Account", "Content", "VCS", "Content Changes" } },
			{ "Mobile", new List<string> { "Admin", "Coach", "Material Request", "Notification", "Report", "Parent", "School", "Survey", "Training" } }
		};

		public static string GetTeamForAssignee(string accountId)
		{
			foreach (var team in Constant.TeamLabelMap)
			{
				if (team.Value.Contains(accountId))
				{
					return team.Key;
				}
			}
			return null;
		}
	}
}
