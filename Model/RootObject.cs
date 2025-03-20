namespace jiraApi.Model
{
	public class RootObject
	{
		public int Total { get; set; }
		public virtual List<Issue> Issues { get; set; }
	}
}
