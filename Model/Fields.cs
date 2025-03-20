namespace jiraApi.Model
{
	public class Fields
	{
		public DateTime? StatusCategoryChangeDate { get; set; }
		public virtual Parent Parent { get; set; }
		public virtual List<FixVersion> FixVersions { get; set; }
		public virtual Resolution Resolution { get; set; }
		public object LastViewed { get; set; }
		public virtual List<string> Labels { get; set; }
		public virtual List<object> IssueLinks { get; set; }
		public virtual User? Assignee { get; set; }
		public virtual Status? Status { get; set; }
		public virtual List<CustomField_10057> CustomField_10057 { get; set; }
		public virtual User Creator { get; set; }
		public virtual List<Subtask> Subtasks { get; set; }
		public virtual User? Reporter { get; set; }
		public virtual IssueType IssueType { get; set; }
		public virtual Project Project { get; set; }
		public DateTime? ResolutionDate { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Updated { get; set; }
		public string CustomField10013 { get; set; }
		public string Summary { get; set; }
	}
}
