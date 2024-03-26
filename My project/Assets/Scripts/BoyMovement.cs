using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class BoyMovement : MonoBehaviour
{
    // Start is called before the first frame update\
    public GameObject player;
    public NavMeshAgent agent;
    public Vector3 boyPoint = Vector3.zero;
    public GameObject[] pointList;
    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.green;
        Gizmos.DrawSphere(boyPoint, 1);
    }
    public enum stateEnum { 
        RUNNING,
        WONDERING,
        CAUGHT
    };
    public  stateEnum CurrentState = stateEnum.WONDERING;
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        float distanceToPlayer = Mathf.Abs(Vector3.Distance(transform.position, player.transform.position));
        if (distanceToPlayer < 3) {

            CurrentState = stateEnum.CAUGHT;
        }
        else if (distanceToPlayer < 50)
        {
            CurrentState = stateEnum.RUNNING;

        }
        else {

            CurrentState = stateEnum.WONDERING;
        }
        switch (CurrentState)
        {
            case stateEnum.RUNNING:
                Vector3 dirToPlayer = transform.position - playerPos;
                Vector3 newPos = transform.position + dirToPlayer;
                agent.SetDestination(newPos);
                agent.speed = 10;
                boyPoint = Vector3.zero;
                break;
            case stateEnum.WONDERING:
                if (boyPoint == Vector3.zero)
                {
                    boyPoint = pointList[Random.Range(0, pointList.Length)].transform.position;
                }
                agent.SetDestination(boyPoint);
                agent.speed = 5;
                float distanceToPoint = Mathf.Abs(Vector3.Distance(boyPoint, transform.position));

                if (distanceToPoint < 10)
                {
                    boyPoint = Vector3.zero;
                }
                break;
            case stateEnum.CAUGHT:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(3);    
                break;

        };

    }

 
}
