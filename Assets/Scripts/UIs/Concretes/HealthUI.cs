using System;
using System.Collections;
using System.Collections.Generic;
using ANKU.Combats.Concretes;
using UnityEngine;
using UnityEngine.UI;

namespace ANKU.UIs.Concretes
{

    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private HealthCombat playerHealth;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            if(playerHealth.IsDead) return;
            _slider.value = playerHealth.CurrentHealth;

        }
    }
}