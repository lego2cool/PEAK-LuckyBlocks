using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;



public static class Outcomes
{
    public static List<(Action<LuckyBreakable, Collision> action, int weight)> ActionWeights =
    new List<(Action<LuckyBreakable, Collision>, int)>
    {
        (SpawnTornado, 100),
        (SpawnLuggage, 100),
        (SpawnBounce, 100),
        (SpawnShelf, 100),
        (LuckyRain, 100),
        (SpawnEruption, 100),
        (PeelRain, 100),
        (Explode, 100),
        (ScorpoRain, 100),
        (BerryRain, 100),
        (SummonScoutmaster, 100),
        (RopeSpawn, 100),
        (ChaosCloud, 100),
        (Zombie, 100),
        (Backpacks, 100),
        (PuffHealSpawn, 100),
        (EquipmentShower, 100),
        (MythicSpawn, 100),
        (Flag, 100),
        (Cannon, 100),
        (Cook, 100),
        (Sunscreen, 100),
        (Enderpearl, 100),
        (SpawnErikTower, 100)
    };

    public static void TriggerRandom(LuckyBreakable lb, Collision coll)
    {
        int totalWeight = 0;
        foreach (var outcome in ActionWeights)
        {
            totalWeight += outcome.weight;
        }


    }

    public static void SpawnTornado(LuckyBreakable lb, Collision coll)
    {
        GameObject tornado = PhotonNetwork.Instantiate("Tornado", lb.item.Center(), Quaternion.identity);
        Tornado tornadoComponent = tornado.GetComponent<Tornado>();
        tornadoComponent.tornadoLifetimeMax = 6f;
        tornadoComponent.tornadoLifetimeMin = 10f;
        tornadoComponent.force = 50;
    }

    public static void SpawnLuggage(LuckyBreakable lb, Collision coll)
    {
        Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, coll.contacts[0].normal);

        switch (UnityEngine.Random.Range(0, 4))
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
        int count = 3; 
    
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
        Vector3 targetPos = coll.contacts[0].point + new Vector3(0f,5f,0f);

        // Find the owner of this LuckyBlock
        Character owner = lb.item.lastThrownCharacter;
        if (owner != null)
        {
            // Teleport player
            owner.transform.position = targetPos;
        }
    }

    public static void SpawnEruption(LuckyBreakable lb, Collision coll)
    {
        EruptionSpawner eruption_spawner = UnityEngine.Object.FindAnyObjectByType<EruptionSpawner>();

        // Use the block's position when it breaks
        Vector3 spawnPos = coll.contacts[0].point;

        eruption_spawner.photonView.RPC(
            "RPCA_SpawnEruption",
            RpcTarget.All, // broadcast to everyone
            new object[] { spawnPos }
        );

    }

    public static void PeelRain(LuckyBreakable lb, Collision coll)
    {
        int gridSize = 5; // 5x5 grid = 25 peels
        float spacing = 1f; // Distance between peels
        float height = 6f; // Height to spawn at

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
                remove.seconds = 120f;
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
        int count = 3; 
    
            for (int i = 0; i < count; i++)
            {
                Vector3 spawnPos = coll.contacts[0].point + new Vector3(
                    UnityEngine.Random.Range(-1f, 1f),  
                    UnityEngine.Random.Range(2f, 4f),   
                    UnityEngine.Random.Range(-1f, 1f)   
                );

                // Spawn the Scorp Peels
                GameObject scorpion = PhotonNetwork.Instantiate("0_Items/Scorpion", spawnPos, Quaternion.identity);
                RemoveAfterSeconds remove = scorpion.AddComponent<RemoveAfterSeconds>();
				remove.photonRemove = true;
				remove.seconds = 60f;
            }
    }

    public static void BerryRain(LuckyBreakable lb, Collision coll)
    {
        int count = 4;

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
                UnityEngine.Random.Range(-3f, 3f),
                UnityEngine.Random.Range(4f, 6f),
                UnityEngine.Random.Range(-3f, 3f)
            );

            PhotonNetwork.Instantiate(prefabName, spawnPos, Quaternion.identity);
        }
    }

    public static void SummonScoutmaster(LuckyBreakable lb, Collision coll)
    {
        Scoutmaster scoutmaster;
        if (Scoutmaster.GetPrimaryScoutmaster(out scoutmaster))
        {
            // Move him to the block’s position
            Vector3 spawnPos = coll.contacts[0].point;
            float chaseTime = 30f;

            Character owner = lb.item.lastThrownCharacter;
            if (owner != null)
            {
                scoutmaster.SetCurrentTarget(owner, chaseTime); 
            }

            scoutmaster.view.RPC("WarpPlayerRPC", RpcTarget.All, new object[] { spawnPos, false });
            scoutmaster.view.RPC("StopClimbingRpc", RpcTarget.All, new object[] { 0f });
        }
    }

    public static void RopeSpawn(LuckyBreakable lb, Collision coll)
    {
        Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, coll.contacts[0].normal);
        GameObject rope = null;

        switch (UnityEngine.Random.Range(0, 2))
        {
            case 0:
                rope = PhotonNetwork.Instantiate("RopeAnchorWithAntiRope", coll.contacts[0].point, quaternion);
                break;
            case 1:
                rope = PhotonNetwork.Instantiate("RopeAnchorWithRope", coll.contacts[0].point, quaternion);
                break;
        }
        RopeAnchorWithRope anchor = rope.GetComponent<RopeAnchorWithRope>();
        anchor.SpawnRope();
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
        zombieComponent.zombieSprintDistance = 30f;
        zombieComponent.zombieLungeDistance = 15f;
        zombieComponent.lungeRecoveryTime = 2f;
        zombieComponent.lifetime = 90f;
        zombieComponent.currentState = MushroomZombie.State.Sleeping;
    }

    public static void Backpacks(LuckyBreakable lb, Collision coll)
    {
        int count = 3;

        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPos = coll.contacts[0].point + new Vector3(
                UnityEngine.Random.Range(-2f, 2f),
                UnityEngine.Random.Range(3f, 6f),
                UnityEngine.Random.Range(-2f, 2f)
            );

            // Spawn the backpack prefab again
            PhotonNetwork.Instantiate("0_Items/Backpack", spawnPos, Quaternion.identity);
        }
    }

    public static void PuffHealSpawn(LuckyBreakable lb, Collision coll)
    {
        Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, coll.contacts[0].normal);

        PhotonNetwork.Instantiate("0_Items/HealingPuffShroomSpawn", coll.contacts[0].point, quaternion, 0, null);
    }

    public static void EquipmentShower(LuckyBreakable lb, Collision coll)
    {
        int count = 4;
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
                UnityEngine.Random.Range(-2f, 2f),
                UnityEngine.Random.Range(3f, 5f),
                UnityEngine.Random.Range(-2f, 2f)
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
            "0_Items/Warp Compass"
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

    public static void SpawnErikTower(LuckyBreakable lb, Collision coll)
    {
        UnityEngine.Object.Instantiate(LuckyBlocks.Plugin.urchPrefab, coll.contacts[0].point, Quaternion.identity);
    }
}