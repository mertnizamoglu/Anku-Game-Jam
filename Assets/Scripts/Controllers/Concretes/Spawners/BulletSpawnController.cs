using ANKU.Controllers.Abstracts;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ANKU.Controllers.Concretes
{
    public class BulletSpawnController : SpawnerController
    {   
        public MyInputActions inputActions; 
        
        private InputAction _fire;

        private void Awake()
        {
            inputActions = new MyInputActions();
        }
        
        private void OnEnable()
        {
            _fire = inputActions.Player.Fire;
            _fire.Enable();
            _fire.performed += Fire;
        }

        protected override void Start()
        {
            base.Start();
        }

        private void Spawn()
        {
            Debug.Log(spawnObject.gameObject.name.ToString() + " spawned");
            Instantiate(spawnObject, spawnPoint.transform.position, Quaternion.identity);
        }
        
        private void Fire(InputAction.CallbackContext context)
        {
            Spawn();
        }

        private void OnDisable()
        {
            _fire.Disable();
        }
    }
}