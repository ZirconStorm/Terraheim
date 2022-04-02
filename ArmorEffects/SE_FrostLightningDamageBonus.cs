using HarmonyLib;
using System.Threading;
using UnityEngine;

namespace Terraheim.ArmorEffects
{
    class SE_FrostLightningDamageBonus : StatusEffect
    {
        public float m_damageBonus = 0.05f;

        public void Awake()
        {
            m_name = "Frost/Lightning Damage Bonus";
            base.name = "Frost/Lightning Damage Bonus";
            m_tooltip = $"\n\nAll attacks gain <color=cyan>{GetDamageBonus() * 100}%</color> damage as frost and lightning damage.";
        }

        public void SetDamageBonus(float bonus)
        {
            //Log.LogInfo("Setting Bonus: " + bonus * 10 + "%");
            m_damageBonus = bonus;
            m_tooltip = $"\n\nAll attacks gain <color=cyan>{GetDamageBonus() * 100}%</color> damage as frost and lightning damage.";
        }

        public float GetDamageBonus() { return m_damageBonus; }
    }
}
