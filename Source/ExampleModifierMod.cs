using BepInEx;
using BepInEx.Configuration;
using BossChallengeMod;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleModifierMod;

[BepInDependency(BossChallengeMod.BossChallengeMod.PluginGUID)]
[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class ExampleModifierMod : BaseUnityPlugin {
    public static HashSet<object> QiRecoilModifierVotes = new HashSet<object>();

    private Harmony harmony = null!;

    private void Awake() {
        Log.Init(Logger);
        RCGLifeCycle.DontDestroyForever(gameObject);

        harmony = Harmony.CreateAndPatchAll(typeof(ExampleModifierMod).Assembly);

        BossChallengeMod.BossChallengeMod.Modifiers
            .CreateModifierBuilder<QiRecoilModifier>("qi_recoil", "QiRecoilModifier")
            .BuildAndAdd();

        BossChallengeMod.Global.LocalizationResolver.AddTranslations("en-us", new Dictionary<string, string> {
            { "qi_recoil", "Qi-Recoil" }
        });

        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }

    private void OnDestroy() {
        harmony.UnpatchSelf();
    }
}