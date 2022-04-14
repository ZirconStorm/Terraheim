using HarmonyLib;
using UnityEngine;

namespace Terraheim.ArmorEffects
{
    public class SE_HealthBlockBonus : StatusEffect
    {
        public float m_bonus = 0f;

        public void Awake()
        {
            m_name = "Health/Block Increase";
            base.name = "Health/Block Increase";
            m_tooltip = $"Block power increased by <color=cyan>{GetBlockPower() * 100}%</color>. " +
                $"Max HP is increased by <color=cyan>{GetHealthBonus() * 100}</color>.";

        }

        public void SetBonus(float bonus)
        {
            //Log.LogInfo("Setting Bonus: " + bonus);
            m_bonus = bonus;
            m_tooltip = $"Block power increased by <color=cyan>{GetBlockPower() * 100}%</color>. " +
                $"Max HP is increased by <color=cyan>{GetHealthBonus() * 100}</color>.";
        }

        public float GetHealthBonus() { return m_bonus * 2; }

        public float GetBlockPower() { return m_bonus; }
    }
}
