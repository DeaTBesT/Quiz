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
        [SerializeField] private LevelsBundleData _levelsBundle;

        private TaskManager _taskManager;
        
        public void GenerateLevel(int levelId, TaskManager taskManager)
        {
            foreach (Transform child in _cardsGrid.transform)
            {
                Destroy(child.gameObject);
            }

            LevelData levelData = _levelsBundle.GetLevelsData[levelId];
            
            _taskManager.Initialize(levelData);
            _cardsGrid.GridSize = levelData.GetGridSize;
            
            for (int i = 0; i < levelData.GetCards.Length; i++)
            {
                CardEntity card = Instantiate(_cardPrefab, _cardsGrid.transform);
                card.Initialize(levelData.GetCards[i], taskManager);
            }
            
            _cardsGrid.GenerateGrid();
        }
    }
}