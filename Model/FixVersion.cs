using System;

namespace jiraApi.Model
{
	public class FixVersion
	{
		public string Description { get; set; }
		public string Name { get; set; }
		public bool Archived { get; set; }
		public bool Released { get; set; }
		public DateTime ReleaseDate { get; set; }
	}
}
