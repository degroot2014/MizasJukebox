using JukeboxDiscordClient.Api;
using JukeboxDiscordClient.Api.interfaces;
using JukeboxDiscordClient.ChoiceProvider;
using JukeboxDiscordClient.Domain;
using NetCord.Rest;
using NetCord.Services.ApplicationCommands;
using static JukeboxDiscordClient.Domain.CommonEnum;

namespace JukeboxDiscordClient.Modules
{
    public class DndReferenceModule : ApplicationCommandModule<ApplicationCommandContext>
    {
        private readonly Idnd5eapi _api;

        public DndReferenceModule(Idnd5eapi dndApi)
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
            var messages = DiscordMessageSplitter.Split(retMessage).ToList();

            await ModifyResponseAsync(message => message.WithContent(messages[0]));

            if(messages.Count > 1)
            {
                for(int i = 1; i < messages.Count; i++)
                {
                    await FollowupAsync(new InteractionMessageProperties().WithContent(messages[i]).WithFlags(ephemeral == YesNo.Yes ? NetCord.MessageFlags.Ephemeral : null));
                }
            }
        }

        [SlashCommand("spell", "Gets Spell information for a spell")]
        public async Task GetSpell(
            [SlashCommandParameter(Name = "spell", Description = "Name of Spell")] string spellName,
            [SlashCommandParameter(Name = "show-me", Description = "Show information to only me")] YesNo ephemeral = YesNo.Yes)
        {
            await RespondAsync(InteractionCallback.DeferredMessage(ephemeral == YesNo.Yes ? NetCord.MessageFlags.Ephemeral : null));
            var spell = _api.GetSpell(spellName.ToLower().Replace(' ', '-'));
            if (spell == null)
            {
                await ModifyResponseAsync(message => message.WithContent($"Spell '{spellName}' not found."));
                return;
            }


            var returnMessage = spell.name;
            foreach (var line in spell.desc)
            {
                returnMessage += $"\n{line}";
            }
            if (!string.IsNullOrEmpty(spell.range))
            {
                returnMessage += $"\nRange: {spell.range}";
            }
            if (spell.components.Any())
            {
                returnMessage += $"\nComponents: {(string.Join(", ", spell.components))}";
            }
            if (!string.IsNullOrEmpty(spell.material))
            {
                returnMessage += $"\nMaterials: {spell.material}";
            }
            if (spell.area_of_effect != null)
            {
                returnMessage += $"\nArea of Effect:" +
                           $"\n      Size: {spell.area_of_effect.size}ft" +
                           $"\n      Type: {spell.area_of_effect.type}";
            }
            returnMessage += $"\nRitual: {(spell.ritual ? "Yes" : "No")}";
            if (!string.IsNullOrEmpty(spell.duration))
            {
                returnMessage += $"\nDuration: {spell.duration}";
            }
            returnMessage += $"\nConcentration: {(spell.concentration ? "Yes" : "No")}";
            if (!string.IsNullOrEmpty(spell.casting_time))
            {
                returnMessage += $"\nCasting Time: {spell.casting_time}";
            }
            returnMessage += $"\nLevel: {spell.level}";
            if (spell.damage != null)
            {
                //spell.damage.damage_type
                returnMessage += $"\nDamage Type: {spell.damage.damage_type.name}";
                if (spell.damage.damage_at_character_level != null)
                {
                    returnMessage += $"\nDamage at Character Level:";
                    returnMessage += spell.damage.damage_at_character_level.PrintChart();
                }
                if (spell.damage.damage_at_slot_level != null)
                {
                    returnMessage += $"\nDamage at Slot Level:";
                    returnMessage += spell.damage.damage_at_slot_level.PrintChart();
                }
            }
            if (spell.school != null)
            {
                returnMessage += $"\nSchool: {spell.school.name}";
            }
            if (spell.classes.Any())
            {
                returnMessage += $"\nClasses: {(string.Join(", ", spell.classes.Select(c => c.name)))}";
            }
            if (spell.subclasses.Any())
            {
                returnMessage += $"\nSub Classes: {(string.Join(", ", spell.subclasses.Select(s => s.name)))}";
            }

            await ModifyResponseAsync(message => message.WithContent(returnMessage));
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
