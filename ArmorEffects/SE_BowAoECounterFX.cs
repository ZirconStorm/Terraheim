using Terraheim.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace Terraheim.ArmorEffects
{
    class SE_BowAoECounterFX : StatusEffect
    {

        public void Awake()
        {
            m_name = "Wyrdarrow2FX";
            base.name = "Wyrdarrow2FX";
            m_tooltip = "";
        }

        public override void Setup(Character character)
        {
            m_startEffects = new EffectList();
            m_startEffects.m_effectPrefabs = new EffectList.EffectData[] { Data.VFXAoECharged };
            base.Setup(character);
        }

        public override void UpdateStatusEffect(float dt)
        {
            base.UpdateStatusEffect(dt);
            if (!m_character.GetSEMan().HaveStatusEffect("Wyrdarrow2"))
            {
                m_character.GetSEMan().RemoveStatusEffect("Wyrdarrow2FX");
            }
        }
    }
}
