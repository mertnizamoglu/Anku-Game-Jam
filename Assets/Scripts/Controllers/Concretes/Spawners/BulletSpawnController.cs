using ANKU.Controllers.Abstracts;
using ANKU.Enums.Concretes;
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

        private bool _canFire;

        private void Awake()
        {
            inputActions = new MyInputActions();
            _rayController = new RayController(_playerController);
        }
        
        private void OnEnable()
        {
            _fire = inputActions.Player.Fire;
            _fire.performed += Fire;
            _fire.Enable();
        }

        protected override void Update()
        {
            if (_playerController.playerEnum == PlayerEnum.ANGEL_CHARACTER_MODE)
            {
                _canFire = false;
                Debug.Log("ANGEL'A GIRDIM");
            }
            if (_playerController.playerEnum == PlayerEnum.VILLIAN_CHARACTER_MODE) _canFire = true;

        }

        protected override void Start()
        {
            base.Start();
        }

        private void Spawn()
        {
            _rayController.SendRay();
            _rayController.SpawnMagic(spawnObject, spawnPoint, bulletSpeed);
        }
        
        private void Fire(InputAction.CallbackContext context)
        {
            Debug.Log("CAN FIRE: " + _canFire);
            if (_canFire)
            {
                Spawn();
            }
        }

        private void OnDisable()
        {
            _fire.Disable();
        }
    }
}