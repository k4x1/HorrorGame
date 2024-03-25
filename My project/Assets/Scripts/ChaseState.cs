using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class ChaseState : State
{
    public ListenState lisenState;
    public bool playerEscaped;
    public EnemyDistanceEffects EnemyEffects;

    public override State RunCurrentState(GameObject _PlayerRef)
    {
        Vector3 playerPos = _PlayerRef.transform.position;
        
        agent.stoppingDistance = 0;
        agent.SetDestination(playerPos);
        agent.speed = 12;
        agent.acceleration= 5;
        playerEscaped = _PlayerRef.GetComponent<PlayerMovement>().hidding;
        EnemyEffects.RedOn = true;
        if (Vector3.Distance(playerPos, transform.position) < 3) {

            SceneManager.LoadScene(2);
        }
        if (playerEscaped)
        {
            //RenderSettings.fogColor = new Color(0, 0, 0);
            EnemyEffects.RedOn = false;
            agent.speed = 30;
            playerEscaped = false;
            return lisenState;
        }
        else
        {
            return this;
        }
    }
}
