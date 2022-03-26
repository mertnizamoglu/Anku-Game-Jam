using System;
using System.Collections.Generic;
using ANKU.Combats.Abstracts;
using ANKU.Combats.Concretes;
using ANKU.Enums.Concretes;
using ANKU.Controllers.Abstracts;
using ANKU.UIs.Concretes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ANKU.Controllers.Concretes
{
    public class CharacterChangerController : MonoBehaviour
    {
        [SerializeField] private List<PlayerController> playerControllers;
        [SerializeField] public PlayerEnum playerEnum;
        [SerializeField] private GameObject hand;
        private float currentHealth;

        public IHealth health;
        public MyInputActions inputActions; 
        
        private InputAction _changeCharacter;
        
        private void Awake()
        {
            inputActions = new MyInputActions();
            health = GetComponent<HealthCombat>();
        }

        private void OnEnable()
        {
            _changeCharacter = inputActions.Player.ChangeCharacter;
            _changeCharacter.Enable();
            _changeCharacter.performed += ChangeCharacter;
        }

        private void Start()
        {
            hand.GetComponent<Animator>().SetBool("hand", true);
        }

        private void OnDisable()
        {
            _changeCharacter.Disable();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("AttackHand"))
            {
                this.gameObject.GetComponent<HealthCombat>().TakeDamage(20);
                Debug.Log(this.gameObject.GetComponent<HealthCombat>().CurrentHealth);
            }
        }

        private void ChangeCharacter(InputAction.CallbackContext context)
        {
            if(playerEnum == PlayerEnum.ANGEL_CHARACTER_MODE)
            {
                playerEnum++;
                SetComponentVisibilities(0, false);
                SetComponentVisibilities(1, true);
                
                hand.GetComponent<Animator>().SetBool("hand", false);
                
            }
            else if(playerEnum == PlayerEnum.VILLIAN_CHARACTER_MODE)
            {
                playerEnum--;
                SetComponentVisibilities(0, true);
                SetComponentVisibilities(1, false);
                hand.GetComponent<Animator>().SetBool("hand", true);
            }
        }

        private void SetComponentVisibilities(int index, bool situation)
        {
            playerControllers[index].enabled = situation;
        } 
    }
}