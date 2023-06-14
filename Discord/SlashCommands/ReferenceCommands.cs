using Discord.WebSocket;
using JukeboxDiscordClient.Api;

namespace JukeboxDiscordClient.SlashCommands
{
    public class ReferenceCommands
    {
        private dnd5eapi _api;

        public ReferenceCommands()
        {
            _api = new dnd5eapi();
        }

        public IList<Result> GetConditions()
        {
            return _api.GetConditions();
        }

        public async Task GetCondition(SocketSlashCommand command)
        {
            var name = (string)command.Data.Options.First(o => o.Name == "condition").Value;
            var condition = _api.GetCondition(name);

            var message = $"{condition.name}";
            foreach (var line in condition.desc)
            {
                message += $"\n{line}";
            }
            await command.RespondAsync(message);
        }

        public async Task GetSpellList(SocketSlashCommand command)
        {
            var className = (string)command.Data.Options.First(o => o.Name == "class").Value;
            var spellList = _api.GetSpellList(className);

            var message = $"Spell List for {className}";
            foreach (var spell in spellList)
            {
                message += $"\n{spell.name}";
            }
            await command.RespondAsync(message, ephemeral: true);
        }

        public async Task GetSpell(SocketSlashCommand command)
        {
            var spellName = (string)command.Data.Options.First(o => o.Name == "spell").Value;
            var spell = _api.GetSpell(spellName.ToLower().Replace(' ', '-'));

            if (spell == null)
            {
                await command.RespondAsync($"No spell found with name {spellName}");
            }

            var message = spell.name;
            foreach (var line in spell.desc)
            {
                message += $"\n{line}";
            }
            if (!string.IsNullOrEmpty(spell.range))
            {
                message += $"\nRange: {spell.range}";
            }
            if (spell.components.Any())
            {
                message += $"\nComponents: {(string.Join(", ", spell.components))}";
            }
            if (!string.IsNullOrEmpty(spell.material))
            {
                message += $"\nMaterials: {spell.material}";
            }
            if (spell.area_of_effect != null)
            {
                message += $"\nArea of Effect:" +
                           $"\n      Size: {spell.area_of_effect.size}ft" +
                           $"\n      Type: {spell.area_of_effect.type}";
            }
            message += $"\nRitual: {(spell.ritual ? "Yes" : "No")}";
            if (!string.IsNullOrEmpty(spell.duration))
            {
                message += $"\nDuration: {spell.duration}";
            }
            message += $"\nConcentration: {(spell.concentration ? "Yes" : "No")}";
            if (!string.IsNullOrEmpty(spell.casting_time))
            {
                message += $"\nCasting Time: {spell.casting_time}";
            }
            message += $"\nLevel: {spell.level}";
            if (spell.damage != null)
            {
                //spell.damage.damage_type
                message += $"\nDamage Type: {spell.damage.damage_type.name}";
                if (spell.damage.damage_at_character_level != null)
                {
                    message += $"\nDamage at Character Level:";
                    message += spell.damage.damage_at_character_level.PrintChart();
                }
                if (spell.damage.damage_at_slot_level != null)
                {
                    message += $"\nDamage at Slot Level:";
                    message += spell.damage.damage_at_slot_level.PrintChart();
                }
            }
            if (spell.school != null)
            {
                message += $"\nSchool: {spell.school.name}";
            }
            if (spell.classes.Any())
            {
                message += $"\nClasses: {(string.Join(", ", spell.classes.Select(c => c.name)))}";
            }
            if (spell.subclasses.Any())
            {
                message += $"\nSub Classes: {(string.Join(", ", spell.subclasses.Select(s => s.name)))}";
            }

            await command.RespondAsync(message);
        }

        public IList<Result> Test()
        {
            return _api.GetConditions();
            //return _api.GetCondition("exhaustion");
            //return _api.GetSpellList("sorcerer");
        }
    }
}
