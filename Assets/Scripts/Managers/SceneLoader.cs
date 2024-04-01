using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private GameObject _blackoutPanel;
        [SerializeField] private Image _backoutImage;

        private const float START_ALPHA = 0f;
        private const float ROUTINE_DELAY = 1f;
       
        public Action OnStartReload { get; set; }
        public Action OnReloaded { get; set; }
        
        public void ReloadScene()
        {
            StartCoroutine(ReloadSceneRoutine());
        }

        private IEnumerator ReloadSceneRoutine()
        {
            _blackoutPanel.SetActive(true);
            _backoutImage.color = new Color(_backoutImage.color.r, _backoutImage.color.g, _backoutImage.color.b, START_ALPHA);
            
            _backoutImage.DOFade(1, 0.8f).OnComplete(() =>
            {
                OnStartReload?.Invoke();
            }).SetAutoKill(true);
            
            yield return new WaitForSeconds(ROUTINE_DELAY);
            
            OnReloaded?.Invoke();
            _backoutImage.DOFade(0, 0.8f).OnComplete(() =>
            {
                _blackoutPanel.SetActive(false);
            }).SetAutoKill(true);
        }
    }
}