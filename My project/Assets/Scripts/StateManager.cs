using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public GameObject playerRef;
    public State currentState;
    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine() {
        State nextState = currentState?.RunCurrentState(playerRef);
        if (nextState != null) {
            SwitchToNextState(nextState);
        }
    }
    private void SwitchToNextState(State nextState) { 
    
        currentState = nextState;
    }
}
