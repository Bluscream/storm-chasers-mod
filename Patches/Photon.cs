using System.Reflection;
using System.Text;

namespace StormChasers {

    [HarmonyLib.HarmonyPatch(typeof(OnlineAuthentication), nameof(OnlineAuthentication.authenticate))]
    static class OnlineAuthenticationAuthenticatePatch {
        static void Postfix(OnlineAuthentication __instance) {
            try {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--------------------");
                sb.AppendLine("void OnlineAuthentication::authenticate()");
                sb.Append("- __instance: ").AppendLine(__instance.ToString());
                Mod.Log(sb.ToString());
            } catch (System.Exception ex) {
                Mod.Log($"Exception in patch of void OnlineAuthentication::authenticate():\n{ex}");
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(OnlineAuthentication), nameof(OnlineAuthentication.GetSteamAuthTicket))]
    static class OnlineAuthenticationGetSteamAuthTicketPatch {
        static void Postfix(OnlineAuthentication __instance) {
            try {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--------------------");
                sb.AppendLine("void OnlineAuthentication::GetSteamAuthTicket()");
                sb.Append("- __instance: ").AppendLine(__instance.ToString());
                Mod.Log(sb.ToString());
            } catch (System.Exception ex) {
                Mod.Log($"Exception in patch of void OnlineAuthentication::GetSteamAuthTicket():\n{ex}");
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(OnlineAuthentication), nameof(OnGetAuthTicketForWebApiResponse))]
    static class OnlineAuthenticationOnGetAuthTicketForWebApiResponsePatch {
        public static readonly MethodInfo OnGetAuthTicketForWebApiResponse = typeof(OnlineAuthentication).GetMethod("OnGetAuthTicketForWebApiResponse", BindingFlags.NonPublic);
        static void Postfix(OnlineAuthentication __instance, object __0) { // Steamworks.GetTicketForWebApiResponse_t
            try {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--------------------");
                sb.AppendLine("void OnlineAuthentication::OnGetAuthTicketForWebApiResponse(Steamworks.GetTicketForWebApiResponse_t pCallback)");
                sb.Append("- __instance: ").AppendLine(__instance.ToString());
                sb.Append("- Parameter 0 'pCallback': ").AppendLine(__0.ToString());
                Mod.Log(sb.ToString());
            } catch (System.Exception ex) {
                Mod.Log($"Exception in patch of void OnlineAuthentication::OnGetAuthTicketForWebApiResponse(Steamworks.GetTicketForWebApiResponse_t pCallback):\n{ex}");
            }
        }

    }

