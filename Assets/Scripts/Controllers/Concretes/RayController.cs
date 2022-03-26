using System.Collections;
using System.Collections.Generic;
using ANKU.Combats.Concretes;
using ANKU.Controllers.Abstracts;
using ANKU.UIs.Concretes;
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
                
                if (_hit.collider.gameObject.CompareTag("Enemy"))
                {
                    FindObjectOfType<CrosshairUI>().GetComponent<Image>().color = Color.red;
                    _hit.collider.gameObject.GetComponent<HealthCombat>().TakeDamage(20.0f);
                }
            }
        }

        public void SpawnMagic(GameObject spawnObject, GameObject spawnPosition, float bulletSpeed, float arcRange = 1)
        {
            if(_hit.point.Equals(Vector3.zero)) return;
            Debug.Log(spawnObject.gameObject.name.ToString() + " spawned");

            var position = spawnPosition.transform.position;
            var spawnedObj = Instantiate(spawnObject, position, Quaternion.identity);
            

            spawnedObj.GetComponent<Rigidbody>().velocity =
                (_hit.point - position).normalized * bulletSpeed;
             iTween.PunchPosition(spawnedObj, new Vector3 (Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2));
        }
    }
}