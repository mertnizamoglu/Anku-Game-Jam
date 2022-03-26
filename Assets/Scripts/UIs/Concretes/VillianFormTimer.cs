using System;
using System.Collections;
using System.Collections.Generic;
using ANKU.Controllers.Concretes;
using ANKU.Enums.Concretes;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ANKU.UIs.Concretes
{
    public class VillianFormTimer : MonoBehaviour
    {
        // 3 farkli form seviyesi olacak
        // Eger iyi karakterdeysek herhangi bir sikinti olmayacak
        // Eger kotu karakterde oyuncu 5 saniye durursa bir ust seviyeye erisecek ve
        // Eristigi en ust form seviyesi max erisebilecegi seviye olucak
        
        
        [SerializeField] private int totalFormLevels;
        [SerializeField] private float timeToSpendInFormLevel;
        [SerializeField] private CharacterChangerController characterChanger;
        [SerializeField] private TextMeshProUGUI _levelText;

        private Slider _slider;
        
        private float _currentFormTime;
        private int _currentLevelIndex;
        private bool IsReachedMaxFormLevel => _currentLevelIndex == totalFormLevels ? true : false;

        private void Start()
        {            
            _slider = GetComponent<Slider>();
        }

        private void Update()
        {
            _slider.maxValue = timeToSpendInFormLevel;
            _levelText.text = (_currentLevelIndex + 1).ToString();
            
            if (characterChanger.playerEnum == PlayerEnum.VILLIAN_CHARACTER_MODE)
            {
                Debug.Log("REACHED MAX LEVEL: " + IsReachedMaxFormLevel);
                if(!IsReachedMaxFormLevel)
                {
                    _currentFormTime += Time.deltaTime;
                }

                if (IsReachedMaxFormLevel)
                {
                    _slider.value = _currentFormTime;
                }
                
                _slider.value = _currentFormTime;
                
                if (_currentFormTime >= timeToSpendInFormLevel)
                {
                    _currentFormTime = 0.0f;
                    _currentLevelIndex++;
                }

                if (_currentLevelIndex >= totalFormLevels)
                {
                    _currentLevelIndex = totalFormLevels;
                }
            }
        }
    }
}