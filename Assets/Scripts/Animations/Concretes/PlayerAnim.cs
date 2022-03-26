using System.Collections;
using System.Collections.Generic;
using ANKU.Animations.Abstracts;
using UnityEngine;

namespace ANKU.Animations.Concretes
{
    public class PlayerAnim : IAnimation
    {
        private Animator _animator;
        
        public PlayerAnim(Animator animator)
        {
            _animator = animator;
        }
       
        public void PlayAttackAnimation(bool animation)
        {
            _animator.SetTrigger("isAttack");
        }
    }
}
