using RestSharp;

namespace JukeboxDiscordClient.Api
{
    public class dnd5eapi
    {
        private const string _url = "https://www.dnd5eapi.co/api/";

        public dnd5eapi()
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

        public IList<Result> GetSpellList(string className)
        {
            return CallApi($"classes/{className}/spells").results;
        }

        public Result GetSpell(string name)
        {
            return CallApiResult($"spells/{name}");
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
