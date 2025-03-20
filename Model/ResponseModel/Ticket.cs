namespace jiraApi.Model.ResponseModel
{
	public class Ticket
	{
		public string key { get; set; }
		public string summary { get; set; }
		public List<string> teams { get; set; }
		public string visualizedData { get; set; }  //  (Key : Summary)
        public string type { get; set; }
        public string status { get; set; }
    }
}
