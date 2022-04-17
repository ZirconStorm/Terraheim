using HarmonyLib;
using System.Threading;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace Terraheim.ArmorEffects
{
    class SE_BowDeathMark : StatusEffect
    {
        public float m_damageBonus = 0.05f;
        public int m_threshold = 0;
        public int m_duration = 0;
        public bool m_lastHitBow = false;

        public void Awake()
        {
            m_name = "Bow Death Mark";
            base.name = "Bow Death Mark";
            m_tooltip = $"Hit an enemy {m_threshold} times with bowshots to Mark them for death. The next {(m_duration > 1 ? $"{m_duration} hits" : "hit")} against a Marked enemy deals {m_damageBonus}x damage.";
            m_icon = null;
        }

        public void SetIcon()
        {
            m_icon = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorBarbarianBronzeHelmetJD").m_itemData.GetIcon();
        }

        public void SetLastHitBow(bool hit) { m_lastHitBow = hit; }
        public bool GetLastHitBow() { return m_lastHitBow; }

        public void SetDamageBonus(float bonus)
        {
            //Log.LogInfo("Setting Bonus: " + bonus * 10 + "%");
            m_damageBonus = bonus;
            m_tooltip = $"Hit an enemy {m_threshold} times with bowshots to Mark them for death. The next {(m_duration > 1 ? $"{m_duration} hits" : "hit")} against a Marked enemy deals {m_damageBonus}x damage.";
        }

        public float GetDamageBonus() { return m_damageBonus; }

        public void SetHitDuration(int dur)
        {
            //Log.LogInfo("Setting Bonus: " + bonus * 10 + "%");
            m_duration = dur;
            m_tooltip = $"Hit an enemy {m_threshold} times with bowshots to Mark them for death. The next {(m_duration > 1 ? $"{m_duration} hits" : "hit")} against a Marked enemy deals {m_damageBonus}x damage.";
        }

        public int GetHitDuration() { return m_duration; }

        public void SetThreshold(int threshold)
        {
            //Log.LogInfo("Setting Bonus: " + bonus * 10 + "%");
            m_threshold = threshold;
            m_tooltip = $"Hit an enemy {m_threshold} times with bowshots to Mark them for death. The next {(m_duration > 1 ? $"{m_duration} hits" : "hit")} against a Marked enemy deals {m_damageBonus}x damage.";
        }

        public int GetThreshold() { return m_threshold; }
    }
}
