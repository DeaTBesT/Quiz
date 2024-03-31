using System;
using UnityEngine;

namespace Managers
{
    public class LevelsManager : MonoBehaviour
    {
        [SerializeField] private int _currentLevel = 0;
        [SerializeField] private LevelGenerator _levelGenerator;

        private TaskManager _taskManager;
        
        public int GetCurrentLevel => _currentLevel;

        private void Start()
        {
            StartLevel();
        }

        private void OnDestroy()
        {
            if (_taskManager == null)
            {
                return;
            }
            
            _taskManager.OnRightAnswer -= OnFinishLevel;
        }

        private void StartLevel()
        {
            if (_taskManager == null)
            {
                _taskManager = new TaskManager();
                _taskManager.OnRightAnswer += OnFinishLevel;
            }

            _levelGenerator.GenerateLevel(_currentLevel, _taskManager);
        }
        
        private void OnFinishLevel()
        {
            _currentLevel++;
            StartLevel();
        }
    }
}