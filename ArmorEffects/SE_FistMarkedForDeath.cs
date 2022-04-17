﻿using Terraheim.Utility;
using UnityEngine;

namespace Terraheim.ArmorEffects
{
    public class SE_FistMarkedForDeath : StatusEffect
    {
        public int m_activationCount = 0;
        public int m_count = 1;
        public int m_duration = 0;
        public int m_hitsRemaining = 0;
        public float m_damageBonus = 0f;

        public void Awake()
        {
            m_name = "Fist Marked For Death";
            base.name = "Fist Marked For Death";
            m_tooltip = "o fug";
            m_icon = null;
        }

        public void IncreaseCounter()
        {
            m_count++;
            if(m_count >= m_activationCount && !m_character.GetSEMan().HaveStatusEffect("Fist Marked For Death FX"))
            {
                m_character.GetSEMan().AddStatusEffect("Fist Marked For Death FX");
                var audioSource = m_character.GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    audioSource = m_character.gameObject.AddComponent<AudioSource>();
                    audioSource.playOnAwake = false;
                }
                audioSource.PlayOneShot(AssetHelper.SFXMarkedForDeath);
            }
        }

        public void DecreaseHitsRemaining()
        {
            m_hitsRemaining--;
            if(m_hitsRemaining <= 0)
            {
                ClearCounter();
                if (m_character.GetSEMan().HaveStatusEffect("Fist Marked For Death FX"))
                    m_character.GetSEMan().RemoveStatusEffect("Fist Marked For Death FX");
            }
        }

        public void ClearCounter()
        {
            m_count = 0;
            m_hitsRemaining = 0;
        }

        public void SetActivationCount(int count)
        {
            m_activationCount = count;
        }

        public float GetActivationCount() { return m_activationCount; }

        public void SetHitDuration(int dur)
        {
            m_duration = dur;
            m_hitsRemaining = dur;
        }

        public float GetHitDuration() { return m_duration; }

        public void SetDamageBonus(float bns)
        {
            m_damageBonus = bns;
        }

        public float GetDamageBonus() { return m_damageBonus; }
    }
}
