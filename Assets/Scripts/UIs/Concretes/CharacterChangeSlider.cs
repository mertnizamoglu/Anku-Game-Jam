using System;
using UnityEngine;
using UnityEngine.UI;

namespace ANKU.UIs.Concretes
{
    public class CharacterChangeSlider : MonoBehaviour
    {
        [SerializeField] private float changeTime;
        private Slider _slider;

        private float _currentTime;

        public bool IsReachedMaxValue => _currentTime >= changeTime;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            _slider.maxValue = changeTime;
        }

        private void Update()
        {
            AdjustSlider();
            TryCharacterChangment();
        }

        private void TryCharacterChangment()
        {
            if (Input.GetKeyDown(KeyCode.Tab) && IsReachedMaxValue)
            {
                _currentTime = 0.0f;
            }
        }

        private void AdjustSlider()
        {
            _currentTime += Time.deltaTime;
            _slider.value = _currentTime;
            
            if (_currentTime >= changeTime) _currentTime = changeTime;
        }
    }
}