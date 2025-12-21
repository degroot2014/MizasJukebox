using JukeboxDiscordClient.Api.interfaces;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;

namespace JukeboxDiscordClient.Api
{
    public class dnd5eapi : Idnd5eapi
    {
        private const string _url = "https://www.dnd5eapi.co/api/";
        private IMemoryCache _spells;

        public dnd5eapi() 
        {
            var options = new MemoryCacheOptions();
            _spells = new MemoryCache(options);
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
            var spells = CallApi($"classes/{className}/spells").results;
            var fullSpells = new List<Result>();
            foreach(var spell in spells)
            {
                fullSpells.Add(GetSpell(spell.index));
            }
            return fullSpells;
        }

        public Result GetSpell(string name)
        {
            if(_spells.TryGetValue(name, out Result result))
            {
                return result;
            }
            var spell = CallApiResult($"spells/{name}");
            _spells.Set(spell.index, spell);
            return spell;
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
