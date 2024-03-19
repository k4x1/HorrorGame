using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State : MonoBehaviour
{
     public NavMeshAgent agent;
    protected GameObject enemy;
    public abstract State RunCurrentState(GameObject _PlayerRef);
/*
    private void Start()
    {
        enemy = transform.parent.transform.parent.gameObject;
    }*/
}