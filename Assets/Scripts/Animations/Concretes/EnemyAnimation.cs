using System.Collections;
using System.Collections.Generic;
using ANKU.Animations.Abstracts;
using UnityEngine;

namespace ANKU.Animations.Concretes
{
    public class EnemyAnimation : IAnimation
    {
        private Animator _animator;
        
        public EnemyAnimation(Animator animator)
        {
            _animator = animator;
        }

        public void PlayAttackAnimation(bool animation)
        {
            _animator.SetBool("isAttack", animation);
        }
    }

}