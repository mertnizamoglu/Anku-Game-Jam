using System;
using ANKU.Animations.Abstracts;
using ANKU.Animations.Concretes;
using ANKU.Combats.Concretes;
using UnityEngine;

namespace ANKU.Controllers.Concretes
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private HealthCombat health;

        private void Update()
        {
            ControlDead();
            // ApplyMove();
        }

        private void ApplyMove()
        {
            this.transform.position = new Vector3(
                transform.position.x,
                Mathf.Sin(Time.time / 0.3f) + 0.4f,
                transform.position.z);
        }

        private void ControlDead()
        {
            if (health.Equals(null)) return;

            if (health.IsDead) Destroy(this.gameObject);
        }
    }
}