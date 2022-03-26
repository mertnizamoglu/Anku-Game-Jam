using System;
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
        [SerializeField] private float fireRate = 4;
        
        public MyInputActions inputActions; 
        
        private IRayController _rayController;
        private InputAction _fire;

        public bool CanFire { get; set; }

        private float timeToFire;

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
        
        protected override void Start()
        {
            base.Start();
            CanFire = true;
        }

        protected override void Update()
        {
            if (Input.GetMouseButtonDown(0) && 
                FindObjectOfType<CharacterChangerController>().playerEnum == PlayerEnum.VILLIAN_CHARACTER_MODE && 
                Time.time >= timeToFire &&
                CanFire)
            { 
                timeToFire = Time.time + 1/fireRate;
                Spawn();
            }

        }

        private void Spawn()
        {
            _rayController.SendRay();
            _rayController.SpawnMagic(spawnObject, spawnPoint, bulletSpeed);
        }
        
        private void Fire(InputAction.CallbackContext context)
        {
       
        }

        private void OnDisable()
        {
            _fire.Disable();
        }
    }
}