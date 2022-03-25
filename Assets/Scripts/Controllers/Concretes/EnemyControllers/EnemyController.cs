using System;
using UnityEngine;

namespace ANKU.Controllers.Concretes
{
    public class EnemyController : MonoBehaviour
    {
        private void Update()
        {
            this.gameObject.transform.Translate(Vector3.up * Time.deltaTime * 5.0f);
        }
    }
}