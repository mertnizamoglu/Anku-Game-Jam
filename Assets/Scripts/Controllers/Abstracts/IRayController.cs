using UnityEngine;

namespace ANKU.Controllers.Abstracts
{
    public interface IRayController
    {
        void SendRay();
        void SpawnMagic(GameObject spawnObject, GameObject spawnPosition, float bulletSpeed);
    }
}