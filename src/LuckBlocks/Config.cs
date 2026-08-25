using BepInEx.Configuration;

namespace LuckyBlocks;

public static class Config
{
    public static ConfigFile Instance = null!;

    //Debug Config
    public static ConfigEntry<bool> DebugMode = null!;
    public static ConfigEntry<string> ForcedOutcome = null!;    

    // Config entries for built-in outcomes
    //Tornado
    public static ConfigEntry<bool> TornadoEnabled = null!;
    public static ConfigEntry<int> TornadoWeight = null!;
    public static ConfigEntry<float> TornadoMaxLifetime = null!;
    public static ConfigEntry<float> TornadoMinLifetime = null!;
    public static ConfigEntry<int> TornadoForce = null!;
    //Luggage
    public static ConfigEntry<bool> LuggageEnabled = null!;
    public static ConfigEntry<int> LuggageWeight = null!;
    //Bounce Shroom
    public static ConfigEntry<bool> BounceEnabled = null!;
    public static ConfigEntry<int> BounceWeight = null!;
    //Shelf Fungus
    public static ConfigEntry<bool> ShelfEnabled = null!;
    public static ConfigEntry<int> ShelfWeight = null!;
    //Lucky Rain
    public static ConfigEntry<bool> LuckyRainEnabled = null!;
    public static ConfigEntry<int> LuckyRainWeight = null!;
    public static ConfigEntry<int> LuckyRainCount = null!;
    //Eruption
    public static ConfigEntry<bool> EruptionEnabled = null!;
    public static ConfigEntry<int> EruptionWeight = null!;
    //Berrynana Peel Rain
    public static ConfigEntry<bool> PeelRainEnabled = null!;
    public static ConfigEntry<int> PeelRainWeight = null!;
    public static ConfigEntry<int> PeelRainGridSize = null!;
    public static ConfigEntry<float> PeelRainSpacing = null!;
    public static ConfigEntry<float> PeelRainLifetime = null!;
    //Explosion
    public static ConfigEntry<bool> ExplodeEnabled = null!;
    public static ConfigEntry<int> ExplodeWeight = null!;
    //Scorpion Rain
    public static ConfigEntry<bool> ScorpoRainEnabled = null!;
    public static ConfigEntry<int> ScorpoRainWeight = null!;
    public static ConfigEntry<int> ScorpoRainCount = null!;
    public static ConfigEntry<float> ScorpoRainLifetime = null!;
    //Berry Rain
    public static ConfigEntry<bool> BerryRainEnabled = null!;
    public static ConfigEntry<int> BerryRainWeight = null!;
    public static ConfigEntry<int> BerryRainCount = null!;
    //Summon Scoutmaster
    public static ConfigEntry<bool> SummonScoutmasterEnabled = null!;
    public static ConfigEntry<int> SummonScoutmasterWeight = null!;
    //Rope/Anti Rope Spawn
    public static ConfigEntry<bool> RopeSpawnEnabled = null!;
    public static ConfigEntry<int> RopeSpawnWeight = null!;
    //Chaos Cloud
    public static ConfigEntry<bool> ChaosCloudEnabled = null!;
    public static ConfigEntry<int> ChaosCloudWeight = null!;
    //Zombie
    public static ConfigEntry<bool> ZombieEnabled = null!;
    public static ConfigEntry<int> ZombieWeight = null!;
    public static ConfigEntry<float> ZombieSprintDistance = null!;
    public static ConfigEntry<float> ZombieLungeDistance = null!;
    public static ConfigEntry<float> ZombieLungeRecoveryTime = null!;
    public static ConfigEntry<float> ZombieLifetime = null!;
    //Backpacks
    public static ConfigEntry<bool> BackpacksEnabled = null!;
    public static ConfigEntry<int> BackpacksWeight = null!;
    public static ConfigEntry<int> BackpackCount = null!;
    //Remed Fungus Heal
    public static ConfigEntry<bool> PuffHealSpawnEnabled = null!;
    public static ConfigEntry<int> PuffHealSpawnWeight = null!;
    //Equipment Shower
    public static ConfigEntry<bool> EquipmentShowerEnabled = null!;
    public static ConfigEntry<int> EquipmentShowerWeight = null!;
    public static ConfigEntry<int> EquipmentShowerCount = null!;
    //Mythic Item Spawn
    public static ConfigEntry<bool> MythicSpawnEnabled = null!;
    public static ConfigEntry<int> MythicSpawnWeight = null!;
    //Checkpoint Flag
    public static ConfigEntry<bool> FlagEnabled = null!;
    public static ConfigEntry<int> FlagWeight = null!;
    //Scout Cannon
    public static ConfigEntry<bool> CannonEnabled = null!;
    public static ConfigEntry<int> CannonWeight = null!;
    //Portable Pot
    public static ConfigEntry<bool> CookEnabled = null!;
    public static ConfigEntry<int> CookWeight = null!;
    //Sunscreen Area
    public static ConfigEntry<bool> SunscreenEnabled = null!;
    public static ConfigEntry<int> SunscreenWeight = null!;
    //Teleport
    public static ConfigEntry<bool> EnderpearlEnabled = null!;
    public static ConfigEntry<int> EnderpearlWeight = null!;
    //Frog
    public static ConfigEntry<bool> FrogEnabled = null!;
    public static ConfigEntry<int> FrogWeight = null!;
    public static ConfigEntry<int> FrogCount = null!;
    public static ConfigEntry<float> FrogLifetime = null!;
    //Ghost Ball
    public static ConfigEntry<bool> GhostBallEnabled = null!;
    public static ConfigEntry<int> GhostBallWeight = null!;
    public static ConfigEntry<float> GhostBallLifetime = null!;
    //Luggage Mimic
    public static ConfigEntry<bool> MimicLuggageEnabled = null!;
    public static ConfigEntry<int> MimicLuggageWeight = null!;
    //Spore Explosion
    public static ConfigEntry<bool> SporeExplosionEnabled = null!;
    public static ConfigEntry<int> SporeExplosionWeight = null!;
    //ShellParty
    public static ConfigEntry<bool> ShellRainEnabled = null!;
    public static ConfigEntry<int> ShellRainWeight = null!;
    public static ConfigEntry<int> ShellRainCount = null!;
    //Anti Gravity Sphere
    public static ConfigEntry<bool> AntiGravSphereEnabled = null!;
    public static ConfigEntry<int> AntiGravSphereWeight = null!;
    public static ConfigEntry<float> AntiGravSphereLifetime = null!;
    //Capybara Pool
    public static ConfigEntry<bool> CapybaraPoolEnabled = null!;
    public static ConfigEntry<int> CapybaraPoolWeight = null!;
    //Beetles
    public static ConfigEntry<bool> BeetlesEnabled = null!;
    public static ConfigEntry<int> BeetlesWeight = null!;
    public static ConfigEntry<int> BeetlesCount = null!;
    public static ConfigEntry<float> BeetlesLifetime = null!;
    //Spawn Petrify Scout
    public static ConfigEntry<bool> PetrifyScoutEnabled = null!;
    public static ConfigEntry<int> PetrifyScoutWeight = null!;
    //Airplane Loot
    public static ConfigEntry<bool> AirPlaneLootEnabled = null!;
    public static ConfigEntry<int> AirPlaneLootWeight = null!;
    //Cactus Balls
    public static ConfigEntry<bool> CactusBallsEnabled = null!;
    public static ConfigEntry<int> CactusBallsWeight = null!;
    public static ConfigEntry<int> CactusBallsCount = null!;
    public static ConfigEntry<float> CactusBallsLifetime = null!;
    //Fire Tornado
    public static ConfigEntry<bool> FireTornadoEnabled = null!;
    public static ConfigEntry<int> FireTornadoWeight = null!;

