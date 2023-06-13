namespace JukeboxDiscordClient.Api
{
    public class Result
    {
        public string slug { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string document__slug { get; set; }
        public string document__title { get; set; }
        public string document__url { get; set; }
    }

    public class Root
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
    }
}
