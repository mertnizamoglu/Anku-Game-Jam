using System.Collections;
using ANKU.Controllers.Abstracts;
using UnityEngine;

namespace ANKU.Controllers.Concretes
{
    public class EnemySpawnerController : SpawnerController
    {
        [SerializeField] private float difficulty;
        protected override void Start()
        {
            base.Start();
        }

        public void Spawn()
        {
            for (int i = 0; i < difficulty; i++)
            {
                Instantiate(spawnObject, this.transform.position, Quaternion.identity);
            }
        }
    }
}