using System.Collections;
using System.Collections.Generic;
using ANKU.Controllers.Concretes;
using ANKU.Enums.Concretes;
using UnityEngine;
using UnityEngine.UI;

namespace ANKU.UIs.Concretes
{
    public class VillianFormTimer : MonoBehaviour
    {
        [SerializeField] private float changeTime;
        [Range(0, 100)]
        [SerializeField] private float timeRangeBetweenForms;
        [SerializeField] private List<float> formLevelsRange;

        private Slider _slider;

        private int _levelCount;
        private float _currentTime;
        private int _intCurrentTime;
        private bool _canIn = false;
        private bool _isChanged = false;

        public bool IsReachedMaxValue => _currentTime >= formLevelsRange[formLevelsRange.Count - 1];

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            _slider.maxValue = changeTime;
            _levelCount = formLevelsRange.Count;

            StartCoroutine(ChangeLevelTimer());
        }

        private void Update()
        {
            AdjustSlider();

          
        }

        private void AdjustSlider()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= changeTime) _currentTime = changeTime;
            if (_currentTime >= 1) _canIn = true;
            
            _intCurrentTime = (int)(_currentTime);
            Debug.Log("CURRENT TIME: " + _intCurrentTime);

            // if (_intCurrentTime % 5 == 0 && _canIn &&!_isChanged)
            // {
            //     _isChanged = true;
            //     _levelCount++;
            //     Debug.Log("CURRENT LEVEL: " + _levelCount);
            // }
        }

        private IEnumerator ChangeLevelTimer()
        {

            if (_intCurrentTime % 5 == 0)
            {
                _levelCount++;
                Debug.Log("CURRENT LEVEL: " + _levelCount);
            }
            yield return new WaitForSeconds(5.0f);
            
            if(FindObjectOfType<CharacterChangerController>().playerEnum == PlayerEnum.ANGEL_CHARACTER_MODE) 
                yield break;
            
            else if (FindObjectOfType<CharacterChangerController>().playerEnum == PlayerEnum.VILLIAN_CHARACTER_MODE)
                StartCoroutine(ChangeLevelTimer());
            
            
        }
    }
}