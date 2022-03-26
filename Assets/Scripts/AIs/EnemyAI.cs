using System.Collections;
using System.Collections.Generic;
using ANKU.Animations.Abstracts;
using ANKU.Animations.Concretes;
using ANKU.Combats.Concretes;
using ANKU.Controllers.Concretes;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private NavMeshAgent _navMeshAgent;
    
    private Animator _animator;
        
    private IAnimation _animation;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animation = new EnemyAnimation(_animator);
    }
    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) >= _navMeshAgent.stoppingDistance)
        {
            _animation.PlayAttackAnimation(false);
            _navMeshAgent.destination = _player.transform.position;
        }

        if (Vector3.Distance(_player.transform.position, transform.position) <= _navMeshAgent.stoppingDistance)
        {
            _animation.PlayAttackAnimation(true);
            this.transform.LookAt(_player.transform);
        }
    }
}
