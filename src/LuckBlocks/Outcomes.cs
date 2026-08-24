using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using BepInEx.Configuration;


public class Outcomes
{
    public static List<(Action<LuckyBreakable, Collision> action, int weight)> ActionWeights = null!;

    public static void Initialize()
    {
        ActionWeights = new List<(Action<LuckyBreakable, Collision>, int)>();

        if (LuckyBlocks.Config.TornadoEnabled.Value)
            ActionWeights.Add((SpawnTornado, LuckyBlocks.Config.TornadoWeight.Value));
        
        if (LuckyBlocks.Config.LuggageEnabled.Value)
            ActionWeights.Add((SpawnLuggage, LuckyBlocks.Config.LuggageWeight.Value));
        
        if (LuckyBlocks.Config.BounceEnabled.Value)
            ActionWeights.Add((SpawnBounce, LuckyBlocks.Config.BounceWeight.Value));
        
        if (LuckyBlocks.Config.ShelfEnabled.Value)
            ActionWeights.Add((SpawnShelf, LuckyBlocks.Config.ShelfWeight.Value));
        
        if (LuckyBlocks.Config.LuckyRainEnabled.Value)
            ActionWeights.Add((LuckyRain, LuckyBlocks.Config.LuckyRainWeight.Value));
        
        if (LuckyBlocks.Config.EruptionEnabled.Value)
            ActionWeights.Add((SpawnEruption, LuckyBlocks.Config.EruptionWeight.Value));
        
        if (LuckyBlocks.Config.PeelRainEnabled.Value)
            ActionWeights.Add((PeelRain, LuckyBlocks.Config.PeelRainWeight.Value));
        
        if (LuckyBlocks.Config.ExplodeEnabled.Value)
            ActionWeights.Add((Explode, LuckyBlocks.Config.ExplodeWeight.Value));
        
        if (LuckyBlocks.Config.ScorpoRainEnabled.Value)
            ActionWeights.Add((ScorpoRain, LuckyBlocks.Config.ScorpoRainWeight.Value));
        
        if (LuckyBlocks.Config.BerryRainEnabled.Value)
            ActionWeights.Add((BerryRain, LuckyBlocks.Config.BerryRainWeight.Value));
        
        if (LuckyBlocks.Config.SummonScoutmasterEnabled.Value)
            ActionWeights.Add((SummonScoutmaster, LuckyBlocks.Config.SummonScoutmasterWeight.Value));
        
        if (LuckyBlocks.Config.RopeSpawnEnabled.Value)
            ActionWeights.Add((RopeSpawn, LuckyBlocks.Config.RopeSpawnWeight.Value));
        
        if (LuckyBlocks.Config.ChaosCloudEnabled.Value)
            ActionWeights.Add((ChaosCloud, LuckyBlocks.Config.ChaosCloudWeight.Value));
        
        if (LuckyBlocks.Config.ZombieEnabled.Value)
            ActionWeights.Add((Zombie, LuckyBlocks.Config.ZombieWeight.Value));
        
        if (LuckyBlocks.Config.BackpacksEnabled.Value)
            ActionWeights.Add((Backpacks, LuckyBlocks.Config.BackpacksWeight.Value));
        
        if (LuckyBlocks.Config.PuffHealSpawnEnabled.Value)
            ActionWeights.Add((PuffHealSpawn, LuckyBlocks.Config.PuffHealSpawnWeight.Value));
        
        if (LuckyBlocks.Config.EquipmentShowerEnabled.Value)
            ActionWeights.Add((EquipmentShower, LuckyBlocks.Config.EquipmentShowerWeight.Value));
        
        if (LuckyBlocks.Config.MythicSpawnEnabled.Value)
            ActionWeights.Add((MythicSpawn, LuckyBlocks.Config.MythicSpawnWeight.Value));
        
        if (LuckyBlocks.Config.FlagEnabled.Value)
            ActionWeights.Add((Flag, LuckyBlocks.Config.FlagWeight.Value));
        
        if (LuckyBlocks.Config.CannonEnabled.Value)
            ActionWeights.Add((Cannon, LuckyBlocks.Config.CannonWeight.Value));
        
        if (LuckyBlocks.Config.CookEnabled.Value)
            ActionWeights.Add((Cook, LuckyBlocks.Config.CookWeight.Value));
        
        if (LuckyBlocks.Config.SunscreenEnabled.Value)
            ActionWeights.Add((Sunscreen, LuckyBlocks.Config.SunscreenWeight.Value));
        
        if (LuckyBlocks.Config.EnderpearlEnabled.Value)
            ActionWeights.Add((Enderpearl, LuckyBlocks.Config.EnderpearlWeight.Value));

        if (LuckyBlocks.Config.FrogEnabled.Value)
            ActionWeights.Add((FROG, LuckyBlocks.Config.FrogWeight.Value));
        
        if (LuckyBlocks.Config.GhostBallEnabled.Value)
            ActionWeights.Add((SpawnGhostBallGuyThing, LuckyBlocks.Config.GhostBallWeight.Value));
        
        if (LuckyBlocks.Config.MimicLuggageEnabled.Value)
            ActionWeights.Add((MimicLuggage, LuckyBlocks.Config.MimicLuggageWeight.Value));
        
        if (LuckyBlocks.Config.ShellRainEnabled.Value)
            ActionWeights.Add((ShellParty, LuckyBlocks.Config.ShellRainWeight.Value));

        if (LuckyBlocks.Config.SporeExplosionEnabled.Value)
            ActionWeights.Add((SpawnSporeExplosion, LuckyBlocks.Config.SporeExplosionWeight.Value));
        
        if (LuckyBlocks.Config.AntiGravSphereEnabled.Value)
            ActionWeights.Add((AntiGravSphere, LuckyBlocks.Config.AntiGravSphereWeight.Value));

        if (LuckyBlocks.Config.CapybaraPoolEnabled.Value)
            ActionWeights.Add((CapybaraPool, LuckyBlocks.Config.CapybaraPoolWeight.Value));

        if (LuckyBlocks.Config.BeetlesEnabled.Value)
            ActionWeights.Add((Beetles, LuckyBlocks.Config.BeetlesWeight.Value));
        
        if (LuckyBlocks.Config.PetrifyScoutEnabled.Value)
            ActionWeights.Add((SpawnPetrfyScout, LuckyBlocks.Config.PetrifyScoutWeight.Value));
    }

