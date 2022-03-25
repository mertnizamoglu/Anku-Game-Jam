using System.Collections.Generic;
using ANKU.Concretes.Enums;
using ANKU.Controllers.Abstracts;
using ANKU.Controllers.Concretes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;

namespace ANKU.Concretes.Controllers
{
    public class CharacterChangerController : MonoBehaviour
    {
        [SerializeField] private List<PlayerController> _playerControllers;

        [SerializeField] private PlayerEnum playerEnum;

        public MyInputActions inputActions; 
        
        private InputAction _changeCharacter;
        
        private void Awake()
        {
            inputActions = new MyInputActions();
        }

        private void OnEnable()
        {
            _changeCharacter = inputActions.Player.ChangeCharacter;
            _changeCharacter.Enable();
            _changeCharacter.performed += ChangeCharacter;
        }

        private void OnDisable()
        {
            _changeCharacter.Disable();
        }

        private void ChangeCharacter(InputAction.CallbackContext context)
        {
            Debug.Log("CHARACTER CHANGED");
            
            if(playerEnum == PlayerEnum.ANGEL_CHARACTER_MODE)
            {
                playerEnum++;
                SetComponentVisibilities(0, false);
                SetComponentVisibilities(1, true);
                
                if(_playerControllers[1].GetComponent<VillianCharacterController>().GunController == null) return;
                _playerControllers[1].GetComponent<VillianCharacterController>().GunController.gameObject.SetActive(true);
                
            }
            else if(playerEnum == PlayerEnum.VILLIAN_CHARACTER_MODE)
            {
                playerEnum--;
                SetComponentVisibilities(0, true);
                SetComponentVisibilities(1, false);
                
                if(_playerControllers[1].GetComponent<VillianCharacterController>().GunController == null) return;
                _playerControllers[1].GetComponent<VillianCharacterController>().GunController.gameObject.SetActive(false);
            }
        }

        private void SetComponentVisibilities(int index, bool situation)
        {
            _playerControllers[index].enabled = situation;
            
        }
    }
}