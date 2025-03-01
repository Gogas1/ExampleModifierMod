using HarmonyLib;
using System.Linq;

namespace ExampleModifierMod;

[HarmonyPatch]
public class Patches {

    // Patches are powerful. They can hook into other methods, prevent them from runnning,
    // change parameters and inject custom code.
    // Make sure to use them only when necessary and keep compatibility with other mods in mind.
    // Documentation on how to patch can be found in the harmony docs: https://harmony.pardeike.net/articles/patching.html
    [HarmonyPatch(typeof(PlayerEnergy), nameof(PlayerEnergy.Consume))]
    [HarmonyPostfix]
    private static void PlayerEnergy_Consume_Postfix(ref float amount) {
        if (ExampleModifierMod.QiRecoilModifierVotes.Any()) {
            Player.i.health.ReceiveRecoverableDamage(Player.i.health.maxHealth.Value / 20 * amount);
        }
    }
}