using ANKU.Controllers.Abstracts;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ANKU.Controllers.Concretes
{
    public class BulletSpawnController : SpawnerController
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private float bulletSpeed;
        
        public MyInputActions inputActions; 
        
        private IRayController _rayController;
        private InputAction _fire;

        private void Awake()
        {
            inputActions = new MyInputActions();
            _rayController = new RayController(_playerController);
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
            _rayController.SpawnMagic(spawnObject, spawnPoint, bulletSpeed);
        }
        
        private void Fire(InputAction.CallbackContext context)
        {
            _rayController.SendRay();
            
            Spawn();
        }

        private void OnDisable()
        {
            _fire.Disable();
        }
    }
}