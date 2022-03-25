using System.Collections;
using System.Collections.Generic;
using ANKU.Enums.Concretes;
using ANKU.Controllers.Abstracts;
using UnityEngine;

namespace ANKU.Controllers.Concretes
{
    public class VillianCharacterController : PlayerController
    {

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            base.Start();
            playerEnum = PlayerEnum.VILLIAN_CHARACTER_MODE;
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}