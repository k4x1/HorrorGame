using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

struct V3nD {
    //vector 3 and distance

   public Vector3 v3;
   public float distance;
}
public class WatchingState : State
{
    public ChaseState chaseState;
    public bool canSeePlayer;
    public DissapearState dissapearState;
    public bool playerLookedAt;
    [SerializeField] private int maxDistance = 100;
    public StateManager stateManager;

    

  

    public override State RunCurrentState(GameObject _PlayerRef)
    {
        dissapearState.NotInView = false;
        /*V3nD[] hitArr = new V3nD[8];
        int iter = 0;
        for (int i = -1; i < 2; i++) {
            for (int j = -1; j < 2; j++)
            {
                if (j == 0 && i == 0) { break; }
                Ray ray = new Ray(_PlayerRef.transform.position, new Vector3(i, 0, j) + _PlayerRef.transform.forward);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                    
                    hitArr[iter].v3 = hit.point;
                    hitArr[iter].distance = Vector3.Distance(hit.point, transform.position);
                }
                
                iter++;
               
            }
        }
        V3nD Smallest = hitArr[0];
        
        for (int i = 0; i < 7; i++)
        {
            Smallest = hitArr[i].distance < Smallest.distance ? hitArr[i] : Smallest;
        }
        if(agent.remainingDistance < maxDistance) {
            agent.isStopped = true;
            agent.SetDestination(Smallest.v3);
        }
        else
        {
            agent.isStopped = false ;
           
        }

        Debug.Log(agent.remainingDistance);*/


        agent.SetDestination(_PlayerRef.transform.position);
        agent.stoppingDistance = maxDistance;

        if (stateManager.Viewing) {
            playerLookedAt = true;
        }


        ////exit
        if (canSeePlayer)
        {
            canSeePlayer = false;
            return chaseState;

        }
        else if (playerLookedAt) {
            float ran = Random.Range(0,100);
            if (_PlayerRef.GetComponent<PlayerMovement>().Loud) {
                ran = 100;
            }
          
            return ran<33 ? chaseState : dissapearState;
        }
        else
        {
            return this;
        }
    }
}
