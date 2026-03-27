using AlwaysMusicChance.Patches;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace AlwaysMusicChance;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class MusicChancePlugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    private readonly Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
    private static MusicChancePlugin Instance;

    private void Awake()
    {
        // Plugin startup logic
        Logger = BepInEx.Logging.Logger.CreateLogSource(MyPluginInfo.PLUGIN_GUID);
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        if (Instance == null)
        {
            Instance = this;
        }
        harmony.PatchAll(typeof(MusicChancePlugin));
        harmony.PatchAll(typeof(MusicChancePatch));
    }
}
