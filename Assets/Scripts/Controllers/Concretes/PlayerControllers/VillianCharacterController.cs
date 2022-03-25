using System.Collections;
using System.Collections.Generic;
using ANKU.Controllers.Abstracts;
using UnityEngine;

namespace ANKU.Controllers.Concretes
{
    public class VillianCharacterController : PlayerController
    {
        private IRayController _rayController;

        protected override void Awake()
        {
            base.Awake();
            _rayController = new RayController();
        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
            // TODO: Input System Mouse
            _rayController.SendRay();
        }
    }
}