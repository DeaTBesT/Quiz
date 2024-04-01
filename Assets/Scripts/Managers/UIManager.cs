using DG.Tweening;
using Level.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textTask;

        [Space] 
        [SerializeField] private GameObject _restartPanel;
        [SerializeField] private Image _imageRestart;
        [SerializeField] private Button _restartButton;

        [Space]
        [SerializeField] private SceneLoader _sceneLoader;

        [SerializeField] private LevelsManager _levelsManager;
        
        private const float START_ALPHA = 0;

        private void Start()
        {
            _restartButton.onClick.AddListener(OnButtonRestart);

            if (_levelsManager != null)
            {
                _levelsManager.OnFinishGame += FinishGame;
            }

            if (_sceneLoader != null)
            {
                _sceneLoader.OnStartReload += DiactivateRestartPanel;
            }
        }

        private void OnDestroy()
        {
            _restartButton.onClick.RemoveListener(OnButtonRestart);
            
            if (_levelsManager != null)
            {
                _levelsManager.OnFinishGame -= FinishGame;
            }
            
            if (_sceneLoader != null)
            {
                _sceneLoader.OnStartReload -= DiactivateRestartPanel;
            }
        }

        public void Initialize(LevelData levelData, bool isAnimate)
        {
            _textTask.text = levelData.GetTaskTitle;
            
            if (isAnimate)
            {
                _textTask.color = new Color(_textTask.color.r, _textTask.color.g, _textTask.color.b, START_ALPHA);
                _textTask.DOFade(1, 0.5f).SetAutoKill(true);
            }
        }

        private void FinishGame()
        {
            _restartPanel.SetActive(true);
            _imageRestart.color = new Color(_imageRestart.color.r, _imageRestart.color.g, _imageRestart.color.b, START_ALPHA);
            _imageRestart.DOFade(0.7f, 0.1f).SetAutoKill(true);
        }

        private void DiactivateRestartPanel()
        {
            _restartPanel.SetActive(false);
        }
        
        public void OnButtonRestart()
        {
            _sceneLoader.ReloadScene();
        }
    }
}