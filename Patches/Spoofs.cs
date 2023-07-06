using System;
using System.Text.RegularExpressions;

namespace StormChasers {
    /*
    [05:32:53.402] [Storm_Chasers] CalculateFileData "G:\SteamLibrary\steamapps\common\Storm Chasers/Storm Chasers_Data/Managed/": 63c434b864ff270ce9fef43917dc86212a6e8b9e6cbfd5a9d54aae1c5341502f
    [05:32:53.406] [Storm_Chasers] CalculateFileData "G:\SteamLibrary\steamapps\common\Storm Chasers/Storm Chasers_Data/Plugins/x86_64/": 0afaa40682693c887a168878a20848f7f3db5801dc9b75da671b39041e2e8bcf
    */
    [HarmonyLib.HarmonyPatch(typeof(Utilities.FileUtility), nameof(Utilities.FileUtility.CalculateFileData), new Type[] { typeof(string) })]
    static class CalculateFileDataPatch {
        // static Entity Postfix(Entity __result, GameObject _gameObject, string _className)
        static string Postfix(string __result, string directory) {
            Mod.Log($"CalculateFileData \"{directory}\": {__result}");
            foreach (var spoofedFolderHash in Preferences.SpoofedFolderHashes.Entries) {
                if (new Regex(spoofedFolderHash.Identifier).IsMatch(directory)) {
                    var spoofedFolderHashValue = spoofedFolderHash.BoxedValue as string;
                    Mod.Log($"Presenting spoofed folder hash: {spoofedFolderHashValue}");
                    return spoofedFolderHashValue;
                }
            }
            return __result;
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(GlobalValues), nameof(GlobalValues.isBeta))]
    static class isBetaPatch {
        static bool Postfix(bool __result) {
            if (Preferences.SpoofBeta.Value) {
                  Mod.Log($"Spoofing isBeta");
                return true;
            }
            return __result;
        }
    }
}
