using HarmonyLib;
using UnityEngine;

public static class Patches
{
	private static bool islandStuffInitialized;

	[HarmonyPatch(typeof(Tornado), "PickTarget")]
	public static class Tornado_PickTarget_Patch
	{
		private static bool Prefix(Tornado __instance)
		{
			// A tornado with no parent target will throw a bunch of tracebacks if it
			// tries to run the target picking routine, so just skip it.
			return __instance.targetParent != null;
		}
	}

	[HarmonyPatch(typeof(SFX_PlayOneShot), "PlayOneShot")]
	public static class SFX_PlayOneShot_PlayOneShot_Patch
	{
		private static bool Prefix(SFX_PlayOneShot __instance)
		{
			return !GetIslandStuff.LoadingWilIsland;
		}
	}

	[HarmonyPatch(typeof(LoadingScreenHandler), "LoadSceneProcess")]
	public static class LoadingScreenHandler_LoadSceneProcess_Patch
	{
		private static bool Prefix(LoadingScreenHandler __instance, string sceneName, bool networked, bool yieldForCharacterSpawn = false, float extraYieldTimeOnEnd = 3f)
		{
			if (sceneName == "Airport" && !islandStuffInitialized)
			{
				islandStuffInitialized = true;
				__instance.StartCoroutine(GetIslandStuff.Initialize());
			}
			return true;
		}
	}
}
