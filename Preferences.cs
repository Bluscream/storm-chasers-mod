﻿using MelonLoader;

namespace StormChasers {
    internal static class Preferences {
        public static MelonPreferences_Entry<bool> EnableLogging { get; private set; }
        public static MelonPreferences_Entry<bool> SkipIntros { get; private set; }
        public static MelonPreferences_Entry<bool> SpoofFolderHashes { get; private set; }
        public static MelonPreferences_Entry<bool> SpoofDebug { get; private set; }
        public static MelonPreferences_Entry<bool> SpoofLegit { get; private set; }
        public static MelonPreferences_Entry<bool> SpoofModded { get; private set; }
        public static MelonPreferences_Entry<bool> SpoofDirSearch { get; private set; }
        public static MelonPreferences_Entry<bool> SpoofLatest { get; private set; }
        public static MelonPreferences_Entry<bool> SpoofBeta { get; private set; }
        public static MelonPreferences_Category SpoofedFolderHashes { get; private set; }

        public static void Init() {
            var category = MelonPreferences.CreateCategory(baseCategoryName);
            EnableLogging = category.CreateEntry(nameof(EnableLogging), true, "Enable Logging", "Wether to enable logging to MelonLoader's Console", is_hidden:true);
            SkipIntros = category.CreateEntry(nameof(SkipIntros), true, "Skip Intros", "Wether to automatically load the main menu on game startup instead of going through the splash screens");
            SpoofFolderHashes = category.CreateEntry(nameof(SpoofFolderHashes), true, "Spoof Folder Hashes", "Folder hashes are used to disallow joining online games with a modded game");
            SpoofDebug = category.CreateEntry(nameof(SpoofDebug), false, "Spoof GlobalValues.isDebug", "isDebug allows you to use debug functionality left in the game by the dev");
            SpoofLegit = category.CreateEntry(nameof(SpoofLegit), false, "Spoof MainUIMenu.isLegit()", "DRM Shit");
            SpoofModded = category.CreateEntry(nameof(SpoofModded), false, "Spoof MainUIMenu.isModded()", "DRM Shit");
            SpoofDirSearch = category.CreateEntry(nameof(SpoofDirSearch), false, "Spoof MainUIMenu.DirSearch()", "DRM Shit");
            SpoofLatest = category.CreateEntry(nameof(SpoofLatest), false, "Spoof MainUIMenu.isLatest()");
            SpoofBeta = category.CreateEntry(nameof(SpoofBeta), false, "Spoof MainUIMenu.isBeta()");

            SpoofedFolderHashes = MelonPreferences.CreateCategory(spoofedFolderHashesName);
            SpoofedFolderHashes.CreateEntry("Managed/$", "63c434b864ff270ce9fef43917dc86212a6e8b9e6cbfd5a9d54aae1c5341502f");
            SpoofedFolderHashes.CreateEntry("Plugins/x86_64/$", "0afaa40682693c887a168878a20848f7f3db5801dc9b75da671b39041e2e8bcf");

            MelonPreferences.Save();
        }

        private static readonly string baseCategoryName = "StormChasers";
        private static readonly string spoofedFolderHashesName = "SpoofedFolderHashes";
    }
}