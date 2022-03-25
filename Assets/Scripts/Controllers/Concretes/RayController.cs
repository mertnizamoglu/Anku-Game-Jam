using System.Collections;
using System.Collections.Generic;
using ANKU.Controllers.Abstracts;
using UnityEngine;
using UnityEngine.InputSystem;

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
            // TODO: Input System Mouse

            RaycastHit hit;

            Ray ray = _player.camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawRay(_player.rayStartLocation.transform.position, 
                Debug.DrawRay(ray.origin, hit.point, Color.red);
            }
        }
    }
}