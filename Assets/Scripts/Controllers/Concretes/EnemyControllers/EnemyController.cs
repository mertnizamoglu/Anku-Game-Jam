using System;
using ANKU.Combats.Concretes;
using UnityEngine;

namespace ANKU.Controllers.Concretes
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private HealthCombat health;
        private void Update()
        {
            if(health.Equals(null)) return;
            
            if(health.IsDead) Destroy(this.gameObject);
            
            this.transform.position = new Vector3(
                transform.position.x,
                Mathf.Sin(Time.time / 0.3f) + 0.4f,
                transform.position.z);
        }
    }
}