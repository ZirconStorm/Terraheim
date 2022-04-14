﻿using HarmonyLib;
using System.Threading;
using UnityEngine;

namespace Terraheim.ArmorEffects
{
    class SE_ThrowingWeaponBonus : StatusEffect
    {
        public float m_damageBonus = 0.05f;

        public void Awake()
        {
            m_name = "Throwing Weapon Bonus";
            base.name = "Throwing Weapon Bonus";
            m_tooltip = "Throwing Damage and Velocity Increased by " + m_damageBonus * 10 + "%";
        }

        public void setDamageBonus(float bonus)
        {
            //Log.LogInfo("Setting Bonus: " + bonus * 10 + "%");
            m_damageBonus = bonus;
            m_tooltip = $"\n\nDamage with throwing weapons is increased by <color=cyan>{getDamageBonus() * 100}%</color>.";
        }

        public float getDamageBonus() { return m_damageBonus; }
    }
}
