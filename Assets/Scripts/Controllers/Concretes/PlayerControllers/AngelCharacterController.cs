using System.Collections;
using System.Collections.Generic;
using ANKU.Concretes.Enums;
using ANKU.Controllers.Abstracts;
using UnityEngine;

namespace ANKU.Controllers.Concretes
{
 
    public class AngelCharacterController : PlayerController
    {
        protected override void Start()
        {
            base.Start();
            playerEnum = PlayerEnum.ANGEL_CHARACTER_MODE;
        }
    }
}