using System.Collections;
using System.Collections.Generic;
using ANKU.Controllers.Abstracts;
using UnityEngine;

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
            
            
            if (Physics.Raycast(_player.rayStartLocation.transform.position, 
                    _player.transform.TransformDirection(_player.camera.transform.forward), 
                        out hit ,100))
            {
                Debug.DrawRay(_player.rayStartLocation.transform.position, 
                    _player.transform.TransformDirection(_player.camera.transform.forward) * hit.distance, Color.green);
            }
        }
    }
}