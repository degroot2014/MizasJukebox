using JukeboxDiscordClient.Api;
using JukeboxDiscordClient.ChoiceProvider;
using NetCord.Rest;
using NetCord.Services.ApplicationCommands;
using static JukeboxDiscordClient.Domain.CommonEnum;

namespace JukeboxDiscordClient.Modules
{
    public class DDReferenceModule : ApplicationCommandModule<ApplicationCommandContext>
    {
        private dnd5eapi _api;

        public DDReferenceModule(dnd5eapi dndApi)
        {
            _api = dndApi;
        }

        [SlashCommand("condition", "Get Condition information")]
        public InteractionMessageProperties Condition(
            [SlashCommandParameter(Name = "condition", Description = "Condition to get more information about", ChoicesProviderType = typeof(ConditionChoiceProvider))] string conditionName,
            [SlashCommandParameter(Name = "show-me", Description = "Show information to only me")] YesNo ephemeral = YesNo.No)
        {
            var condition = _api.GetCondition(conditionName);

            var message = $"{condition.name}";
            foreach (var line in condition.desc)
            {
                message += $"\n{line}";
            }
            var props = new InteractionMessageProperties().WithContent(message);
            if (ephemeral == YesNo.Yes)
            {
                props.WithFlags(NetCord.MessageFlags.Ephemeral);
            }
            return props;

        }

        [SlashCommand("spell-list", "Retrieves list of spells for selected Class")]
        public async Task GetSpellList(
            [SlashCommandParameter(Name = "class", Description = "Class wanted for Spells")] DDReferenceEnums.Class className,
            [SlashCommandParameter(Name = "show-me", Description = "Show information to only me")] YesNo ephemeral = YesNo.Yes)
        {
            await RespondAsync(InteractionCallback.DeferredMessage(ephemeral == YesNo.Yes ? NetCord.MessageFlags.Ephemeral : null));

            var spellList = _api.GetSpellList(className.ToString().ToLower());
            var levels = spellList.Select(s => s.level).Distinct().OrderBy(i => i).ToList();
            var retMessage = $"Spell List for {className}";
            foreach (var level in levels)
            {
                retMessage += $"\n-Level {level} Spells-";
                foreach (var spell in spellList.Where(s => s.level == level).OrderBy(s => s.name))
                {
                    retMessage += $"\n   {spell.name}";
                }
            }

            await ModifyResponseAsync(message => message.WithContent(retMessage));
        }
    }

    public class DDReferenceEnums
    {
        public enum Class
        {
            Bard,
            Cleric,
            Druid,
            Paladin,
            Ranger,
            Sorcerer,
            Warlock,
            Wizard
        }
    }
}
