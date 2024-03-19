using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public GameObject playerRef;
    public State currentState;
    public bool Viewing = false;
    int layerMask = (1 << 7);
    [SerializeField] private float maxRayDistance = 20;
    public PlayerMovement playerMoveRef;

    private void Start()
    {
        playerMoveRef = playerRef.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Ray ray = new Ray(playerRef.transform.position, playerRef.transform.forward);
        RaycastHit hit = new RaycastHit();
        Debug.DrawRay(playerRef.transform.position, playerRef.transform.forward * maxRayDistance, Color.red);
        Viewing = Physics.Raycast(ray, out hit, maxRayDistance, layerMask);
        //if (Viewing) { Debug.Log(Viewing); }
        
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
