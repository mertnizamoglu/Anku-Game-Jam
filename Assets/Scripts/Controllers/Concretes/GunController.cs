using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ANKU.Controllers.Concretes
{
    public class GunController : MonoBehaviour
    {
        [SerializeField] private int ammoCount;

        private int _currentAmmoCount;

        public int CurrentAmmoCount => _currentAmmoCount;

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

        private void OnDisable()
        {
            _fire.Disable();
        }

        private void Start()
        {
            _currentAmmoCount = ammoCount;
        }

        private void Fire(InputAction.CallbackContext context)
        {
            if (_currentAmmoCount <= 0) _currentAmmoCount = 0;
            _currentAmmoCount--;
            Debug.Log(_currentAmmoCount);
        }
    }   
}