using System.Collections;
using System.Collections.Generic;
using ANKU.Controllers.Abstracts;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ANKU.Controllers.Concretes
{
    public class RayController : MonoBehaviour, IRayController
    {
        private PlayerController _player;
        private RaycastHit _hit;

        public RayController(PlayerController player)
        {
            _player = player;
        }

        public void SendRay()
        {
            
            Ray ray = _player.camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out _hit))
            {
                _player.Destination = _hit.point;
                Debug.DrawRay(ray.origin, _hit.point, Color.red);
            }
            else
            {
                _player.Destination = ray.GetPoint(1000);
            }
            
            if (_hit.collider.gameObject.Equals(null)) return;
            
            if (_hit.collider.gameObject.CompareTag("Enemy"))
            {
                _player.crosshairUI.GetComponent<Image>().color = Color.red;
            }
        }

        public void SpawnMagic(GameObject spawnObject, GameObject spawnPosition, float bulletSpeed)
        {
            Debug.Log(spawnObject.gameObject.name.ToString() + " spawned");

            var position = spawnPosition.transform.position;
            var spawnedObj = Instantiate(spawnObject, position, Quaternion.identity);
           
            spawnedObj.GetComponent<Rigidbody>().velocity =
                (_hit.point - position).normalized * bulletSpeed;
        }
    }
}