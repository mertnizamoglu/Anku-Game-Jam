using System.Collections;
using System.Collections.Generic;
using ANKU.Combats.Abstracts;
using UnityEngine;

namespace ANKU.Combats.Concretes
{
    public class HealthCombat : MonoBehaviour, IHealth
    {
        [SerializeField] private float _currentHealth;

        public bool IsDead => _currentHealth <= 0;
        public float CurrentHealth => _currentHealth;

        public HealthCombat(float currentHealth)
        {
            _currentHealth = currentHealth;
        }
        
        public void TakeDamage(float damage)
        {
            if(IsDead) return;
            if (!IsDead) _currentHealth -= damage;
        }
    }   
}