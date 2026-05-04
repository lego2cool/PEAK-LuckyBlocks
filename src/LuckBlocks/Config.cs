using BepInEx.Configuration;

namespace LuckyBlocks;

public static class Config
{
    public static ConfigFile Instance;

    // Config entries for built-in outcomes
    public static ConfigEntry<bool> TornadoEnabled;
    public static ConfigEntry<int> TornadoWeight;
    public static ConfigEntry<bool> LuggageEnabled;
    public static ConfigEntry<int> LuggageWeight;
    public static ConfigEntry<bool> BounceEnabled;
    public static ConfigEntry<int> BounceWeight;
    public static ConfigEntry<bool> ShelfEnabled;
    public static ConfigEntry<int> ShelfWeight;
    public static ConfigEntry<bool> LuckyRainEnabled;
    public static ConfigEntry<int> LuckyRainWeight;
    public static ConfigEntry<bool> EruptionEnabled;
    public static ConfigEntry<int> EruptionWeight;
    public static ConfigEntry<bool> PeelRainEnabled;
    public static ConfigEntry<int> PeelRainWeight;
    public static ConfigEntry<bool> ExplodeEnabled;
    public static ConfigEntry<int> ExplodeWeight;
    public static ConfigEntry<bool> ScorpoRainEnabled;
    public static ConfigEntry<int> ScorpoRainWeight;
    public static ConfigEntry<bool> BerryRainEnabled;
    public static ConfigEntry<int> BerryRainWeight;
    public static ConfigEntry<bool> SummonScoutmasterEnabled;
    public static ConfigEntry<int> SummonScoutmasterWeight;
    public static ConfigEntry<bool> RopeSpawnEnabled;
    public static ConfigEntry<int> RopeSpawnWeight;
    public static ConfigEntry<bool> ChaosCloudEnabled;
    public static ConfigEntry<int> ChaosCloudWeight;
    public static ConfigEntry<bool> ZombieEnabled;
    public static ConfigEntry<int> ZombieWeight;
    public static ConfigEntry<bool> BackpacksEnabled;
    public static ConfigEntry<int> BackpacksWeight;
    public static ConfigEntry<bool> PuffHealSpawnEnabled;
    public static ConfigEntry<int> PuffHealSpawnWeight;
    public static ConfigEntry<bool> EquipmentShowerEnabled;
    public static ConfigEntry<int> EquipmentShowerWeight;
    public static ConfigEntry<bool> MythicSpawnEnabled;
    public static ConfigEntry<int> MythicSpawnWeight;
    public static ConfigEntry<bool> FlagEnabled;
    public static ConfigEntry<int> FlagWeight;
    public static ConfigEntry<bool> CannonEnabled;
    public static ConfigEntry<int> CannonWeight;
    public static ConfigEntry<bool> CookEnabled;
    public static ConfigEntry<int> CookWeight;
    public static ConfigEntry<bool> SunscreenEnabled;
    public static ConfigEntry<int> SunscreenWeight;
    public static ConfigEntry<bool> EnderpearlEnabled;
    public static ConfigEntry<int> EnderpearlWeight;

