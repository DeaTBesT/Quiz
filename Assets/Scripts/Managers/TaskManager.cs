using System;
using Level.Data;

namespace Managers
{
    public class TaskManager
    {
        public Action OnRightAnswer { get; set; }
        
        private LevelData _levelData;
        
        public TaskManager()
        {
            
        }

        public TaskManager(LevelData levelData)
        {
            _levelData = levelData;
        }

        public void Initialize(LevelData levelData)
        {
            _levelData = levelData;
        }
        
        public bool CheckAnswer(string answerId)
        {
            if (answerId == _levelData.GetRightAnswerId)
            {
                OnRightAnswer?.Invoke();
                return true;
            }

            return false;
        }
    }
}