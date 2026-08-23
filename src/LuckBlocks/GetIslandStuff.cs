using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using BepInEx.Logging;

public class GetIslandStuff
{
    public static bool LoadingWilIsland { get; private set; }

    public static GameObject EruptionPrefab { get; private set; } = null!;

    public static IEnumerator Initialize()
    {

        LoadingWilIsland = true;

        Debug.Log("Loading WilIsland...");

        AsyncOperation load = SceneManager.LoadSceneAsync(
            "WilIsland",
            LoadSceneMode.Additive
        );

        if (load == null)
        {
            Debug.LogError("LoadSceneAsync returned null!");
            yield break;
        }

        yield return load;

        Debug.Log("WilIsland finished loading.");

        EruptionSpawner spawner =
            Object.FindAnyObjectByType<EruptionSpawner>();

        Debug.Log($"Spawner result: {spawner}");

        if (spawner == null)
        {
            Debug.LogError("Couldn't find EruptionSpawner.");
            yield break;
        }

        Debug.Log($"Eruption reference: {spawner.eruption}");

        EruptionPrefab = spawner.eruption;

        Debug.Log("Cached EruptionPrefab.");

        // DON'T unload yet.
        yield return SceneManager.UnloadSceneAsync("WilIsland");

        LoadingWilIsland = false;
    }

}