namespace PokeGotchi.Utils
{
    public static class JsonValidator
    {

        // Validate if the file content is valid JSON
        public static bool IsValidJson(string fileContent)
        {
            try
            {
                // Try to parse the file content as a JsonDocument
                using (System.Text.Json.JsonDocument.Parse(fileContent))
                {
                    return true;
                }
            }
            catch (System.Text.Json.JsonException)
            {
                return false;
            }
        }

        public static bool ValidateSaveData(SaveData saveData)
        {
            // check if properties in SaveData are present
            return saveData.PartnerPokemon != null &&
                   !string.IsNullOrWhiteSpace(saveData.PartnerPokemon.Name) &&
                   saveData.PartnerPokemon.Stats != null &&
                   saveData.PartnerPokemon.Stats.ContainsKey("Happiness") &&
                   saveData.PartnerPokemon.Stats.ContainsKey("Friendship") &&
                   saveData.PartnerPokemon.Stats.ContainsKey("Hunger");
        }
    }
}
