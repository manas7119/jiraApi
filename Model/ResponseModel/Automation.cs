namespace jiraApi.Model.ResponseModel
{
    public class Automation
    {
        public string key { get; set; }
        public string summary { get; set; }
		public List<string> teams { get; set; }    // we can make this as enum just as we have in our admin services.
		public string visualizedData { get; set; }
    }
}
