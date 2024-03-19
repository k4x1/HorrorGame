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
    public Vector3 point = Vector3.zero;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(point, 1);
    }
    public override State RunCurrentState(GameObject _PlayerRef)
    {
        
        if (point == Vector3.zero) {
            point = new Vector3(Random.Range(-146.25f, 123.33f), transform.position.y, Random.Range(-229.14f, 239.1f));
            Ray ray = new Ray(point, Vector3.zero);
            while (Physics.Raycast(ray, 0.01f)) { 
                point = new Vector3(point.x++, point.y, point.z++);
                Debug.Log(point);
            }

        }
        agent.SetDestination(point);
        float distanceToPoint= Mathf.Abs(Vector3.Distance(point, transform.parent.transform.parent.transform.position));
   
        if (distanceToPoint < 10) {
            point = Vector3.zero;
        }
     /*   Vector3 playerPos = _PlayerRef.transform.position;
        float distance = Mathf.Abs(Vector3.Distance(playerPos, transform.position));
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

        }*/
        return this;
    }
}
