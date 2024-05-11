using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using Vignette = UnityEngine.Rendering.Universal.Vignette;

namespace Game.LV
{
    public class VignetteSystem : MonoBehaviour
    {
        [SerializeField]
        private int _maxLevel = 10;

        [SerializeField]
        private int _level = 0;
        
        [SerializeField]
        private Volume _volume;
        [SerializeField]
        private Vignette _vignette;
        
        [SerializeField]
        private Image _ui;

        private void Awake()
        {
            _volume = GetComponentInChildren<Volume>();
            _volume.profile.TryGet(out _vignette);
            _vignette.intensity.value = 0f;
            
            _ui = GetComponentInChildren<Image>();
        }

        [ContextMenu("Darker")]
        public void SetScreenDarker()
        {
            _level++;

            float startValue = _vignette.intensity.value;
            float endValue = (float)_level / _maxLevel;
            
            DOTween.To(() => startValue, value => _vignette.intensity.value = value, endValue, 2f);
            if (_level == _maxLevel) _ui.DOFade(1f, 2f);
        }

        [ContextMenu("Brighter")]
        public void SetScreenBrighter()
        {
            _level = 0;

            float startValue = _vignette.intensity.value;
            float endValue = (float)_level / _maxLevel;
            
            DOTween.To(() => startValue, value => _vignette.intensity.value = value, endValue, 2f);
            _ui.DOFade(0f, 2f);
        }

        public void Reset()
        {
            _level = 0;
            
            _vignette.intensity.value = (float)_level / _maxLevel;
            _ui.material. color = Color.clear;
        }
    }
}