namespace jiraApi.Model
{
	public class ParentFields
	{
		public string Summary { get; set; }
		public virtual Status Status { get; set; }
		public virtual IssueType IssueType { get; set; }
	}
}
