using ANKU.Enums.Concretes;
using ANKU.Controllers.Concretes;
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

        private Vector3 _destination;

        public Vector3 Destination
        {
            get => _destination;
            set => value = _destination;
        }

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