using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ANKU.Controllers.Abstracts
{
 
    public abstract class SpawnerController : MonoBehaviour
    {
        [SerializeField] protected GameObject spawnPoint;
        [SerializeField] protected GameObject spawnObject;

        protected virtual void Start()
        {
            
        }

        protected void Update()
        {
            
        }
    }
}