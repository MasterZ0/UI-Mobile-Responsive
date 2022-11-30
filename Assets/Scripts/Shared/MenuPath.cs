﻿namespace TritanTest.Shared
{

    public static class MenuPath
    {
        // Base
        public const string ScriptableObjects = "Scriptable Objects/";
        public const string Items = ScriptableObjects + "Items/";

        // Cathegories
        public const string Inputs = ScriptableObjects + "Inputs/";
        public const string Settings = ScriptableObjects + "Settings/";

        public const string SettingsSub = Settings + "Sub/";
        public const string SettingsPlayers = SettingsSub + "Players/";
        public const string SettingsGlobal = Settings + "Global/";
        public const string SettingsEnemies = SettingsSub + "Enemies/";
    }
}