using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    // Start is called before the first frame update

    ParticleSystem parts;
    public bool playing = false;
    void Start()
    {
        parts = GetComponent<ParticleSystem>();
        parts.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {

            parts.Play();
            return;
        }

        parts.Pause();
        parts.Clear();
    }
}
