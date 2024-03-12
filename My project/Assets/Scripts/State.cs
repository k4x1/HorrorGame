using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State : MonoBehaviour
{
    public abstract State RunCurrentState(GameObject _PlayerRef);

}
