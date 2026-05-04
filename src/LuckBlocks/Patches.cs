using HarmonyLib;

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