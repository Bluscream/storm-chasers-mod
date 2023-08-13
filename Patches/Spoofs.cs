using Harmony;
using System;
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;

namespace StormChasers {
    /*
    [05:32:53.402] [Storm_Chasers] CalculateFileData "G:\SteamLibrary\steamapps\common\Storm Chasers/Storm Chasers_Data/Managed/": 63c434b864ff270ce9fef43917dc86212a6e8b9e6cbfd5a9d54aae1c5341502f
    [05:32:53.406] [Storm_Chasers] CalculateFileData "G:\SteamLibrary\steamapps\common\Storm Chasers/Storm Chasers_Data/Plugins/x86_64/": 0afaa40682693c887a168878a20848f7f3db5801dc9b75da671b39041e2e8bcf
    */
    [HarmonyLib.HarmonyPatch(typeof(Utilities.FileUtility), nameof(Utilities.FileUtility.CalculateFileData), new Type[] { typeof(string) })]
    static class CalculateFileDataPatch {
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

    //[HarmonyLib.HarmonyPatch(typeof(GlobalValues), nameof(GlobalValues.isDebug), methodType: HarmonyLib.MethodType.Getter)]
    static class isDebugPatch {
        public static readonly FieldInfo isDebug = typeof(GlobalValues).GetField("isDebug");
        static void Postfix(bool __result) {
            try { Mod.Log($"GlobalValues.isDebug getter called: {__result}"); } catch { }
            if (Preferences.SpoofDebug.Value) {
                Mod.Log($"Presenting spoofed GlobalValues.isDebug");
                __result = true;
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(OnlineAuthentication), nameof(checkDebug))]
    static class checkDebugPatch {
        public static readonly MethodInfo checkDebug = typeof(OnlineAuthentication).GetMethod("checkDebug", BindingFlags.NonPublic);
        static bool Prefix() {
            if (Preferences.SpoofDebug.Value) {
                Mod.Log($"Skipping OnlineAuthentication.checkDebug()");
                return true;
            }
            return false;
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(GlobalValues), nameof(GlobalValues.isBeta))]
    static class isBetaPatch {
        static bool Postfix(bool __result) {
            if (Preferences.SpoofBeta.Value) {
                Mod.Log($"Spoofing MainUIMenu.isBeta()");
                return true;
            }
            return __result;
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(MainUIMenu), nameof(isLegit))]
    static class isLegitPatch {
        public static readonly MethodInfo isLegit = typeof(MainUIMenu).GetMethod("isLegit", BindingFlags.NonPublic);
        static bool Postfix(bool __result) {
            if (Preferences.SpoofLegit.Value) {
                  Mod.Log($"Spoofing MainUIMenu.isLegit()");
                return true;
            }
            return __result;
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(MainUIMenu), nameof(isModded))]
    static class isModdedPatch {
        public static readonly MethodInfo isModded = typeof(MainUIMenu).GetMethod("isModded", BindingFlags.NonPublic);
        static bool Prefix(bool __result) {
            if (Preferences.SpoofModded.Value) {
                Mod.Log($"Spoofing MainUIMenu.isModded()");
                return true;
            }
            return __result;
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(MainUIMenu), nameof(isLastVersion))]
    static class isLastVersionPatch {
        public static readonly MethodInfo isLastVersion = typeof(MainUIMenu).GetMethod("isLastVersion", BindingFlags.NonPublic);
        static bool Prefix(bool __result) {
            if (Preferences.SpoofLatest.Value) {
                Mod.Log($"Spoofing MainUIMenu.isLastVersion()");
                return true;
            }
            return __result;
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(MainUIMenu), nameof(DirSearch))]
    static class DirSearchPatch {
        public static readonly MethodInfo DirSearch = typeof(MainUIMenu).GetMethod("DirSearch", BindingFlags.NonPublic);
        static bool Prefix(bool __result) {
            if (Preferences.SpoofDirSearch.Value) {
                Mod.Log($"Spoofing MainUIMenu.DirSearch()");
                return true;
            }
            return __result;
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(ScoreExtensions), nameof(ScoreExtensions.SetPing))]
    static class PingPatch {
        private static Random random = new Random();
        static bool Prefix(PhotonPlayer player, int newPing) {
            if (Preferences.SpoofPing.Value) {
                var ping = random.Next(Preferences.SpoofedPingMin.Value, Preferences.SpoofedPingMax.Value);
                Mod.LogDebug($"Spoofing ping from {newPing} to {ping}");
                var hashtable = new ExitGames.Client.Photon.Hashtable();
                hashtable["ping"] = ping;
                player.SetCustomProperties(hashtable, null, false);
                return false;
            }
            return true;
        }
    }
}
