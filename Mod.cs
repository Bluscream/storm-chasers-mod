using MelonLoader;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StormChasers {

    internal partial class Mod : MelonMod {
        internal static AssemblyName FileInfo = typeof(Mod).Assembly.GetName();
        internal static MelonInfoAttribute ModInfo = typeof(Mod).Assembly.GetCustomAttribute<MelonInfoAttribute>();
        internal bool fullyLoaded = false;

        internal static void LogDebug(object message) => Log(message, debug: true);
        internal static void Log(object message, LogType type = LogType.Log, bool debug = false) {
            if (!Preferences.EnableLogging.Value || debug && !Preferences.EnableDebugLogging.Value) return;
            var msg = message.ToString();
            MelonLogger.Msg(msg);
            // try { GameController.Instance.getLocalPlayer().think(msg); } catch { }
        }

        public override void OnInitializeMelon() {
            Preferences.Init();
            if (Preferences.SpoofDebug.Value) GlobalValues.Instance.isDebug = true;
            Log("Testing Spoofs:");
            try { Log($"SystemInfo.deviceUniqueIdentifier:\t{SystemInfo.deviceUniqueIdentifier}"); } catch { }
            try { Log($"GlobalValues.isDebug:\t{GlobalValues.Instance.isDebug}"); } catch { }
            try { Log($"MainUIMenu.isLegit():\t{isLegitPatch.isLegit.Invoke(null, new object[] { })}"); } catch { }
            try { Log($"MainUIMenu.isModded():\t{isModdedPatch.isModded.Invoke(null, new object[] { })}"); } catch { }
            try { Log($"MainUIMenu.DirSearch():\t{DirSearchPatch.DirSearch.Invoke(null, new object[] { })}"); } catch { }
            try { Log($"MainUIMenu.isLatest():\t{isModdedPatch.isModded.Invoke(null, new object[] { })}"); } catch { }
            //try { Log($"MainUIMenu.isBeta():\t{MainUIMenu.}"); } catch { }
            if (Preferences.SpoofDebug.Value) GlobalValues.Instance.isDebug = true;
        }

        public override void OnSceneWasInitialized(int buildindex, string sceneName) {
            if (!fullyLoaded && sceneName == "Main Menu") {
                fullyLoaded = true;
                OnMainMenuLoaded();
            }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName) {
            //if (sceneName == "Splash" && Preferences.SkipIntros.Value) {
            //    SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
            //}
        }

        public override void OnSceneWasUnloaded(int buildIndex, string sceneName) {
            if (buildIndex == -1 && Preferences.SkipIntros.Value) {
                SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
            }
        }

        internal void OnMainMenuLoaded() {
        }
    }
}