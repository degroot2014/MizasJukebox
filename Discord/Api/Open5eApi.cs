using RestSharp;
namespace JukeboxDiscordClient.Api
{
    

    public class Open5eApi
    {
        private const string _url = "https://api.open5e.com/";

        public Open5eApi()
        {

        }

        public IList<Result> GetConditions()
        {
            return CallApi("conditions").results;
        }

        public Result GetCondition(string name)
        {
            return CallApiResult($"conditions/{name}");
        }

        private Root CallApi(string command)
        {
            var client = new RestClient(_url);
            var request = new RestRequest(command) { };

            var response = client.Execute<Root>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                return new Root();
            }
        }

        private Result CallApiResult(string command)
        {
            var client = new RestClient(_url);
            var request = new RestRequest(command) { };

            var response = client.Execute<Result>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                return new Result();
            }
        }
    }
}
