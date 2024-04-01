using System;
using Level.Data;
using UnityEngine;

namespace Managers
{
    public class LevelsManager : MonoBehaviour
    {
        [SerializeField] private int _currentLevel = 0;
        [SerializeField] private LevelGenerator _levelGenerator;
        [SerializeField] private LevelsBundleData _levelsBundle;
        [SerializeField] private SceneLoader _sceneLoader;
        
        private TaskManager _taskManager;

        private const int START_LEVEL_ID = 0;
        
        public int GetCurrentLevel => _currentLevel;
        
        public Action OnFinishGame { get; set; }
        
        private void Start()
        {
            StartLevel();
            
            if (_sceneLoader != null)
            {
                _sceneLoader.OnReloaded += OnGameReloaded;
            }
        }

        private void OnDestroy()
        {
            if (_taskManager == null)
            {
                return;
            }
            
            _taskManager.OnRightAnswer -= OnFinishLevel;
            
            if (_sceneLoader == null)
            {
                return;
            }
            
            _sceneLoader.OnReloaded -= OnGameReloaded;
        }

        private void StartLevel()
        {
            if (_taskManager == null)
            {
                _taskManager = new TaskManager();
                _taskManager.OnRightAnswer += OnFinishLevel;
            }
            
            _levelGenerator.GenerateLevel(_levelsBundle.GetLevelsData[_currentLevel], _taskManager, _currentLevel == START_LEVEL_ID);
        }
        
        private void OnFinishLevel()
        {
            if (_currentLevel + 1 >= _levelsBundle.GetLevelsData.Length)
            {
                FinishGame();
                return;
            }
            
            _currentLevel++;
            
            Invoke(nameof(StartLevel), 1f);
        }

        private void FinishGame()
        {
            OnFinishGame?.Invoke();
        }

        private void OnGameReloaded()
        {
            _currentLevel = 0;
            StartLevel();
        }
    }
}