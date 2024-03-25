using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyDistanceEffects : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject playerRef;
    [SerializeField] GameObject cameraRef;
    public float maxFogDistance = 10;
    BadTVEffect camTv;
    public float redLessening = 10;
    public bool RedOn = false;
    void Start()
    {
        RenderSettings.fog = true;
        camTv =  cameraRef.GetComponent<BadTVEffect>();
        ;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceX = playerRef.transform.position.x - transform.position.x;
        float distanceZ= playerRef.transform.position.z - transform.position.z;

        float distanceXnormal = (maxFogDistance - Mathf.Abs(distanceX)) / (maxFogDistance - 0);
        float distanceZnormal = (maxFogDistance - Mathf.Abs(distanceZ)) / (maxFogDistance - 0);

        float normalAvarage = (distanceXnormal + distanceZnormal)/2 ;
        // Debug.Log(normalAvarage);
        if (RedOn)
        {
       
            RenderSettings.fogColor = new Color(normalAvarage / redLessening, 0, 0);
        }
        else {
            RenderSettings.fogColor = new Color(0, 0, 0);
        }
     
            
        // RenderSettings.fogDensity = normalAvarage < 0.1f ? 0.1f : normalAvarage;
        camTv.thickDistort = normalAvarage*2.5f < 0.9f ? 0.9f : normalAvarage*2.5f;
        camTv.fineDistort = normalAvarage*5 < 2.5f ? 2.5f : normalAvarage*5;
        //transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, playerRef.transform.position, 1, 0.0f) );
        transform.LookAt(playerRef.transform);
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.x = 0;
        
        eulerAngles.z = 0;
        transform.rotation = Quaternion.Euler(eulerAngles);
    }
}
