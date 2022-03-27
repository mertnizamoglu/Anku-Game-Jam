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
        [SerializeField] private int _difficultyIndex;
        [SerializeField] private GameObject fill;
        [SerializeField] private GameObject bg;

        private int _difficulty;

        private Slider _slider;
        
        private float _currentFormTime;
        private int _currentLevelIndex;
        private bool IsReachedMaxFormLevel => _currentLevelIndex == totalFormLevels ? true : false;
        public int Difficulty => _difficulty;

        private void Start()
        {            
            _slider = GetComponent<Slider>();
            _difficulty = 1;
        }

        private void Update()
        {
            
            Debug.Log("CURRENT LEVEL INDEX:" + _currentLevelIndex);
            //255, 155, 85
            
            if (_currentLevelIndex == 0) fill.GetComponent<Image>().color = Color.red;
            else if (_currentLevelIndex == 1) fill.GetComponent<Image>().color = Color.grey;
            else if (_currentLevelIndex == 2) fill.GetComponent<Image>().color = Color.black;
            
            if (_currentLevelIndex == 3) bg.GetComponent<Image>().color = Color.black;

            
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
                    _difficulty = _currentLevelIndex * _difficultyIndex;
                    Debug.Log("DIFFICULTY: " + _difficulty);
                }

                if (_currentLevelIndex >= totalFormLevels)
                {
                    _currentLevelIndex = totalFormLevels;
                }
            }
        }
    }
}