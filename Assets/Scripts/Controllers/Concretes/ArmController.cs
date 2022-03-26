using System;
using ANKU.Animations.Abstracts;
using ANKU.Animations.Concretes;
using ANKU.Enums.Concretes;
using UnityEngine;

namespace ANKU.Controllers.Concretes
{
    
    public class ArmController : MonoBehaviour
    {
        private IAnimation _animation;
        
        private void Awake()
        {
            _animation = new PlayerAnim(GetComponent<Animator>());
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && FindObjectOfType<CharacterChangerController>().playerEnum == PlayerEnum.VILLIAN_CHARACTER_MODE)
            {
                _animation.PlayAttackAnimation(true);
            }
        }
    }
}