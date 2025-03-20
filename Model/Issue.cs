namespace jiraApi.Model
{
	public class Issue
	{
		public string Id { get; set; }
		public string Key { get; set; }
		public virtual Fields Fields { get; set; }
	}
}
