using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StormChasers {

    internal partial class Mod : MelonMod {
        internal bool fullyLoaded = false;

        internal static void Log(object message, LogType type = LogType.Log) {
            if (!Preferences.EnableLogging.Value) return;
            var msg = message.ToString();
            MelonLogger.Msg(msg);
            // try { GameController.Instance.getLocalPlayer().think(msg); } catch { }
        }


        //EnableLogging = category.CreateEntry(nameof(EnableLogging), true, "Enable Logging", "Wether to enable logging to MelonLoader's Console", is_hidden:true);
        //    SkipIntros = category.CreateEntry(nameof(SkipIntros), true, "Skip Intros", "Wether to automatically load the main menu on game startup instead of going through the splash screens");
        //    SpoofFolderHashes = category.CreateEntry(nameof(SpoofFolderHashes), true, "Spoof Folder Hashes", "Folder hashes are used to disallow joining online games with a modded game");
        //    SpoofDebug = category.CreateEntry(nameof(SpoofDebug), false, "Spoof GlobalValues.isDebug", "isDebug allows you to use debug functionality left in the game by the dev");
        //    SpoofLegit = category.CreateEntry(nameof(SpoofLegit), false, "Spoof MainUIMenu.isLegit()", "DRM Shit");
        //    SpoofModded = category.CreateEntry(nameof(SpoofModded), false, "Spoof MainUIMenu.isModded()", "DRM Shit");
        //    SpoofDirSearch = category.CreateEntry(nameof(SpoofDirSearch), false, "Spoof MainUIMenu.DirSearch()", "DRM Shit");
        //    SpoofLatest = category.CreateEntry(nameof(SpoofLatest), false, "Spoof MainUIMenu.isLatest()");
        //    SpoofBeta = category.CreateEntry(nameof(SpoofBeta), false, "Spoof MainUIMenu.isBeta()");

        public override void OnInitializeMelon() {
            Preferences.Init();
            if (Preferences.SpoofDebug.Value) GlobalValues.Instance.isDebug = true;
            Log("Testing Spoofs:");
            try { Log($"SystemInfo.deviceUniqueIdentifier:\t{SystemInfo.deviceUniqueIdentifier}"); } catch {}
            try { Log($"GlobalValues.isDebug:\t{GlobalValues.Instance.isDebug}"); } catch {}
            try { Log($"MainUIMenu.isLegit():\t{isLegitPatch.isLegit.Invoke(null, new object[] { })}"); } catch {}
            try { Log($"MainUIMenu.isModded():\t{isModdedPatch.isModded.Invoke(null, new object[] { })}"); } catch {}
            try { Log($"MainUIMenu.DirSearch():\t{DirSearchPatch.DirSearch.Invoke(null, new object[] { })}"); } catch {}
            try { Log($"MainUIMenu.isLatest():\t{isModdedPatch.isModded.Invoke(null, new object[] { })}"); } catch {}
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