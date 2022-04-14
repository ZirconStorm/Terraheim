
using HarmonyLib;

namespace Terraheim.ArmorEffects
{
    class SE_BluntArrows : StatusEffect
    {
        public float m_damageBonus = 0f;

        public void Awake()
        {
            m_name = "Blunt Arrows";
            base.name = "Blunt Arrows";
            m_tooltip = $"Arrows deal an additional <color=cyan>{GetDamageBonus() * 100}%</color> damage as blunt.";
        }

        public void SetDamageBonus(float bonus)
        {
            m_damageBonus = bonus;
            m_tooltip = $"Arrows deal an additional <color=cyan>{GetDamageBonus() * 100}%</color> damage as blunt.";
        }

        public float GetDamageBonus() { return m_damageBonus; }
    }
}