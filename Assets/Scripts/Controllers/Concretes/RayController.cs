using System.Collections;
using System.Collections.Generic;
using ANKU.Controllers.Abstracts;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ANKU.Controllers.Concretes
{
    public class RayController : IRayController
    {
        private PlayerController _player;

        public RayController(PlayerController player)
        {
            _player = player;
        }

        public void SendRay()
        {
            RaycastHit hit;

            Ray ray = _player.camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawRay(ray.origin, hit.point, Color.red);
            }
            
            if (hit.collider.gameObject.Equals(null)) return;
            
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                _player.crosshairUI.GetComponent<Image>().color = Color.red;
            }
        }
    }
}