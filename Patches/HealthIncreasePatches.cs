using HarmonyLib;
using Terraheim.ArmorEffects;

namespace Terraheim.Patches
{
    [HarmonyPatch(typeof(Player), "GetTotalFoodValue")]
    class HealthIncreasePatches
    {

        public static void Postfix(Player __instance, ref float hp, ref float stamina)
        {
            //Log.LogInfo("Total Val Increasing HP");
            if (__instance.GetSEMan().HaveStatusEffect("Health Increase"))
            {
                //Log.LogInfo($"Total Val Has Effect HP${hp}");
                SE_HealthIncrease effect = __instance.GetSEMan().GetStatusEffect("Health Increase") as SE_HealthIncrease;
                hp += hp * effect.getHealthBonus();
                //Log.LogInfo($"Total Val Modded HP${hp} from effect ${effect.getHealthBonus()}");
            }

            //Log.LogInfo("Total Val Increasing HP v2");
            if (__instance.GetSEMan().HaveStatusEffect("Health/Block Increase"))
            {
                //Log.LogInfo($"Total Val Has Effect HP${hp}");
                SE_HealthBlockBonus effect = __instance.GetSEMan().GetStatusEffect("Health/Block Increase") as SE_HealthBlockBonus;
                hp += hp * effect.GetHealthBonus();
                //Log.LogInfo($"Total Val Modded HP${hp} from effect ${effect.GetHealthBonus()}");
            }
        }
    }

    [HarmonyPatch(typeof(Player), "GetBaseFoodHP")]
    public class HealthIncreasePatches_BaseFoodHP
    {

        public static void Postfix(Player __instance, ref float __result)
        {
            if (__instance.GetSEMan().HaveStatusEffect("Health Increase"))
            {
                //Log.LogMessage($"Base Food HP Has Effect HP${__result}");
                SE_HealthIncrease effect = __instance.GetSEMan().GetStatusEffect("Health Increase") as SE_HealthIncrease;
                __result += __result * effect.getHealthBonus();
                //Log.LogMessage($"Base Food HP Modded HP${__result}, from effect ${effect.getHealthBonus()}");
            }
            if(__instance.GetSEMan().HaveStatusEffect("Health/Block Increase"))
            {
                //Log.LogMessage($"Base Food HP Has Effect HP${__result}");
                SE_HealthBlockBonus effect = __instance.GetSEMan().GetStatusEffect("Health/Block Increase") as SE_HealthBlockBonus;
                __result += __result * effect.GetHealthBonus();
                //Log.LogMessage($"Base Food HP Modded HP${__result}, from effect ${effect.GetHealthBonus()}");
            }
        }
    }
}
