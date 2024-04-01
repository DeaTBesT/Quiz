using System;
using System.Collections.Generic;
using Card.Entity;
using Level.Data;
using UnityEngine;
using Utils;

namespace Managers
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GridTransform _cardsGrid;
        [SerializeField] private CardEntity _cardPrefab;

        [SerializeField] private UIManager _uiManager;
        [SerializeField] private RotateSpecificSprites _rotaterSpecificSprites;

        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private LevelsManager _levelsManager;
        
        private List<CardEntity> _spawnedCards = new List<CardEntity>();
        
        private void Start()
        {
            if (_sceneLoader != null)
            {
                _sceneLoader.OnStartReload += ClearLevel;
            }
            
            if (_levelsManager != null)
            {
                _levelsManager.OnFinishGame += OnFinishGame;
            }
        }

        private void OnDestroy()
        {
            if (_sceneLoader != null)
            {
                _sceneLoader.OnStartReload -= ClearLevel;
            }
            
            if (_levelsManager != null)
            {
                _levelsManager.OnFinishGame -= OnFinishGame;
            }
        }

        public void GenerateLevel(LevelData levelData, TaskManager taskManager, bool isAnimate)
        {
            ClearLevel();
            
            if (levelData.GetGridSize.x * levelData.GetGridSize.y < levelData.GetCards.Length)
            {
                Debug.LogWarning("Grid less then cards lenght");
                return;
            }
            
            List<SpriteRenderer> renderers = new List<SpriteRenderer>();
            _uiManager.Initialize(levelData, isAnimate);
            taskManager.Initialize(levelData);
            _cardsGrid.GridSize = levelData.GetGridSize;
            
            for (int i = 0; i < levelData.GetCards.Length; i++)
            {
                CardEntity card = Instantiate(_cardPrefab, _cardsGrid.transform);
                _spawnedCards.Add(card);
                card.Initialize(levelData.GetCards[i], taskManager, isAnimate);
                renderers.Add(card.GetRenderer);
            }
            
            _cardsGrid.GenerateGrid();
            _rotaterSpecificSprites.RotateSprites(renderers.ToArray());
        }

        public void ClearLevel()
        {
            foreach (Transform child in _cardsGrid.transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void OnFinishGame()
        {
            foreach (var card in _spawnedCards)
            {
                card.DiactivateCard();
            }
        }
    }
}