using Newtonsoft.Json.Linq;
using Terraheim.Utility;
using UnityEngine;

namespace Terraheim.ArmorEffects
{
    class SE_BowMarkedForDeathFX : StatusEffect
    {
        static JObject balance = UtilityFunctions.GetJsonFromFile("balance.json");

        public void Awake()
        {
            m_name = "Bow Marked For Death FX";
            base.name = "Bow Marked For Death FX";
            m_tooltip = "";
            m_icon = null;
        }

        public override void Setup(Character character)
        {
            if ((bool)balance["enableMarkedForDeathFXBow"])
            {
                m_startEffects = new EffectList();
                m_startEffects.m_effectPrefabs = new EffectList.EffectData[] { Data.VFXMarkedForDeath };
            }
            base.Setup(character);
        }
    }
}
