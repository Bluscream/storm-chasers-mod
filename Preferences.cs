using MelonLoader;

namespace StormChasers {
    internal static class Preferences {
        public static MelonPreferences_Entry<bool> SkipIntros { get; private set; }
        public static MelonPreferences_Entry<bool> SpoofFolderHashes { get; private set; }
        public static MelonPreferences_Entry<bool> SpoofDebug { get; private set; }
        public static MelonPreferences_Entry<bool> SpoofBeta { get; private set; }
        public static MelonPreferences_Entry<bool> EnableLogging { get; private set; }
        public static MelonPreferences_Category SpoofedFolderHashes { get; private set; }

        public static void Init() {
            var category = MelonPreferences.CreateCategory(baseCategoryName);
            EnableLogging = category.CreateEntry(nameof(EnableLogging), true, is_hidden:true);
            SkipIntros = category.CreateEntry(nameof(SkipIntros), true);
            SpoofFolderHashes = category.CreateEntry(nameof(SpoofFolderHashes), true);
            SpoofDebug = category.CreateEntry(nameof(SpoofDebug), false);
            SpoofBeta = category.CreateEntry(nameof(SpoofBeta), false);

            SpoofedFolderHashes = MelonPreferences.CreateCategory(spoofedFolderHashesName);
            SpoofedFolderHashes.CreateEntry("Managed/$", "63c434b864ff270ce9fef43917dc86212a6e8b9e6cbfd5a9d54aae1c5341502f");
            SpoofedFolderHashes.CreateEntry("Plugins/x86_64/$", "0afaa40682693c887a168878a20848f7f3db5801dc9b75da671b39041e2e8bcf");

            MelonPreferences.Save();
        }

        private static readonly string baseCategoryName = "StormChasers";
        private static readonly string spoofedFolderHashesName = "SpoofedFolderHashes";
    }
}