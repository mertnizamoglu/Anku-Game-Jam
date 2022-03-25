using System.Collections.Generic;
using UnityEngine;

namespace ANKU.Controllers.Concretes
{
    public class SpawnerZone : MonoBehaviour
    {
        [SerializeField] private List<EnemySpawnerController> spawnPoints;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                this.gameObject.SetActive(false);
                
                foreach (var spawner in spawnPoints)
                {
                    spawner.Spawn();
                }
            }
        }
    }
}