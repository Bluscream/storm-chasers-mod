using SmartLocalization;
using System.Reflection;
using UIWidgetsSamples;

namespace Photon {
    [HarmonyLib.HarmonyPatch(typeof(GameOverUI), nameof(addChatText))] // , new Type[] { typeof(PhotonPlayer), typeof(string) }
    static class GameOverAddChatTextPatch {
        public static readonly MethodInfo addChatText = typeof(GameOverUI).GetMethod("addChatText", BindingFlags.NonPublic);
        static void Prefix(PhotonPlayer author, string text) {
            if (Preferences.LogChatInfo.Value) {
                var UserName = ((author != null) ? ((author.ID == PhotonNetwork.player.ID) ? (LanguageManager.Instance.GetTextValue("UI.Ingame.Chat.You") + " " + author.NickName) : author.NickName) : LanguageManager.Instance.GetTextValue("UI.Ingame.Chat.Information"));
                var Type = ((author != null) ? ChatLineType.User : ChatLineType.System);
                var UserTeam = ((author != null) ? author.GetTeam() : PunTeams.Team.none);
                Mod.Log($"{Type} > [{UserTeam}] \"{UserName}\": \"{text}\"");
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(GameController), nameof(GameController.addChatText))]
    static class GameControllerAddChatTextPatch {
        //public static readonly MethodInfo addChatText = typeof(GameController).GetMethod("addChatText", BindingFlags.NonPublic);
        static void Prefix(PhotonPlayer author, string text, bool addToChatList) {
            if (Preferences.LogChatInfo.Value) {
                var UserName = ((author != null) ? ((author.ID == PhotonNetwork.player.ID) ? (LanguageManager.Instance.GetTextValue("UI.Ingame.Chat.You") + " " + author.NickName) : author.NickName) : LanguageManager.Instance.GetTextValue("UI.Ingame.Chat.Information"));
                var Type = ((author != null) ? ChatLineType.User : ChatLineType.System);
                var UserTeam = ((author != null) ? author.GetTeam() : PunTeams.Team.none);
                Mod.Log($"{Type} > [{UserTeam}] \"{UserName}\": \"{text}\" (hidden: {!addToChatList})");
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(GameController), nameof(receiveChat))]
    static class GameControllerReceiveChatPatch {
        public static readonly MethodInfo receiveChat = typeof(GameController).GetMethod("receiveChat", BindingFlags.NonPublic);
        static void Prefix(PhotonPlayer author, string text, bool isForAllPlayers) {
            if (Preferences.LogChatMessages.Value) {
                var UserName = ((author != null) ? ((author.ID == PhotonNetwork.player.ID) ? (LanguageManager.Instance.GetTextValue("UI.Ingame.Chat.You") + " " + author.NickName) : author.NickName) : LanguageManager.Instance.GetTextValue("UI.Ingame.Chat.Information"));
                var Type = ((author != null) ? ChatLineType.User : ChatLineType.System);
                var UserTeam = ((author != null) ? author.GetTeam() : PunTeams.Team.none);
                Mod.Log($"{Type} > [{UserTeam}] \"{UserName}\": \"{text}\" (all: {isForAllPlayers})");
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(Player), nameof(Player.think))]
    static class PlayerThinkPatch {
        static void Prefix(Player __instance, string text) {
            if (Preferences.LogThinkMessages.Value) {
                Mod.Log($"{__instance.name} thinks \"{text}\"");
            }
        }
    }
}