    public static void BindAll()
    {
        //Tornado
        TornadoEnabled = Instance.Bind("Outcomes.Tornado", "Spawn Tornado Enabled", true, "Enable Spawn Tornado outcome");
        TornadoWeight = Instance.Bind("Outcomes.Tornado", "Spawn Tornado Weight", 80, "Weight for Spawn Tornado");
        TornadoMinLifetime = Instance.Bind("Outcomes.Tornado", "Tornado Min Lifetime", 6f, "Minimum lifetime for the tornado (in seconds)");
        TornadoMaxLifetime = Instance.Bind("Outcomes.Tornado", "Tornado Max Lifetime", 10f, "Maximum lifetime for the tornado (in seconds)");
        TornadoForce = Instance.Bind("Outcomes.Tornado", "Tornado Force", 50, "Force applied by the tornado");
        //Luggage
        LuggageEnabled = Instance.Bind("Outcomes.Luggage", "Spawn Luggage Enabled", true, "Enable Spawn Luggage outcome");
        LuggageWeight = Instance.Bind("Outcomes.Luggage", "Spawn Luggage Weight", 110, "Weight for Spawn Luggage");
        //Bounce Shroom
        BounceEnabled = Instance.Bind("Outcomes.Bounce Shroom", "Spawn Bounce Shroom Enabled", true, "Enable Spawn Bounce Shroom outcome");
        BounceWeight = Instance.Bind("Outcomes.Bounce Shroom", "Spawn Bounce Shroom Weight", 100, "Weight for Spawn Bounce Shroom");
        //Shelf Fungus
        ShelfEnabled = Instance.Bind("Outcomes.Shelf Fungus", "Spawn Shelf Fungus Enabled", true, "Enable Spawn Shelf Fungus outcome");
        ShelfWeight = Instance.Bind("Outcomes.Shelf Fungus", "Spawn Shelf Fungus Weight", 90, "Weight for Spawn Shelf Fungus");
        //Lucky Rain
        LuckyRainEnabled = Instance.Bind("Outcomes.LuckyRain", "Lucky Block Rain Enabled", true, "Enable Lucky Block Rain outcome");
        LuckyRainWeight = Instance.Bind("Outcomes.LuckyRain", "Lucky Block Rain Weight", 75, "Weight for Lucky Block Rain");
        LuckyRainCount = Instance.Bind("Outcomes.LuckyRain", "Lucky Block Count", 3, "Number of lucky blocks to spawn");
        //Eruption
        EruptionEnabled = Instance.Bind("Outcomes.Eruption", "Spawn Eruption Enabled", true, "Enable Spawn Eruption outcome");
        EruptionWeight = Instance.Bind("Outcomes.Eruption", "Spawn Eruption Weight", 90, "Weight for Spawn Eruption");
        //Berrynana Peel Rain
        PeelRainEnabled = Instance.Bind("Outcomes.Berrynana Peel Rain", "Berrynana Peel Rain Enabled", true, "Enable Berrynana Peel Rain outcome");
        PeelRainWeight = Instance.Bind("Outcomes.Berrynana Peel Rain", "Berrynana Peel Rain Weight", 100, "Weight for Berrynana Peel Rain");
        PeelRainGridSize = Instance.Bind("Outcomes.Berrynana Peel Rain", "Grid Size", 5, "Grid size for Berrynana Peel Rain (size of 5 = 5x5 grid or 25 peels)");
        PeelRainSpacing = Instance.Bind("Outcomes.Berrynana Peel Rain", "Berrynana Peel Spacing", 1f, "Spacing between the peels");
        PeelRainLifetime = Instance.Bind("Outcomes.Berrynana Peel Rain", "Berrynana Peel Lifetime", 120f, "Time before the peels despawn (in seconds)");
        //Explosion
        ExplodeEnabled = Instance.Bind("Outcomes.Explosion", "Explosion Enabled", true, "Enable Explosion outcome");
        ExplodeWeight = Instance.Bind("Outcomes.Explosion", "Explosion Weight", 80, "Weight for Explosion");
        //Scorpion Rain
        ScorpoRainEnabled = Instance.Bind("Outcomes.Scorpion Rain", "Scorpion Rain Enabled", true, "Enable Scorpion Rain outcome");
        ScorpoRainWeight = Instance.Bind("Outcomes.Scorpion Rain", "Scorpion Rain Weight", 60, "Weight for Scorpion Rain");
        ScorpoRainCount = Instance.Bind("Outcomes.Scorpion Rain", "Scorpion Count", 3, "Number of scorpions to spawn");
        ScorpoRainLifetime = Instance.Bind("Outcomes.Scorpion Rain", "Scorpion Lifetime", 60f, "Time before scorpions despawn (in seconds)");
        //Berry Rain
        BerryRainEnabled = Instance.Bind("Outcomes.Berry Rain", "Berry Rain Enabled", true, "Enable Berry Rain outcome");
        BerryRainWeight = Instance.Bind("Outcomes.Berry Rain", "Berry Rain Weight", 100, "Weight for Berry Rain");
        BerryRainCount = Instance.Bind("Outcomes.Berry Rain", "Berry Count", 4, "Number of berries to spawn");
        //Summon Scoutmaster
        SummonScoutmasterEnabled = Instance.Bind("Outcomes.Scoutmaster", "Spawn Scoutmaster Enabled", false, "Enable Spawn Scoutmaster outcome");
        SummonScoutmasterWeight = Instance.Bind("Outcomes.Scoutmaster", "Spawn Scoutmaster Weight", 50, "Weight for Spawn Scoutmaster");
        //Rope/Anti Rope Spawn
        RopeSpawnEnabled = Instance.Bind("Outcomes.Rope/Anti Rope Spawn", "Rope/Anti Rope Spawn Enabled", true, "Enable Rope/Anti Rope Spawn outcome");
        RopeSpawnWeight = Instance.Bind("Outcomes.Rope/Anti Rope Spawn", "Rope/Anti Rope Spawn Weight", 95, "Weight for Rope/Anti Rope Spawn");
        //Chaos Cloud
        ChaosCloudEnabled = Instance.Bind("Outcomes.Chaos Cloud", "Chaos Cloud Enabled", true, "Enable Chaos Cloud outcome");
        ChaosCloudWeight = Instance.Bind("Outcomes.Chaos Cloud", "Chaos Cloud Weight", 100, "Weight for Chaos Cloud");
        //Zombie
        ZombieEnabled = Instance.Bind("Outcomes.Zombie", "Spawn Zombie Enabled", true, "Enable Spawn Zombie outcome");
        ZombieWeight = Instance.Bind("Outcomes.Zombie", "Spawn Zombie Weight", 70, "Weight for Spawn Zombie");
        ZombieSprintDistance = Instance.Bind("Outcomes.Zombie", "Zombie Sprint Distance", 30f, "Distance at which the zombie starts sprinting");
        ZombieLungeDistance = Instance.Bind("Outcomes.Zombie", "Zombie Lunge Distance", 15f, "Distance at which the zombie can lunge");
        ZombieLungeRecoveryTime = Instance.Bind("Outcomes.Zombie", "Zombie Lunge Recovery Time", 2f, "Time it takes for the zombie to recover after lunging (in seconds)");
        ZombieLifetime = Instance.Bind("Outcomes.Zombie", "Zombie Lifetime", 90f, "Time before the zombie dies (in seconds)");
        //Backpacks
        BackpacksEnabled = Instance.Bind("Outcomes.Backpacks", "Backpack Spawn Enabled", true, "Enable Backpack Spawn outcome");
        BackpacksWeight = Instance.Bind("Outcomes.Backpacks", "Backpack Spawn Weight", 90, "Weight for Backpack Spawn");
        BackpackCount = Instance.Bind("Outcomes.Backpacks", "Backpack Count", 3, "Number of backpacks to spawn");
        //Remed Fungus Heal
        PuffHealSpawnEnabled = Instance.Bind("Outcomes.Remed Fungus Heal", "Remed Fungus Heal Spawn Enabled", true, "Enable Remed Fungus Heal Spawn outcome");
        PuffHealSpawnWeight = Instance.Bind("Outcomes.Remed Fungus Heal", "Remed Fungus Heal Spawn Weight", 100, "Weight for Remed Fungus Heal Spawn");
        //Equipment Shower
        EquipmentShowerEnabled = Instance.Bind("Outcomes.Equipment Shower", "Equipment Shower Enabled", true, "Enable Equipment Shower outcome");
        EquipmentShowerWeight = Instance.Bind("Outcomes.Equipment Shower", "Equipment Shower Weight", 100, "Weight for Equipment Shower");
        EquipmentShowerCount = Instance.Bind("Outcomes.Equipment Shower", "Equipment Count", 4, "Number of equipment pieces to spawn");
        //Mythic Item Spawn
        MythicSpawnEnabled = Instance.Bind("Outcomes.Mythic Item Spawn", "Mythic Item Spawn Enabled", true, "Enable Mythic Item Spawn outcome");
        MythicSpawnWeight = Instance.Bind("Outcomes.Mythic Item Spawn", "Mythic Item Spawn Weight", 85, "Weight for Mythic Item Spawn");
        //Checkpoint Flag
        FlagEnabled = Instance.Bind("Outcomes.Checkpoint Flag", "Checkpoint Flag Enabled", true, "Enable Checkpoint Flag outcome");
        FlagWeight = Instance.Bind("Outcomes.Checkpoint Flag", "Checkpoint Flag Weight", 90, "Weight for Checkpoint Flag");
        //Scout Cannon
        CannonEnabled = Instance.Bind("Outcomes.Scout Cannon", "Scout Cannon Spawn Enabled", true, "Enable Scout Cannon outcome");
        CannonWeight = Instance.Bind("Outcomes.Scout Cannon", "Scout Cannon Spawn Weight", 95, "Weight for Scout Cannon");
        //Portable Pot
        CookEnabled = Instance.Bind("Outcomes.Portable Pot", "Portable Pot Spawn Enabled", true, "Enable Portable Pot Spawn outcome");
        CookWeight = Instance.Bind("Outcomes.Portable Pot", "Portable Pot Spawn Weight", 85, "Weight for Portable Pot Spawn");
        //Sunscreen Area
        SunscreenEnabled = Instance.Bind("Outcomes.Sunscreen Area", "Sunscreen Area Enabled", true, "Enable Sunscreen area outcome");
        SunscreenWeight = Instance.Bind("Outcomes.Sunscreen Area", "Sunscreen Area Weight", 65, "Weight for Sunscreen area");
        //Teleport
        EnderpearlEnabled = Instance.Bind("Outcomes.Teleport", "Teleport Enabled", true, "Enable Teleport outcome");
        EnderpearlWeight = Instance.Bind("Outcomes.Teleport", "Teleport Weight", 80, "Weight for Teleport");
        //Frog
        FrogEnabled = Instance.Bind("Outcomes.Frog", "Frog Spawn Enabled", true, "Enable Frog Spawn outcome");
        FrogWeight = Instance.Bind("Outcomes.Frog", "Frog Spawn Weight", 70, "Weight for Frog Spawn");
        FrogCount = Instance.Bind("Outcomes.Frog", "Frog Count", 2 , "Number of frogs to spawn");
        FrogLifetime = Instance.Bind("Outcomes.Frog", "Frog Lifetime", 60f, "Time before frogs despawn (in seconds)");
        //Ghost Ball
        GhostBallEnabled = Instance.Bind("Outcomes.Ghost Ball", "Ghost Ball Spawn Enabled", true, "Enable Ghost Ball outcome");
        GhostBallWeight = Instance.Bind("Outcomes.Ghost Ball", "Ghost Ball Spawn Weight", 75, "Weight for Ghost Ball Spawn");
        GhostBallLifetime = Instance.Bind("Outcomes.Ghost Ball", "Ghost Ball Lifetime", 30f, "Time before ghost ball despawns (in seconds)");
        //Luggage Mimic
        MimicLuggageEnabled = Instance.Bind("Outcomes.Luggage Mimic", "Luggage Mimic Spawn Enabled", true, "Enable Luggage Mimic outcome");
        MimicLuggageWeight = Instance.Bind("Outcomes.Luggage Mimic", "Luggage Mimic Spawn Weight", 75, "Weight for Luggage Mimic Spawn");
        //Spore Explosion
        SporeExplosionEnabled = Instance.Bind("Outcomes.Spore Explosion", "Spore Explosion Enabled", true, "Enable Spore Explosion outcome");
        SporeExplosionWeight = Instance.Bind("Outcomes.Spore Explosion", "Spore Explosion Weight", 60, "Weight for Spore Explosion");
        //ShellParty
        ShellRainEnabled = Instance.Bind("Outcomes.ShellParty", "Shell Party Enabled", true, "Enable Shell Party outcome");
        ShellRainWeight = Instance.Bind("Outcomes.ShellParty", "Shell Party Weight", 100, "Weight for Shell Party");
        ShellRainCount = Instance.Bind("Outcomes.ShellParty", "Shell Party Count", 5, "Number of shells to spawn");
        //Anti Gravity Sphere
        AntiGravSphereEnabled = Instance.Bind("Outcomes.Anti Gravity Sphere", "Anti Gravity Sphere Enabled", true, "Enable Anti Gravity Sphere outcome");
        AntiGravSphereWeight = Instance.Bind("Outcomes.Anti Gravity Sphere", "Anti Gravity Sphere Weight", 80, "Weight for Anti Gravity Sphere");
        AntiGravSphereLifetime = Instance.Bind("Outcomes.Anti Gravity Sphere", "Anti Gravity Sphere Lifetime", 60f, "Time before Anti Gravity Sphere despawns (in seconds)");
        //Capybara Pool
        CapybaraPoolEnabled = Instance.Bind("Outcomes.Capybara Pool", "Capybara Pool Enabled", true, "Enable Capybara Pool outcome");
        CapybaraPoolWeight = Instance.Bind("Outcomes.Capybara Pool", "Capybara Pool Weight", 50, "Weight for Capybara Pool");
        //Beetles
        BeetlesEnabled = Instance.Bind("Outcomes.Beetles", "Beetles Enabled", true, "Enable Beetles outcome");
        BeetlesWeight = Instance.Bind("Outcomes.Beetles", "Beetles Weight", 75, "Weight for Beetles");
        BeetlesCount = Instance.Bind("Outcomes.Beetles", "Beetles Count", 4, "Number of beetles to spawn");
        BeetlesLifetime = Instance.Bind("Outcomes.Beetles", "Beetles Lifetime", 60f, "Time before beetles despawn (in seconds)");
        //Spawn Petrify Scout
        PetrifyScoutEnabled = Instance.Bind("Outcomes.Petrify Scout", "Petrify Scout Enabled", true, "Enable Petrify Scout outcome");
        PetrifyScoutWeight = Instance.Bind("Outcomes.Petrify Scout", "Petrify Scout Weight", 100, "Weight for Petrify Scout");
        //Airplane Loot
        AirPlaneLootEnabled = Instance.Bind("Outcomes.Airplane Loot", "Airplane Loot Enabled", true, "Enable Airplane Loot outcome");
        AirPlaneLootWeight = Instance.Bind("Outcomes.Airplane Loot", "Airplane Loot Weight", 100, "Weight for Airplane Loot");
        //Cactus Balls
        CactusBallsEnabled = Instance.Bind("Outcomes.Cactus Balls", "Cactus Balls Enabled", true, "Enable Cactus Balls outcome");
        CactusBallsWeight = Instance.Bind("Outcomes.Cactus Balls", "Cactus Balls Weight", 100, "Weight for Cactus Balls");
        CactusBallsCount = Instance.Bind("Outcomes.Cactus Balls", "Cactus Balls Count", 5, "Number of cactus balls to spawn");
        CactusBallsLifetime = Instance.Bind("Outcomes.Cactus Balls", "Cactus Balls Lifetime", 120f, "Time before cactus balls despawn (in seconds)");
        //Fire Tornado
        FireTornadoEnabled = Instance.Bind("Outcomes.Fire Tornado", "Fire Tornado Enabled", true, "Enable Fire Tornado outcome");
        FireTornadoWeight = Instance.Bind("Outcomes.Fire Tornado", "Fire Tornado Weight", 100, "Weight for Fire Tornado");
    
    
    
    
    
        //Debug Config
        DebugMode = Instance.Bind("Debug", "Debug Mode", false, "Always trigger the selected outcome");
        ForcedOutcome = Instance.Bind("Debug", "Forced Outcome", "", "Outcome method name to trigger");
    }
}