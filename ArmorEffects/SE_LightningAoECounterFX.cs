using Terraheim.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace Terraheim.ArmorEffects
{
    class SE_LightningAoECounterFX : StatusEffect
    {

        public void Awake()
        {
            m_name = "Njords AngerFX";
            base.name = "Njords AngerFX";
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
            if (!m_character.GetSEMan().HaveStatusEffect("Njords Anger"))
            {
                m_character.GetSEMan().RemoveStatusEffect("Njords AngerFX");
            }
        }
    }
}
