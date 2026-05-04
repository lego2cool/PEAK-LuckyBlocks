using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using PEAKLib.Items;
using PEAKLib.Core;
using PEAKLib.Items.UnityEditor;
using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;

namespace LuckyBlocks;

public static class LuckyBlockRarity
{
    public const Rarity LuckyBlockDefault = (Rarity)(-1);
}

[BepInAutoPlugin]
[BepInDependency(ItemsPlugin.Id)]
[BepInDependency(CorePlugin.Id)]
public partial class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log { get; private set; } = null!;
    private Harmony _harmony = null!;

    private void Awake()
    {
        _harmony = new Harmony("legocool.LuckBlock");
        _harmony.PatchAll();
        Log = Logger;

        this.LoadBundleWithName(
            "luckyblock.peakbundle",InitLuckyBlock);

        LocalizedText.mainTable["NAME_LUCKYBLOCK"] = new List<string>(new string[LocalizedText.LANGUAGE_COUNT]);
        for (int i = 0; i < LocalizedText.LANGUAGE_COUNT; i++)
        {
            LocalizedText.mainTable["NAME_LUCKYBLOCK"][i] = "Lucky Block";
        }
        LocalizedText.mainTable["NAME_LUCKYBLOCK"][(int)LocalizedText.Language.SimplifiedChinese] = "幸运方块";

        LootData.RarityWeights.Add(LuckyBlockRarity.LuckyBlockDefault, 500);

        BindAll();

        Log.LogInfo($"Plugin {Name} is loaded!");
    }

    private void InitLuckyBlock(PeakBundle bundle)
    {
        foreach (var name in bundle.GetAllAssetNames())
            Plugin.Log.LogInfo($"Asset: {name}");

        var LBPrefab = bundle.LoadAsset<GameObject>("LuckyBlock.prefab");

        var breaking = LBPrefab.AddComponent<LuckyBreakable>();
        breaking.breakOnCollision = true;
        breaking.minBreakVelocity = 10f;

        // Makes the block more common
        var rarity = LBPrefab.GetComponent<LootData>();
        rarity.Rarity = LuckyBlockRarity.LuckyBlockDefault;

        bundle.Mod.RegisterContent();
    }
}


