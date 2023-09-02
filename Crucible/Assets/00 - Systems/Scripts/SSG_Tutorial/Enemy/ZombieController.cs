using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform target;
    
    private Animator animator; 

    void Start()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    private void RotateToTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    void Update()
    {
        MoveToTarget();
        RotateToTarget();
    }
}
