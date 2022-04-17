using Newtonsoft.Json.Linq;
using Terraheim.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace Terraheim.ArmorEffects
{
    class SE_FireAoECounterExhausted : StatusEffect
    {
        static JObject balance = UtilityFunctions.GetJsonFromFile("balance.json");
        public float TTL
        {
            get { return m_ttl; }
            set { m_ttl = value; }
        }

        public void Awake()
        {
            m_name = "Flame Exhausted";
            base.name = "Flame Exhausted";
            m_tooltip = "";
        }

        public override void Setup(Character character)
        {
            SetIcon();
            TTL = (float)balance["flameExhaustedTTL"];
            Log.LogWarning("Adding Exhaustion");
            base.Setup(character);
        }

        public void SetIcon()
        {
            m_icon = PrefabManager.Cache.GetPrefab<ItemDrop>("HelmetBronze").m_itemData.GetIcon();
        }
    }
}
