using System;
using UnityEngine;

namespace Game.Shop
{
    [CreateAssetMenu(fileName = "Currency", menuName = "Custom Assets/Currency")]
    [Serializable]
    public class Currency : ScriptableObject
    {
        [SerializeField] protected Sprite _sprite;
        [SerializeField] protected string _name;

        public Sprite Sprite => _sprite;
        public string Name => _name;
    }
}