    public static void AddOutcome(Action<LuckyBreakable, Collision> action, int weight = 100, string? name = null)
    {
        name ??= action.Method.Name;

        ConfigEntry<bool> enabledEntry = LuckyBlocks.Config.Instance.Bind(
            $"Custom Outcomes.{name}",
            $"{name} Enabled",
            true,
            $"Enable custom outcome: {name}");

        ConfigEntry<int> weightEntry = LuckyBlocks.Config.Instance.Bind(
            $"Custom Outcomes.{name}",
            $"{name} Weight",
            weight,
            $"Weight for custom outcome: {name}");

        LuckyBlocks.Plugin.Log.LogInfo($"Adding outcome {name} with weight {weightEntry.Value}");

        if (enabledEntry.Value)
        {
            ActionWeights.Add((action, weightEntry.Value));
        }
    }

    public static void TriggerRandom(LuckyBreakable lb, Collision coll)
    {
        if (ActionWeights == null || ActionWeights.Count == 0)
        {
            return;
        }

        if (LuckyBlocks.Config.DebugMode.Value && !string.IsNullOrWhiteSpace(LuckyBlocks.Config.ForcedOutcome.Value))
        {
            string forcedOutcome = LuckyBlocks.Config.ForcedOutcome.Value.Trim();

            foreach (var outcome in ActionWeights)
            {
                if (string.Equals(
                        outcome.action.Method.Name,
                        forcedOutcome,
                        StringComparison.OrdinalIgnoreCase))
                {
                    outcome.action(lb, coll);
                    return;
                }
            }

            LuckyBlocks.Plugin.Log.LogWarning(
                $"Could not find forced outcome '{forcedOutcome}'. Using random outcome.");
        }

        int totalWeight = 0;
        foreach (var outcome in ActionWeights)
        {
            if (outcome.weight > 0)
            {
                totalWeight += outcome.weight;
            }
        }

        if (totalWeight <= 0)
        {
            return;
        }

        int roll = UnityEngine.Random.Range(0, totalWeight);
        foreach (var outcome in ActionWeights)
        {
            if (outcome.weight <= 0)
            {
                continue;
            }

            if (roll < outcome.weight)
            {
                outcome.action(lb, coll);
                return;
            }

            roll -= outcome.weight;
        }
    }

