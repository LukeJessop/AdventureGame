using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleNavMeshAgent : MonoBehaviour
{
    
    public Transform[] waypoints;
    private int currentWaypointIndex;
    private NavMeshAgent agent;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[0].position);
        }
    }

    private void Update()
    {
        if (agent.velocity.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (currentWaypointIndex < waypoints.Length - 1)
            {
                currentWaypointIndex++;
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }
            else
            {
                currentWaypointIndex = 0;
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }
        }
    }
}