    public static void BindAll()
    {
        TornadoEnabled = Instance.Bind("Outcomes", "Spawn Tornado Enabled", true, "Enable Spawn Tornado outcome");
        TornadoWeight = Instance.Bind("Outcomes", "Spawn Tornado Weight", 80, "Weight for Spawn Tornado");
        LuggageEnabled = Instance.Bind("Outcomes", "Spawn Luggage Enabled", true, "Enable Spawn Luggage outcome");
        LuggageWeight = Instance.Bind("Outcomes", "Spawn Luggage Weight", 110, "Weight for Spawn Luggage");
        BounceEnabled = Instance.Bind("Outcomes", "Spawn Bounce Shroom Enabled", true, "Enable Spawn Bounce Shroom outcome");
        BounceWeight = Instance.Bind("Outcomes", "Spawn Bounce Shroom Weight", 100, "Weight for Spawn Bounce Shroom");
        ShelfEnabled = Instance.Bind("Outcomes", "Spawn Shelf Fungus Enabled", true, "Enable Spawn Shelf Fungus outcome");
        ShelfWeight = Instance.Bind("Outcomes", "Spawn Shelf Fungus Weight", 90, "Weight for Spawn Shelf Fungus");
        LuckyRainEnabled = Instance.Bind("Outcomes", "Lucky Block Rain Enabled", true, "Enable Lucky Block Rain outcome");
        LuckyRainWeight = Instance.Bind("Outcomes", "Lucky Block Rain Weight", 75, "Weight for Lucky Block Rain");
        EruptionEnabled = Instance.Bind("Outcomes", "Spawn Eruption Enabled", true, "Enable Spawn Eruption outcome");
        EruptionWeight = Instance.Bind("Outcomes", "Spawn Eruption Weight", 90, "Weight for Spawn Eruption");
        PeelRainEnabled = Instance.Bind("Outcomes", "Berrynana Peel Rain Enabled", true, "Enable Berrynana Peel Rain outcome");
        PeelRainWeight = Instance.Bind("Outcomes", "Berrynana Peel Rain Weight", 100, "Weight for Berrynana Peel Rain");
        ExplodeEnabled = Instance.Bind("Outcomes", "Explosion Enabled", true, "Enable Explosion outcome");
        ExplodeWeight = Instance.Bind("Outcomes", "Explosion Weight", 80, "Weight for Explosion");
        ScorpoRainEnabled = Instance.Bind("Outcomes", "Scorpion Rain Enabled", true, "Enable Scorpion Rain outcome");
        ScorpoRainWeight = Instance.Bind("Outcomes", "Scorpion Rain Weight", 60, "Weight for Scorpion Rain");
        BerryRainEnabled = Instance.Bind("Outcomes", "Berry Rain Enabled", true, "Enable Berry Rain outcome");
        BerryRainWeight = Instance.Bind("Outcomes", "Berry Rain Weight", 100, "Weight for Berry Rain");
        SummonScoutmasterEnabled = Instance.Bind("Outcomes", "Spawn Scoutmaster Enabled", true, "Enable Spawn Scoutmaster outcome");
        SummonScoutmasterWeight = Instance.Bind("Outcomes", "Spawn Scoutmaster Weight", 50, "Weight for Spawn Scoutmaster");
        RopeSpawnEnabled = Instance.Bind("Outcomes", "Rope/Anti Rope Spawn Enabled", true, "Enable Rope/Anti Rope Spawn outcome");
        RopeSpawnWeight = Instance.Bind("Outcomes", "Rope/Anti Rope Spawn Weight", 95, "Weight for Rope/Anti Rope Spawn");
        ChaosCloudEnabled = Instance.Bind("Outcomes", "Chaos Cloud Enabled", true, "Enable Chaos Cloud outcome");
        ChaosCloudWeight = Instance.Bind("Outcomes", "Chaos Cloud Weight", 100, "Weight for Chaos Cloud");
        ZombieEnabled = Instance.Bind("Outcomes", "Spawn Zombie Enabled", true, "Enable Spawn Zombie outcome");
        ZombieWeight = Instance.Bind("Outcomes", "Spawn Zombie Weight", 70, "Weight for Spawn Zombie");
        BackpacksEnabled = Instance.Bind("Outcomes", "Backpack Spawn Enabled", true, "Enable Backpack Spawn outcome");
        BackpacksWeight = Instance.Bind("Outcomes", "Backpack Spawn Weight", 90, "Weight for Backpack Spawn");
        PuffHealSpawnEnabled = Instance.Bind("Outcomes", "Remed Fungus Heal Spawn Enabled", true, "Enable Remed Fungus Heal Spawn outcome");
        PuffHealSpawnWeight = Instance.Bind("Outcomes", "Remed Fungus Heal Spawn Weight", 100, "Weight for Remed Fungus Heal Spawn");
        EquipmentShowerEnabled = Instance.Bind("Outcomes", "Equipment Shower Enabled", true, "Enable Equipment Shower outcome");
        EquipmentShowerWeight = Instance.Bind("Outcomes", "Equipment Shower Weight", 100, "Weight for Equipment Shower");
        MythicSpawnEnabled = Instance.Bind("Outcomes", "Mythic Item Spawn Enabled", true, "Enable Mythic Item Spawn outcome");
        MythicSpawnWeight = Instance.Bind("Outcomes", "Mythic Item Spawn Weight", 85, "Weight for Mythic Item Spawn");
        FlagEnabled = Instance.Bind("Outcomes", "Checkpoint Flag Enabled", true, "Enable Checkpoint Flag outcome");
        FlagWeight = Instance.Bind("Outcomes", "Checkpoint Flag Weight", 90, "Weight for Checkpoint Flag");
        CannonEnabled = Instance.Bind("Outcomes", "Scout Cannon Spawn Enabled", true, "Enable Scout Cannon outcome");
        CannonWeight = Instance.Bind("Outcomes", "Scout Cannon Spawn Weight", 95, "Weight for Scout Cannon");
        CookEnabled = Instance.Bind("Outcomes", "Portable Pot Spawn Enabled", true, "Enable Portable Pot Spawn outcome");
        CookWeight = Instance.Bind("Outcomes", "Portable Pot Spawn Weight", 85, "Weight for Portable Pot Spawn");
        SunscreenEnabled = Instance.Bind("Outcomes", "Sunscreen Area Enabled", true, "Enable Sunscreen area outcome");
        SunscreenWeight = Instance.Bind("Outcomes", "Sunscreen Area Weight", 65, "Weight for Sunscreen area");
        EnderpearlEnabled = Instance.Bind("Outcomes", "Teleport Enabled", true, "Enable Teleport outcome");
        EnderpearlWeight = Instance.Bind("Outcomes", "Teleport Weight", 80, "Weight for Teleport");
    }
}