using System.Collections;
using ANKU.Controllers.Abstracts;
using UnityEngine;

namespace ANKU.Controllers.Concretes
{
    public class EnemySpawnerController : SpawnerController
    {
        [SerializeField] private float spawnRate;
        protected override void Start()
        {
            base.Start();
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(spawnRate);

            StartCoroutine(Spawn());
        }
    }
}