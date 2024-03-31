using UnityEngine;

namespace Level.Data
{
    [CreateAssetMenu(fileName = "New LevelsBundleData", menuName = "Levels Bundle Data", order = 1)]
    public class LevelsBundleData : ScriptableObject
    {
        [SerializeField] private LevelData[] _levelsData;

        public LevelData[] GetLevelsData => _levelsData;
    }
}