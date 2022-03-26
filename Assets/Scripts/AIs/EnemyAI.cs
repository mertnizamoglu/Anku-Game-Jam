using System.Collections;
using System.Collections.Generic;
using ANKU.Combats.Concretes;
using ANKU.Controllers.Concretes;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private NavMeshAgent _navMeshAgent;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) >= _navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.destination = _player.transform.position;
        }

        if (Vector3.Distance(_player.transform.position, transform.position) <= _navMeshAgent.stoppingDistance)
        {
            this.transform.LookAt(_player.transform);
        }
    }
}
