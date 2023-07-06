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

        public override void OnInitializeMelon() {
            Preferences.Init();
            if (Preferences.SpoofDebug.Value) {
                Log("Spoofing debug mode");
                GlobalValues.Instance.isDebug = true;
            }
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