    [HarmonyLib.HarmonyPatch(typeof(OnlineAuthentication), nameof(checkDebug))]
    static class OnlineAuthenticationCheckDebugPatch {
        public static readonly MethodInfo checkDebug = typeof(OnlineAuthentication).GetMethod("checkDebug", BindingFlags.NonPublic);
        static void Postfix(OnlineAuthentication __instance) {
            try {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--------------------");
                sb.AppendLine("void OnlineAuthentication::checkDebug()");
                sb.Append("- __instance: ").AppendLine(__instance.ToString());
                Mod.Log(sb.ToString());
            } catch (System.Exception ex) {
                Mod.Log($"Exception in patch of void OnlineAuthentication::checkDebug():\n{ex}");
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(OnlineAuthentication), nameof(AuthenticateWithPlayFab))]
    static class OnlineAuthenticationAuthenticateWithPlayFabPatch {
        public static readonly MethodInfo AuthenticateWithPlayFab = typeof(OnlineAuthentication).GetMethod("AuthenticateWithPlayFab", BindingFlags.NonPublic);
        static void Postfix(OnlineAuthentication __instance, string __0) {
            try {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--------------------");
                sb.AppendLine("void OnlineAuthentication::AuthenticateWithPlayFab(string SteamTicketId)");
                sb.Append("- __instance: ").AppendLine(__instance.ToString());
                sb.Append("- Parameter 0 'SteamTicketId': ").AppendLine(__0?.ToString() ?? "null");
                Mod.Log(sb.ToString());
            } catch (System.Exception ex) {
                Mod.Log($"Exception in patch of void OnlineAuthentication::AuthenticateWithPlayFab(string SteamTicketId):\n{ex}");
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(OnlineAuthentication), nameof(PreparePhoton))]
    static class OnlineAuthenticationPreparePhotonPatch {
        public static readonly MethodInfo PreparePhoton = typeof(OnlineAuthentication).GetMethod("PreparePhoton", BindingFlags.NonPublic);
        static void Postfix(OnlineAuthentication __instance, object __0) { // PlayFab.ClientModels.LoginResult
            try {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--------------------");
                sb.AppendLine("void OnlineAuthentication::PreparePhoton(PlayFab.ClientModels.LoginResult obj)");
                sb.Append("- __instance: ").AppendLine(__instance.ToString());
                sb.Append("- Parameter 0 'obj': ").AppendLine(__0?.ToString() ?? "null");
                Mod.Log(sb.ToString());
            } catch (System.Exception ex) {
                Mod.Log($"Exception in patch of void OnlineAuthentication::PreparePhoton(PlayFab.ClientModels.LoginResult obj):\n{ex}");
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(OnlineAuthentication), nameof(RequestPhotonToken))]
    static class OnlineAuthenticationRequestPhotonTokenPatch {
        public static readonly MethodInfo RequestPhotonToken = typeof(OnlineAuthentication).GetMethod("RequestPhotonToken", BindingFlags.NonPublic);
        static void Postfix(OnlineAuthentication __instance, object __0) { // PlayFab.ClientModels.ExecuteCloudScriptResult
            try {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--------------------");
                sb.AppendLine("void OnlineAuthentication::RequestPhotonToken(PlayFab.ClientModels.ExecuteCloudScriptResult result)");
                sb.Append("- __instance: ").AppendLine(__instance.ToString());
                sb.Append("- Parameter 0 'result': ").AppendLine(__0?.ToString() ?? "null");
                Mod.Log(sb.ToString());
            } catch (System.Exception ex) {
                Mod.Log($"Exception in patch of void OnlineAuthentication::RequestPhotonToken(PlayFab.ClientModels.ExecuteCloudScriptResult result):\n{ex}");
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(OnlineAuthentication), nameof(AuthenticateWithPhoton))]
    static class OnlineAuthenticationAuthenticateWithPhotonPatch {
        public static readonly MethodInfo AuthenticateWithPhoton = typeof(OnlineAuthentication).GetMethod("AuthenticateWithPhoton", BindingFlags.NonPublic);
        static void Postfix(OnlineAuthentication __instance, object __0) { // PlayFab.ClientModels.GetPhotonAuthenticationTokenResult
            try {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--------------------");
                sb.AppendLine("void OnlineAuthentication::AuthenticateWithPhoton(PlayFab.ClientModels.GetPhotonAuthenticationTokenResult obj)");
                sb.Append("- __instance: ").AppendLine(__instance.ToString());
                sb.Append("- Parameter 0 'obj': ").AppendLine(__0?.ToString() ?? "null");
                Mod.Log(sb.ToString());
            } catch (System.Exception ex) {
                Mod.Log($"Exception in patch of void OnlineAuthentication::AuthenticateWithPhoton(PlayFab.ClientModels.GetPhotonAuthenticationTokenResult obj):\n{ex}");
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(OnlineAuthentication), nameof(OnPlayFabError))]
    static class OnlineAuthenticationOnPlayFabErrorPatch {
        public static readonly MethodInfo OnPlayFabError = typeof(OnlineAuthentication).GetMethod("OnPlayFabError", BindingFlags.NonPublic);
        static void Postfix(OnlineAuthentication __instance, object __0) { // PlayFab.PlayFabError
            try {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--------------------");
                sb.AppendLine("void OnlineAuthentication::OnPlayFabError(PlayFab.PlayFabError obj)");
                sb.Append("- __instance: ").AppendLine(__instance.ToString());
                sb.Append("- Parameter 0 'obj': ").AppendLine(__0?.ToString() ?? "null");
                Mod.Log(sb.ToString());
            } catch (System.Exception ex) {
                Mod.Log($"Exception in patch of void OnlineAuthentication::OnPlayFabError(PlayFab.PlayFabError obj):\n{ex}");
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(OnlineAuthentication), nameof(OnlineAuthentication.GetGeneralData))]
        static class OnlineAuthenticationGetGeneralDataPatch {
            static void Postfix(OnlineAuthentication __instance) {
                try {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("--------------------");
                    sb.AppendLine("void OnlineAuthentication::GetGeneralData()");
                    sb.Append("- __instance: ").AppendLine(__instance.ToString());
                    Mod.Log(sb.ToString());
                } catch (System.Exception ex) {
                    Mod.Log($"Exception in patch of void OnlineAuthentication::GetGeneralData():\n{ex}");
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(OnlineAuthentication), nameof(OnlineAuthentication.GetUserData))]
        static class OnlineAuthenticationGetUserDataPatch {
            static void Postfix(OnlineAuthentication __instance) {
                try {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("--------------------");
                    sb.AppendLine("void OnlineAuthentication::GetUserData()");
                    sb.Append("- __instance: ").AppendLine(__instance.ToString());
                    Mod.Log(sb.ToString());
                } catch (System.Exception ex) {
                    Mod.Log($"Exception in patch of void OnlineAuthentication::GetUserData():\n{ex}");
                }
            }

        }
    }
}
