using Card.Data;
using UnityEngine;

namespace Level.Data
{
    [System.Serializable]
    public class LevelData
    {
        [SerializeField] private string _taskTitle;
        [SerializeField] private string _rightAnswerId; 
        [SerializeField] private Vector2Int _gridSize;
        [SerializeField] private CardData[] _cards;
        
        public string GetTaskTitle => _taskTitle;
        public string GetRightAnswerId => _rightAnswerId;
        public Vector2Int GetGridSize => _gridSize;
        public CardData[] GetCards => _cards;
    }
}