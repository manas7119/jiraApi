namespace jiraApi.Model.ResponseModel
{
    public class EpicList
    {
        public string key { get; set; }
        public string summary { get; set; }
		public List<string> teams { get; set; }
		public string visualizedData { get; set; }
        public List<Story> stories { get; set; }
    }
}
