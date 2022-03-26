using System;
using System.Collections;
using ANKU.Controllers.Abstracts;
using ANKU.UIs.Concretes;
using UnityEngine;

namespace ANKU.Controllers.Concretes
{
    public class EnemySpawnerController : SpawnerController
    {
        private VillianFormTimer _villianFormTimer;

        private void Awake()
        {
            _villianFormTimer = FindObjectOfType<VillianFormTimer>();
        }

        protected override void Start()
        {
            base.Start();
        }

        public void Spawn()
        {
            for (int i = 0; i < _villianFormTimer.Difficulty; i++)
            {
                Instantiate(spawnObject, this.transform.position, Quaternion.identity);
            }
        }
    }
}