using Card.Data;
using DG.Tweening;
using Managers;
using UnityEngine;

namespace Card.Entity
{
    public class CardEntity : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private ParticleSystem _starsParticle;
         
        private CardData _cardData;
        private TaskManager _taskManager;

        private bool _isBouncing = false;
        private bool _isActivate = true;
        
        public SpriteRenderer GetRenderer => _renderer;
        
        public void Initialize(CardData cardData, TaskManager taskManager, bool isAnimate)
        {
            _taskManager = taskManager;
            _cardData = cardData;

            _renderer.sprite = cardData.GetSprite;

            if (isAnimate)
            {
                transform.DOMoveY(transform.position.y + 1, 0.5f).SetEase(Ease.InBounce).SetAutoKill(true);
            }
        }

        private void OnMouseDown()
        {
            if ((_isBouncing) || (!_isActivate))
            {
                return;
            }
            
            if (_taskManager.CheckAnswer(_cardData.GetID))
            {
                _starsParticle.Play();
            }

            _isBouncing = true;
            _renderer.transform.DOPunchPosition(Vector2.right, 1f).SetEase(Ease.InBounce)
                .OnComplete(() => _isBouncing = false).SetAutoKill(true);
        }

        public void DiactivateCard()
        {
            _isActivate = false;
        }
    }
}