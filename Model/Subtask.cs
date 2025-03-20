namespace jiraApi.Model
{
	public class Subtask
	{
		public string Id { get; set; }
		public string Key { get; set; }
		public virtual Fields Fields { get; set; }
	}
}