    public static void SpawnTornado(LuckyBreakable lb, Collision coll)
    {
        GameObject tornado = PhotonNetwork.Instantiate("Tornado", lb.item.Center(), Quaternion.identity);
        Tornado tornadoComponent = tornado.GetComponent<Tornado>();
        tornadoComponent.tornadoLifetimeMax = LuckyBlocks.Config.TornadoMaxLifetime.Value;
        tornadoComponent.tornadoLifetimeMin = LuckyBlocks.Config.TornadoMinLifetime.Value;
        tornadoComponent.force = LuckyBlocks.Config.TornadoForce.Value;
    }

    public static void SpawnLuggage(LuckyBreakable lb, Collision coll)
    {
        Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, coll.contacts[0].normal);

        switch (UnityEngine.Random.Range(0, 5))
        {
            case 0:
                PhotonNetwork.Instantiate("0_Items/LuggageSmall", coll.contacts[0].point, quaternion);
                break;
            case 1:
                PhotonNetwork.Instantiate("0_Items/LuggageBig", coll.contacts[0].point, quaternion);
                break;
            case 2:
                PhotonNetwork.Instantiate("0_Items/LuggageEpic", coll.contacts[0].point, quaternion);
                break;
            case 3:
                PhotonNetwork.Instantiate("0_Items/LuggageAncient", coll.contacts[0].point, quaternion);
                break;
            case 4:
                PhotonNetwork.Instantiate("0_Items/LuggageClown", coll.contacts[0].point, quaternion);
                break;
        }
    }

    public static void SpawnBounce(LuckyBreakable lb, Collision coll)
    {
        Quaternion quaternion = Quaternion.Euler(0f, (float)UnityEngine.Random.Range(0, 360), 0f);
        quaternion = Quaternion.LookRotation(Vector3.forward, coll.contacts[0].normal);
        PhotonNetwork.Instantiate("0_Items/BounceShroomSpawn", coll.contacts[0].point, quaternion, 0, null);
    }
    
    public static void SpawnShelf(LuckyBreakable lb, Collision coll)
    {
        Quaternion quaternion = Quaternion.Euler(0f, (float)UnityEngine.Random.Range(0, 360), 0f);
        PhotonNetwork.Instantiate("0_Items/ShelfShroomSpawn", coll.contacts[0].point, quaternion, 0, null);    
    }

    public static void LuckyRain(LuckyBreakable lb, Collision coll)
    {
        int count = LuckyBlocks.Config.LuckyRainCount.Value; 
    
            for (int i = 0; i < count; i++)
            {
                Vector3 spawnPos = coll.contacts[0].point + new Vector3(
                    UnityEngine.Random.Range(-3f, 3f),  
                    UnityEngine.Random.Range(4f, 7f),   
                    UnityEngine.Random.Range(-3f, 3f)   
                );

                // Spawn the LuckyBlock prefab again
                GameObject block = PhotonNetwork.Instantiate("0_Items/legocool.LuckyBlocks:LuckyBlock", spawnPos, Quaternion.identity);
                Item itemComponent = block.GetComponent<Item>();
                itemComponent.lastThrownCharacter = lb.item.lastThrownCharacter;
            }
    }

    public static void Enderpearl(LuckyBreakable lb, Collision coll)
    {
        // Put teleport position one unit before the contact point so players aren't jammed into the contact surface
        Vector3 targetPos = coll.contacts[0].point + coll.contacts[0].normal;
        Character owner = lb.item.lastThrownCharacter;
        if (owner != null)
        {
            owner.photonView.RPC("WarpPlayerRPC", RpcTarget.All, targetPos, true);
        }
    }

    public static void SpawnEruption(LuckyBreakable lb, Collision coll)
    {
        lb.item.view.RPC("RPC_SpawnPrefab", RpcTarget.All, new object[] { "EruptionPrefab", coll.contacts[0].point, Quaternion.LookRotation(Vector3.up) });

    }

    public static void PeelRain(LuckyBreakable lb, Collision coll)
    {
        int gridSize = LuckyBlocks.Config.PeelRainGridSize.Value; // 5x5 grid = 25 peels
        float spacing = LuckyBlocks.Config.PeelRainSpacing.Value; // Distance between peels
        float height = 0.75f; // Height to spawn at

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                Vector3 spawnPos = coll.contacts[0].point + new Vector3(
                    (x - gridSize / 2) * spacing,
                    height,
                    (z - gridSize / 2) * spacing
                );

                // Spawn the Nana Peels in grid pattern
                GameObject nana = PhotonNetwork.Instantiate("0_Items/Berrynana Peel Yellow", spawnPos, Quaternion.identity);
                RemoveAfterSeconds remove = nana.AddComponent<RemoveAfterSeconds>();
                remove.photonRemove = true;
                remove.seconds = LuckyBlocks.Config.PeelRainLifetime.Value;
            }
        }
    }

    public static void Explode(LuckyBreakable lb, Collision coll)
    {
        GameObject dynamite = PhotonNetwork.Instantiate("0_Items/Dynamite", coll.contacts[0].point, Quaternion.identity);
        Dynamite dynamiteComponent = dynamite.GetComponent<Dynamite>();
        dynamiteComponent.LightFlare();
        dynamiteComponent.startingFuseTime = 0f;

    }

    public static void ScorpoRain(LuckyBreakable lb, Collision coll)
    {
        int count = LuckyBlocks.Config.ScorpoRainCount.Value; 
    
            for (int i = 0; i < count; i++)
            {
                Vector3 spawnPos = coll.contacts[0].point + new Vector3(
                    UnityEngine.Random.Range(-0.10f, 0.10f),
                    1f,
                    UnityEngine.Random.Range(-0.10f, 0.10f)
            );

                // Spawn the Scorp Peels
                GameObject scorpion = PhotonNetwork.Instantiate("0_Items/Scorpion", spawnPos, Quaternion.identity);
                RemoveAfterSeconds remove = scorpion.AddComponent<RemoveAfterSeconds>();
				remove.photonRemove = true;
				remove.seconds = LuckyBlocks.Config.ScorpoRainLifetime.Value;
            }
    }

    public static void BerryRain(LuckyBreakable lb, Collision coll)
    {
        int count = LuckyBlocks.Config.BerryRainCount.Value;

        // A pool of good/neutral item prefab names
        string[] itemPool = new string[]
        {
            "0_items/Winterberry Yellow",
            "0_Items/Winterberry Orange",
            "0_Items/Prickleberry_Gold",
            "0_Items/Prickleberry_Red",
            "0_Items/Apple Berry Green",
            "0_Items/Apple Berry Red",
            "0_Items/Apple Berry Yellow",
            "0_Items/Berrynana Brown",
            "0_Items/Berrynana Blue",
            "0_Items/Berrynana Pink",
            "0_Items/Berrynana Yellow",
            "0_Items/Clusterberry Black",
            "0_Items/Clusterberry Red",
            "0_Items/Clusterberry Yellow",
            "0_Items/Kingberry Green",
            "0_Items/Kingberry Purple",
            "0_Items/Kingberry Yellow",
            "0_Items/Napberry",
            "0_Items/Shroomberry_Blue",
            "0_Items/Shroomberry_Green",
            "0_Items/Shroomberry_Purple",
            "0_Items/Shroomberry_Red",
            "0_Items/Shroomberry_Yellow"
        };

        for (int i = 0; i < count; i++)
        {
            // Random item from pool
            string prefabName = itemPool[UnityEngine.Random.Range(0, itemPool.Length)];

            // Spawn position above the block
            Vector3 spawnPos = coll.contacts[0].point + new Vector3(
                UnityEngine.Random.Range(-0.10f, 0.10f),
                1f,
                UnityEngine.Random.Range(-0.10f, 0.10f)
            );

            GameObject berry = PhotonNetwork.Instantiate(prefabName, spawnPos, Quaternion.identity);
            berry.GetComponent<Rigidbody>().isKinematic = false; // Ensure gravity affects the berries
        }
    }

    public static void SummonScoutmaster(LuckyBreakable lb, Collision coll)
    {
        Scoutmaster scoutmaster;
        if (Scoutmaster.GetPrimaryScoutmaster(out scoutmaster))
        {
            // Move him to the block’s position
            Vector3 spawnPos = coll.contacts[0].point + coll.contacts[0].normal;
            float chaseTime = 30f;

            Character owner = lb.item.lastThrownCharacter;
            if (owner != null)
            {
                scoutmaster.SetCurrentTarget(owner, chaseTime); 
            }

            scoutmaster.view.RPC("WarpPlayerRPC", RpcTarget.All, spawnPos, true);
            scoutmaster.view.RPC("StopClimbingRpc", RpcTarget.All, new object[] { 0f });
        }
    }

    public static void RopeSpawn(LuckyBreakable lb, Collision coll)
    {
        Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, coll.contacts[0].normal);
        GameObject? rope = null;

        switch (UnityEngine.Random.Range(0, 2))
        {
            case 0:
                rope = PhotonNetwork.Instantiate("RopeAnchorWithAntiRope", coll.contacts[0].point, quaternion);
                break;
            case 1:
                rope = PhotonNetwork.Instantiate("RopeAnchorWithRope", coll.contacts[0].point, quaternion);
                break;
        }
        if (rope != null)
        {
            RopeAnchorWithRope anchor = rope.GetComponent<RopeAnchorWithRope>();
            anchor.SpawnRope();
        }
    }

    public static void ChaosCloud(LuckyBreakable lb, Collision coll)
    {
        GameObject box = PhotonNetwork.Instantiate("0_Items/PandorasBox", coll.contacts[0].point, Quaternion.identity);
        ItemCooking cooking = box.GetComponent<ItemCooking>();
        cooking.FinishCooking();
    }

    public static void Zombie(LuckyBreakable lb, Collision coll)
    {
        GameObject spawnedZombie = PhotonNetwork.Instantiate("MushroomZombie", lb.item.Center(), Quaternion.identity);
        MushroomZombie zombieComponent = spawnedZombie.GetComponent<MushroomZombie>();
        zombieComponent.zombieSprintDistance = LuckyBlocks.Config.ZombieSprintDistance.Value;
        zombieComponent.zombieLungeDistance = LuckyBlocks.Config.ZombieLungeDistance.Value;
        zombieComponent.lungeRecoveryTime = LuckyBlocks.Config.ZombieLungeRecoveryTime.Value;
        zombieComponent.lifetime = LuckyBlocks.Config.ZombieLifetime.Value;
        zombieComponent.currentState = MushroomZombie.State.Sleeping;
    }

    public static void Backpacks(LuckyBreakable lb, Collision coll)
    {
        int count = LuckyBlocks.Config.BackpackCount.Value;
        string[] PackPool = new string[]
        {
            "0_Items/Backpack",
            "0_Items/Fannypack",
            "0_Items/Rocketpack",
            "0_Items/Jetpack",
        };

        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPos = coll.contacts[0].point + new Vector3(
                UnityEngine.Random.Range(-0.10f, 0.10f),
                1f,
                UnityEngine.Random.Range(-0.10f, 0.10f)
            );

            // Spawn the backpack prefab again
            PhotonNetwork.Instantiate(PackPool[UnityEngine.Random.Range(0, PackPool.Length)], spawnPos, Quaternion.identity);
        }
    }

    public static void PuffHealSpawn(LuckyBreakable lb, Collision coll)
    {
        Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, coll.contacts[0].normal);

        PhotonNetwork.Instantiate("0_Items/HealingPuffShroomSpawn", coll.contacts[0].point, quaternion, 0, null);
    }

    public static void EquipmentShower(LuckyBreakable lb, Collision coll)
    {
        int count = LuckyBlocks.Config.EquipmentShowerCount.Value;
        string[] equipmentPool = new string[]
        {
            "0_Items/ChainShooter",
            "0_Items/ClimbingSpike",
            "0_Items/Energy Drink",
            "0_Items/Lollipop",
            "0_Items/RescueHook",
            "0_Items/RopeShooter",
            "0_Items/RopeSpool"
        };

        for (int i = 0; i < count; i++)
        {
            string prefabName = equipmentPool[UnityEngine.Random.Range(0, equipmentPool.Length)];
            
            Vector3 spawnPos = coll.contacts[0].point + new Vector3(
                UnityEngine.Random.Range(-0.10f, 0.10f),
                1f,
                UnityEngine.Random.Range(-0.10f, 0.10f)
            );

            PhotonNetwork.Instantiate(prefabName, spawnPos, Quaternion.identity);
        }
    }

    public static void MythicSpawn(LuckyBreakable lb, Collision coll)
    {
        string[] itemPool = new string[]
        {
            "0_Items/Anti-Rope Spool",
            "0_Items/AncientIdol",
            "0_Items/BookOfBones",
            "0_Items/Bugle_Magic",
            "0_Items/Bugle_Scoutmaster Variant",
            "0_Items/Cure-All",
            "0_Items/Cursed Skull",
            "0_Items/Lantern_Faerie",
            "0_Items/PandorasBox",
            "0_Items/RopeShooterAnti",
            "0_Items/ScoutEffigy",
            "0_Items/Warp Compass",
            "0_Items/RitualDagger",
            "0_Items/AntiZooka",
            "0_Items/BookOfBones",
        };

        // Random item from pool
        string prefabName = itemPool[UnityEngine.Random.Range(0, itemPool.Length)];

        PhotonNetwork.Instantiate(prefabName, lb.item.Center(), Quaternion.identity);
    }

    public static void Sunscreen(LuckyBreakable lb, Collision coll)
    {
        GameObject box = PhotonNetwork.Instantiate("0_Items/Sunscreen", coll.contacts[0].point, Quaternion.identity);
        ItemCooking cooking = box.GetComponent<ItemCooking>();
        cooking.FinishCooking();
    }

    public static void Cannon(LuckyBreakable lb, Collision coll)
    {
        Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, coll.contacts[0].normal);
        PhotonNetwork.Instantiate("ScoutCannon_Placed", coll.contacts[0].point, quaternion, 0, null);
    }

    public static void Cook(LuckyBreakable lb, Collision coll)
    {
        Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, coll.contacts[0].normal);
        PhotonNetwork.Instantiate("PortableStovetop_Placed", coll.contacts[0].point, quaternion, 0, null);
    }

    public static void Flag(LuckyBreakable lb, Collision coll)
    {
        Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, coll.contacts[0].normal);

        GameObject flag = PhotonNetwork.Instantiate("Flag_Planted_Checkpoint", coll.contacts[0].point, quaternion, 0, null);
        CheckpointFlag flagCompo = flag.GetComponent<CheckpointFlag>();
        flagCompo.Initialize(lb.item.lastThrownCharacter);
    }

    public static void FROG(LuckyBreakable lb, Collision coll)
    {
        int count = LuckyBlocks.Config.FrogCount.Value;

        for (int i = 0; i < count; i++)
        {
            GameObject frog = PhotonNetwork.Instantiate("0_Items/Frog", coll.contacts[0].point, Quaternion.identity, 0, null);
            RemoveAfterSeconds remove = frog.AddComponent<RemoveAfterSeconds>();
            remove.photonRemove = true;
            remove.seconds = LuckyBlocks.Config.FrogLifetime.Value;
        }
    }

    public static void SpawnGhostBallGuyThing(LuckyBreakable lb, Collision coll)
    {
        GameObject ghostBallGuy = PhotonNetwork.Instantiate("GhostBall", lb.item.Center(), Quaternion.identity);
        Peak.GhostBall ghostBallGuyComponent = ghostBallGuy.GetComponent<Peak.GhostBall>();
        ghostBallGuyComponent.lifetime = LuckyBlocks.Config.GhostBallLifetime.Value;
    }

    public static void SpawnSporeExplosion(LuckyBreakable lb, Collision coll)
    {
        lb.item.view.RPC("RPC_SpawnPrefab", RpcTarget.All, new object[] { "JungleSporeMushroomExploPrefab", coll.contacts[0].point, Quaternion.LookRotation(Vector3.up) });   
    }
    
    public static void MimicLuggage(LuckyBreakable lb, Collision coll)
    {
        Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, coll.contacts[0].normal);
        PhotonNetwork.Instantiate("0_Items/LuggageTrick", coll.contacts[0].point, quaternion, 0, null);
    }

    public static void ShellParty(LuckyBreakable lb, Collision coll)
    {
        int count = LuckyBlocks.Config.ShellRainCount.Value;

        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPos = coll.contacts[0].point + new Vector3(
                UnityEngine.Random.Range(-2f, 2f),
                UnityEngine.Random.Range(3f, 6f),
                UnityEngine.Random.Range(-2f, 2f)
            );

            // Spawn the Shell prefab again
            PhotonNetwork.Instantiate("0_Items/Shell Big", spawnPos, Quaternion.identity);
        }
    }

    public static void AntiGravSphere(LuckyBreakable lb, Collision coll)
    {
        Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, coll.contacts[0].normal);
        GameObject antiGravSphere = PhotonNetwork.Instantiate("AntiSphere_Projectile", coll.contacts[0].point, quaternion, 0, null);
        Peak.AntiSphere antiSphereComponent = antiGravSphere.GetComponent<Peak.AntiSphere>();
        antiSphereComponent.lifetime = LuckyBlocks.Config.AntiGravSphereLifetime.Value;
    }

    public static void CapybaraPool(LuckyBreakable lb, Collision coll)
    {
        lb.item.view.RPC("RPC_SpawnPrefab", RpcTarget.All, new object[] { "CapybaraPool", coll.contacts[0].point, Quaternion.identity });
    }

    public static void Beetles(LuckyBreakable lb, Collision coll)
    {
        int count = LuckyBlocks.Config.BeetlesCount.Value;

        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPos = coll.contacts[0].point + new Vector3(
                UnityEngine.Random.Range(-0.10f, 0.10f),
                0.75f,
                UnityEngine.Random.Range(-0.10f, 0.10f)
            );

            // Spawn the Beetle prefab
            GameObject beetle = PhotonNetwork.Instantiate("0_Items/Beetle", spawnPos, Quaternion.identity);
            RemoveAfterSeconds remove = beetle.AddComponent<RemoveAfterSeconds>();
            remove.photonRemove = true;
            remove.seconds = LuckyBlocks.Config.BeetlesLifetime.Value;
        }
    }

    public static void SpawnPetrfyScout(LuckyBreakable lb, Collision coll)
    {
        PhotonNetwork.Instantiate("PetrifiedScout", coll.contacts[0].point, lb.item.lastThrownCharacter.refs.ragdoll.bodySpawnPoint.transform.rotation, 0, null).GetComponent<PhotonView>().RPC("RPC_SpawnPetrifiedScout", RpcTarget.All, new object[]
		{
            lb.item.view.ViewID,
			false
		});
    }



    
}

