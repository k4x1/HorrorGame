using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    int layermask = (1 << 13);
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 8; // select distance = 10 units from the camera
            Vector3 click=  Camera.main.ScreenToWorldPoint(mousePos);

            Ray ray = new Ray(click, new Vector3(0,0,1));

            RaycastHit hit = new RaycastHit();


            if (Physics.Raycast(ray, out hit, 5, layermask)) {
                Play();
            }

        }
    }
    public void Play() {
     
        SceneManager.LoadScene(1);
    }
    public void Quit() {
        Application.Quit();
    }
}
