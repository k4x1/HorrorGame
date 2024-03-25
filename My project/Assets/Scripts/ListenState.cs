using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;

public class ListenState : State
{
    public WatchingState watchingState;
    public bool PlayerHeard;
    [SerializeField] private float LoudDistance = 500;
    [SerializeField] public float QuietDistance = 100;
    [SerializeField] public float ExtraQuietDistance = 10;
    public StateManager stateManager;
    public GameObject[] pointList;
    public Vector3 point = Vector3.zero;

    public override State RunCurrentState(GameObject _PlayerRef)
    {
        
        if (point == Vector3.zero) {
            point = pointList[Random.Range(0, pointList.Length)].transform.position;
        }
        agent.SetDestination(point);
        float distanceToPoint= Mathf.Abs(Vector3.Distance(point, transform.parent.transform.parent.transform.position));
   
        if (distanceToPoint < 10) {
            point = Vector3.zero;
        }
        Vector3 playerPos = _PlayerRef.transform.position;
        float distance = Mathf.Abs(Vector3.Distance(playerPos, transform.position));
        if (_PlayerRef.GetComponent<PlayerMovement>().hidding){
            return this;
        }
        if (distance < LoudDistance)
        {
            if (stateManager.playerMoveRef.Loud) {
                
                return watchingState;
            }
            if (distance < QuietDistance)
            {
                if (distance > ExtraQuietDistance)
                    if (stateManager.playerMoveRef.Quiet)
                    {
                        return this;
                    }
               return watchingState;
            }

        }
        return this;
    }
}
