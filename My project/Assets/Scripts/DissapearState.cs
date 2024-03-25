using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


public class DissapearState : State
{
    public WatchingState watchingState;
    public ListenState listenState;
    public bool NotInView = false;
    public GameObject eyes;
    public float eyeSpeed = 0;
    public float eyeAccelration = 1.2f;
    public override State RunCurrentState(GameObject _PlayerRef)
    {
        eyeSpeed += eyeAccelration*Time.deltaTime;
        watchingState.GetComponent<WatchingState>().playerLookedAt = false;
    
        Vector3 playerDir = _PlayerRef.transform.position - agent.transform.position;
        playerDir.Normalize();
        Vector2 perpendicular = new Vector2(playerDir.x, playerDir.z);
        perpendicular = Vector2.Perpendicular(perpendicular);


        eyes.transform.position = new Vector3(eyes.transform.position.x + (perpendicular.x * Time.deltaTime * eyeSpeed),
            eyes.transform.position.y, eyes.transform.position.z + (perpendicular.y * Time.deltaTime * eyeSpeed));
        if (eyeSpeed > 10)
        {
           transform.parent.transform.parent.transform.position = new Vector3(Random.Range(-1000f, 1000f), transform.position.y, Random.Range(-1000, 1000));
            eyes.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            eyeSpeed = 0;
            NotInView = true;

        }
            if (NotInView)
            {
                eyes.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                return listenState;
            }
            else
            {
                return this;
            }
        }
    }
    