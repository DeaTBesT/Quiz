using System;
using Card.Data;
using Managers;
using UnityEngine;

namespace Card.Entity
{
    public class CardEntity : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;

        private CardData _cardData;
        private TaskManager _taskManager;
        
        public void Initialize(CardData cardData, TaskManager taskManager)
        {
            _taskManager = taskManager;
            _cardData = cardData;
        }

        private void OnMouseDown()
        {
            if (_taskManager.CheckAnswer(_cardData.GetID))
            {
                
            }
        }
    }
}