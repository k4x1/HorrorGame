using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchingState : State
{
    public ChaseState chaseState;
    public bool canSeePlayer;

    public override State RunCurrentState(GameObject _PlayerRef)
    {
        if (canSeePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }
}
