using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent _agent;
    public Transform _player;
    public LayerMask ground;
    public LayerMask player;
    public Vector3 destinationPoint;
    public GameObject sphere;
    public bool destinationPointSet;
    private bool alreadyAttacked;
    public bool playerInSightRange;
    public bool playerInAttackRange;
    public float timeBetweenAttacks;
    public float walkPointRange;
    public float sightRange;
    public float attackRange;

    private void Awake() 
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update() 
    {
        playerInSightRange = Physics.CheckSphere(transform.position,sightRange,player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, player);

        if(!playerInSightRange && !playerInAttackRange )
        {
            Patrol();
        }

        if(playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }

        if(playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }

    }

    void Patrol()
    {
        if(!destinationPointSet)
        {
            SearchWalkPoint();
        }
        
        if(destinationPointSet)
        {
            _agent.SetDestination(destinationPoint);
        }

        Vector3 distanceToDestinationPoint = transform.position - destinationPoint;

        if(distanceToDestinationPoint.magnitude < 1.0f)
        {
            destinationPointSet = false;
        }
    }

    void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }
    void  AttackPlayer()
    {
        _agent.SetDestination(transform.position);

        transform.LookAt(_player);

        if(!alreadyAttacked)
        {
            //logic
            alreadyAttacked = true;
        }
        
    }
    void SearchWalkPoint()
    {
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        destinationPoint = new Vector3(transform.position.x + randomX , transform.position.y , transform.position.z + randomZ);

        if(Physics.Raycast(destinationPoint, -transform.up, 2.0f, ground))
        {
            destinationPointSet = true;
        }

    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }



}
