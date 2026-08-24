using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using BepInEx.Logging;

public class GetIslandStuff
{
    public static bool LoadingWilIsland { get; private set; }

    public static GameObject EruptionPrefab { get; private set; } = null!;
    public static GameObject JungleSporeMushroomExploPrefab { get; private set; } = null!;
    public static GameObject CapybaraPool{ get; private set; } = null!;

    public static GameObject? FindGameObjectByPath(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return null;
        }

        string normalizedPath = path.Trim().Trim('/');
        string[] pathParts = normalizedPath.Split('/');

        for (int sceneIndex = 0; sceneIndex < SceneManager.sceneCount; sceneIndex++)
        {
            Scene scene = SceneManager.GetSceneAt(sceneIndex);
            if (!scene.isLoaded)
            {
                continue;
            }

            foreach (GameObject rootObject in scene.GetRootGameObjects())
            {
                Transform? current = rootObject.transform;
                int startIndex = string.Equals(rootObject.name, pathParts[0], System.StringComparison.Ordinal)
                    ? 1
                    : 0;

                if (startIndex == 0 && pathParts.Length == 1 && !string.Equals(rootObject.name, pathParts[0], System.StringComparison.Ordinal))
                {
                    continue;
                }

                for (int partIndex = startIndex; partIndex < pathParts.Length && current != null; partIndex++)
                {
                    current = current.Find(pathParts[partIndex]);
                }

                if (current != null)
                {
                    return current.gameObject;
                }
            }
        }

        return null;
    }
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

        if (spawner == null)
        {
            Debug.LogError("Couldn't find EruptionSpawner.");
            yield break;
        }
        EruptionPrefab = spawner.eruption;

        GameObject? SporeMushroom = FindGameObjectByPath("Map/Biome_2/Tropics/Jungle_Segment/Default/Props_Wall/ExploShrooms/Jungle_SporeMushroomExplo");
        SpawnGameObject? SporeMushroomSpawner = SporeMushroom?.GetComponent<SpawnGameObject>();

        if (SporeMushroomSpawner?.toSpawn == null)
        {
            Debug.LogError("Couldn't find Jungle Spore Mushroom explosion prefab.");
            yield break;
        }

        JungleSporeMushroomExploPrefab = SporeMushroomSpawner.toSpawn;

        GameObject? CapybaraPoolObj = FindGameObjectByPath("Map/Biome_3/Alpine/Snow_Segment/Onsen");
        if (CapybaraPoolObj == null)
        {
            Debug.LogError("Couldn't find Capybara Pool.");
            yield break;
        }

        CapybaraPool = Object.Instantiate(CapybaraPoolObj);
        CapybaraPool.name = "CapybaraPoolTemplate";
        CapybaraPool.transform.SetParent(null);
        CapybaraPool.transform.position = new Vector3(0f, -10000f, 0f);
        CapybaraPool.hideFlags = HideFlags.HideAndDontSave;
        Object.DontDestroyOnLoad(CapybaraPool);
        CapybaraPool.SetActive(false);
        Debug.Log("Created persistent Capybara Pool template.");

        yield return SceneManager.UnloadSceneAsync("WilIsland");

        LoadingWilIsland = false;
    }

}