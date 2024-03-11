using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public WatchingState watchingState;
    public bool playerEscaped;
    public override State RunCurrentState()
    {
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
