using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    public ListenState lisenState;
    public bool playerEscaped;

    public override State RunCurrentState(GameObject _PlayerRef)
    {
        Vector3 playerPos = _PlayerRef.transform.position;
        agent.stoppingDistance = 0;
        agent.SetDestination(playerPos);
        playerEscaped = _PlayerRef.GetComponent<PlayerMovement>().hidding;
        if (playerEscaped)
        {
            playerEscaped = false;
            return lisenState;
        }
        else
        {
            return this;
        }
    }
}
