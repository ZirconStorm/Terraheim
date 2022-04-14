using Terraheim.Utility;
using UnityEngine;
using Jotunn.Managers;

namespace Terraheim.ArmorEffects
{
    class SE_BowAoECounter : StatusEffect
    {
        public float m_damageBonus = 0.05f;
        public int m_activationCount = 0;
        public int m_count = 0;
        public int m_maxCount = 12;
        public float m_aoeSize = 0f;
        public GameObject m_lastProjectile;

        public void Awake()
        {
            m_name = "Wyrdarrow2";
            base.name = "Wyrdarrow2";
            m_tooltip = "Hitting an enemy " + m_activationCount + " times charges you. The next bowshot will deal " 
                + m_damageBonus * 100 + "% of damage dealt as spirit/frost damage in a " + m_aoeSize + "m radius.";
        }

        public void IncreaseCounter()
        {
            if (m_character.GetSEMan().HaveStatusEffect("Wyrd Exhausted"))
                return;

            m_count += 1;
            if (m_count >= m_maxCount)
                m_count = m_maxCount;

            if(m_count >= m_activationCount && !m_character.GetSEMan().HaveStatusEffect("Wyrdarrow2FX"))
            {
                Log.LogInfo("Adding status");
                m_character.GetSEMan().AddStatusEffect("Wyrdarrow2FX");
                var audioSource = m_character.GetComponent<AudioSource>();
                if(audioSource == null)
                {
                    audioSource = m_character.gameObject.AddComponent<AudioSource>();
                    audioSource.playOnAwake = false;
                }
                audioSource.PlayOneShot(AssetHelper.AoEReady);
            } 
            else
            {
                Log.LogInfo($"{m_count} >= {m_activationCount} && !{m_character.GetSEMan().HaveStatusEffect("Wyrdarrow2FX")}");
            }
            m_name = base.name + " " + m_count + " / " + m_activationCount;
        }

        public void ClearCounter()
        {
            m_count -= m_activationCount;
            if(m_count < m_activationCount && m_character.GetSEMan().HaveStatusEffect("Wyrdarrow2FX"))
            {
                m_character.GetSEMan().RemoveStatusEffect("Wyrdarrow2FX");
                m_character.GetSEMan().AddStatusEffect("Wyrd2 Exhausted");
            }

            if(m_count < 1)
                m_name = base.name;
            else
                m_name = base.name + " " + m_count + " / " + m_activationCount;
        }

        public void SetIcon()
        {
            m_icon = PrefabManager.Cache.GetPrefab<ItemDrop>("HelmetDrake").m_itemData.GetIcon();
        }

        public void SetDamageBonus(float bonus)
        {
            m_damageBonus = bonus;
            m_tooltip = "Hitting an enemy " + m_activationCount + " times charges you. The next fully charged attack with bows will deal "
                + m_damageBonus * 100 + "% of damage dealt as spirit/frost damage in a " + m_aoeSize + "m radius.";
        }

        public float GetDamageBonus() { return m_damageBonus; }

        public void SetActivationCount(int count)
        {
            m_activationCount = count;
            m_tooltip = "Hitting an enemy " + m_activationCount + " times charges you. The next fully charged attack with bows will deal "
                + m_damageBonus * 100 + "% of damage dealt as spirit/frost damage in a " + m_aoeSize + "m radius.";
        }

        public float GetActivationCount() { return m_activationCount; }

        public void SetAoESize(float aoe)
        {
            m_aoeSize = aoe;
            m_tooltip = "Hitting an enemy " + m_activationCount + " times charges you. The next fully charged attack with bows will deal "
                + m_damageBonus * 100 + "% of damage dealt as spirit/frost damage in a " + m_aoeSize + "m radius.";
        }

        public float GetAoESize() { return m_aoeSize; }

        public void SetLastProjectile(GameObject proj){ m_lastProjectile = proj; }

        public GameObject GetLastProjectile() { return m_lastProjectile; }
    }
}
