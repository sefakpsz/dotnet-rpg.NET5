using System.Text.Json.Serialization;

namespace dotnet_rpg.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]        // With help of that we can see the inside of number of enums like; Cleric instead of "3".
    public enum RpgClass
    {
        Knigth,
        Mage,
        Cleric
    }
}