using ANKU.Concretes.Enums;
using ANKU.UIs.Concretes;
using UnityEngine;

namespace ANKU.Controllers.Abstracts
{
    public abstract class PlayerController : MonoBehaviour
    {
        [Header("RAYCAST CONTROL")]
        [Space(20)]
        public Camera camera;
        public CrosshairUI crosshairUI;
        [Header("MODE")]
        [Space(20)]
        public PlayerEnum playerEnum;

        protected virtual void Awake()
        {
            
        }
        
        protected virtual void Start()
        {
            
        }

        protected virtual void Update()
        {
            
        }

    }
}
