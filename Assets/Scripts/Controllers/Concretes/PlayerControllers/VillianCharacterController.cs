using System.Collections;
using System.Collections.Generic;
using ANKU.Concretes.Enums;
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
            _rayController = new RayController(this);
        }

        protected override void Start()
        {
            base.Start();
            playerEnum = PlayerEnum.VILLIAN_CHARACTER_MODE;
        }

        protected override void Update()
        {
            base.Update();
            _rayController.SendRay();
        }
    }
}