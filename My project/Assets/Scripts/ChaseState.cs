using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    public WatchingState watchingState;
    public bool playerEscaped;
    public NavMeshAgent agent;
    public override State RunCurrentState(GameObject _PlayerRef)
    {
        Vector3 playerPos = _PlayerRef.transform.position;
        agent.SetDestination(playerPos);
        if (playerEscaped)
        {
            return watchingState;
        }
        else
        {
            return this;
        }
    }
}
