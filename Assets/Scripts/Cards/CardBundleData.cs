using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data", order = 1)]
    public class CardBundleData : ScriptableObject
    {
        [SerializeField] private CardData[] _cardBundle;

        public CardData[] GetCardBundle => _cardBundle;
    }
}