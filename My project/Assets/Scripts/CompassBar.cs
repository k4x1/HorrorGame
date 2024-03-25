using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//    https://www.youtube.com/watch?v=XcpTC1VYVNE
public class CompassBar : MonoBehaviour
{
    // Start is called before the first frame update

    public RectTransform compassTransform;
    public RectTransform objectiveTransform;

    public Transform cameraObjectTransform;
    public Transform objectiveObjectTransform;

    void Update()
    {
        SetMarkerPosition(objectiveTransform, objectiveObjectTransform.position);

    }
    private void SetMarkerPosition(RectTransform markerTransform, Vector3 worldPosition) {
        Vector3 direcitonToTarget = worldPosition - cameraObjectTransform.position;
        float angle = Vector2.SignedAngle(new Vector2(direcitonToTarget.x, direcitonToTarget.z), new Vector2(cameraObjectTransform.transform.forward.x, cameraObjectTransform.transform.forward.z));
        float compassPositionX = Mathf.Clamp(2 * angle / Camera.main.fieldOfView, -1, 1);
        markerTransform.anchoredPosition = new Vector2(compassTransform.rect.width / 2 * compassPositionX , 0);
    }
}
