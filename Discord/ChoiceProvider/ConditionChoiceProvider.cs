using NetCord.Rest;
using NetCord.Services.ApplicationCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JukeboxDiscordClient.ChoiceProvider
{
    public class ConditionChoiceProvider : IChoicesProvider<ApplicationCommandContext>
    {

        public ValueTask<IEnumerable<ApplicationCommandOptionChoiceProperties>?> GetChoicesAsync(SlashCommandParameter<ApplicationCommandContext> parameter)
        {
            var api = new Api.dnd5eapi();
            var conditions = api.GetConditions();
            var choices = conditions.Select(c => new ApplicationCommandOptionChoiceProperties(c.name, c.index));
            return new ValueTask<IEnumerable<ApplicationCommandOptionChoiceProperties>?>(choices);
        }
    }
}
