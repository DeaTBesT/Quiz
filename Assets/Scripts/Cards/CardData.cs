﻿using UnityEngine;

namespace Cards
{
    [System.Serializable]
    public class CardData
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _sprite;

        public string GetID => _id;
        public Sprite GetSprite => _sprite;
    }
}