using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ANKU.Controllers.Concretes
{
    
    public class DestroyImpact : MonoBehaviour
    {
        private void Update()
        {
            Destroy(this, 5.0f);
        }
    }

}