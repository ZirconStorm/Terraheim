﻿using Newtonsoft.Json.Linq;
using Terraheim.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace Terraheim.ArmorEffects
{
    class SE_BowAoECounterExhausted : StatusEffect
    {
        static JObject balance = UtilityFunctions.GetJsonFromFile("balance.json");
        public float TTL
        {
            get { return m_ttl; }
            set { m_ttl = value; }
        }

        public void Awake()
        {
            m_name = "Wyrd2 Exhausted";
            base.name = "Wyrd2 Exhausted";
            m_tooltip = "";
        }

        public override void Setup(Character character)
        {
            SetIcon();
            TTL = (float)balance["wyrdExhaustedTTL"];
            Log.LogWarning("Adding Exhaustion");
            base.Setup(character);
        }

        public void SetIcon()
        {
            m_icon = PrefabManager.Cache.GetPrefab<ItemDrop>("HelmetDrake").m_itemData.GetIcon();
        }
    }
}
