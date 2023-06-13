using System.Text.Json.Serialization;

namespace JukeboxDiscordClient.Api
{
    public class Root
    {
        public int count { get; set; }
        public List<Result> results { get; set; }
    }

    public class Result
    {
        public string index { get; set; }
        public string name { get; set; }
        public List<string> desc { get; set; }
        public string url { get; set; }
        public List<string> higher_level { get; set; }
        public string range { get; set; }
        public List<string> components { get; set; }
        public string material { get; set; }
        public AreaOfEffect area_of_effect { get; set; }
        public bool ritual { get; set; }
        public string duration { get; set; }
        public bool concentration { get; set; }
        public string casting_time { get; set; }
        public int level { get; set; }
        public string attack_type { get; set; }
        public Damage damage { get; set; }
        public Dc dc { get; set; }
        public School school { get; set; }
        public List<Class> classes { get; set; }
        public List<Subclass> subclasses { get; set; }
    }

    public class Damage
    {
        public DamageType damage_type { get; set; }
        public DamageAtCharacterLevel damage_at_character_level { get; set; }
        public DamageAtSlotLevel damage_at_slot_level { get; set; }
    }

    public class DamageAtCharacterLevel
    {
        [JsonPropertyName("1")]
        public string level1 { get; set; }
        [JsonPropertyName("2")]
        public string level2 { get; set; }
        [JsonPropertyName("3")]
        public string level3 { get; set; }
        [JsonPropertyName("4")]
        public string level4 { get; set; }
        [JsonPropertyName("5")]
        public string level5 { get; set; }
        [JsonPropertyName("6")]
        public string level6 { get; set; }
        [JsonPropertyName("7")]
        public string level7 { get; set; }
        [JsonPropertyName("8")]
        public string level8 { get; set; }
        [JsonPropertyName("9")]
        public string level9 { get; set; }
        [JsonPropertyName("10")]
        public string level10 { get; set; }
        [JsonPropertyName("11")]
        public string level11 { get; set; }
        [JsonPropertyName("12")]
        public string level12 { get; set; }
        [JsonPropertyName("13")]
        public string level13 { get; set; }
        [JsonPropertyName("14")]
        public string level14 { get; set; }
        [JsonPropertyName("15")]
        public string level15 { get; set; }
        [JsonPropertyName("16")]
        public string level16 { get; set; }
        [JsonPropertyName("17")]
        public string level17 { get; set; }
        [JsonPropertyName("18")]
        public string level18 { get; set; }
        [JsonPropertyName("19")]
        public string level19 { get; set; }
        [JsonPropertyName("20")]
        public string level20 { get; set; }

        public string PrintChart()
        {
            var message = "";
            if (level1 != null)
            {
                message += $"\n      Level 1: {level1}";
            }
            if (level2 != null)
            {
                message += $"\n      Level 2: {level2}";
            }
            if (level3 != null)
            {
                message += $"\n      Level 3: {level3}";
            }
            if (level4 != null)
            {
                message += $"\n      Level 4: {level4}";
            }
            if (level5 != null)
            {
                message += $"\n      Level 5: {level5}";
            }
            if (level6 != null)
            {
                message += $"\n      Level 6: {level6}";
            }
            if (level7 != null)
            {
                message += $"\n      Level 7: {level7}";
            }
            if (level8 != null)
            {
                message += $"\n      Level 8: {level8}";
            }
            if (level9 != null)
            {
                message += $"\n      Level 9: {level9}";
            }
            if (level10 != null)
            {
                message += $"\n      Level 10: {level10}";
            }
            if (level11 != null)
            {
                message += $"\n      Level 11: {level11}";
            }
            if (level12 != null)
            {
                message += $"\n      Level 12: {level12}";
            }
            if (level13 != null)
            {
                message += $"\n      Level 13: {level13}";
            }
            if (level14 != null)
            {
                message += $"\n      Level 14: {level14}";
            }
            if (level15 != null)
            {
                message += $"\n      Level 15: {level15}";
            }
            if (level16 != null)
            {
                message += $"\n      Level 16: {level16}";
            }
            if (level17 != null)
            {
                message += $"\n      Level 17: {level17}";
            }
            if (level18 != null)
            {
                message += $"\n      Level 18: {level18}";
            }
            if (level19 != null)
            {
                message += $"\n      Level 19: {level19}";
            }
            if (level20 != null)
            {
                message += $"\n      Level 20: {level20}";
            }
            return message;
        }

    }

    public class DamageAtSlotLevel
    {
        [JsonPropertyName("1")]
        public string slot1 { get; set; }
        [JsonPropertyName("2")]
        public string slot2 { get; set; }
        [JsonPropertyName("3")]
        public string slot3 { get; set; }
        [JsonPropertyName("4")]
        public string slot4 { get; set; }
        [JsonPropertyName("5")]
        public string slot5 { get; set; }
        [JsonPropertyName("6")]
        public string slot6 { get; set; }
        [JsonPropertyName("7")]
        public string slot7 { get; set; }
        [JsonPropertyName("8")]
        public string slot8 { get; set; }
        [JsonPropertyName("9")]
        public string slot9 { get; set; }

        public string PrintChart()
        {
            var message = "";
            if (slot1 != null)
            {
                message += $"\n      Slot 1: {slot1}";
            }
            if (slot2 != null)
            {
                message += $"\n      Slot 2: {slot2}";
            }
            if (slot3 != null)
            {
                message += $"\n      Slot 3: {slot3}";
            }
            if (slot4 != null)
            {
                message += $"\n      Slot 4: {slot4}";
            }
            if (slot5 != null)
            {
                message += $"\n      Slot 5: {slot5}";
            }
            if (slot6 != null)
            {
                message += $"\n      Slot 6: {slot6}";
            }
            if (slot7 != null)
            {
                message += $"\n      Slot 7: {slot7}";
            }
            if (slot8 != null)
            {
                message += $"\n      Slot 8: {slot8}";
            }
            if (slot9 != null)
            {
                message += $"\n      Slot 9: {slot9}";
            }
            return message;
        }
    }

    public class DamageType
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Dc
    {
        public DcType dc_type { get; set; }
        public string dc_success { get; set; }
    }

    public class DcType
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class School
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Subclass
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Class
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class AreaOfEffect
    {
        public int size { get; set; }
        public string type { get; set; }
    }
}
