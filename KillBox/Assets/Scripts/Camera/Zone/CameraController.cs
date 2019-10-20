using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


     float targetFOV;
    public float sizeDecrement = .5f;
    public float initialFOV = 60f;
    public float smoothRate = 1f; // Value for smoother transition
    public Camera cam; //set main camera to this variable

    private float cameraTimer;
    private float currentFOV;
    public float maxTime = 20.0f;
    float zoomTimer;
    bool didZoneShrink = false;
    // Use this for initialization
    void Start()
    {
        cam.orthographicSize = initialFOV;
        zoomTimer = maxTime;
        targetFOV = initialFOV;
    }
    // Update is called once per frame
    void Update()
    {
        currentFOV = cam.orthographicSize; //keep track of Current FOV

        
        if (didZoneShrink) //Zone is shrinking
        {
            ChangeFOV();
        }
        else
        {
            zoomTimer -= Time.deltaTime;
            if (zoomTimer <= 0)
            {
                ShrinkFOV(sizeDecrement);
                zoomTimer = maxTime; 
            }
        }

    }
    public void ShrinkFOV(float viewSize)
    {
        targetFOV -= viewSize; //Change target size
        didZoneShrink = true;
        Debug.Log("In ShrinkFOV");
    }

    public void ChangeFOV()
    {
        Debug.Log("In Change FOV");
        if (currentFOV != targetFOV) //Is currentFOV caught up to targetFOV?
        {
            if (currentFOV >= targetFOV)
            {
                cam.orthographicSize += (-smoothRate * Time.deltaTime); //Smooth transition
            }
            else
            {
                if (currentFOV <= targetFOV) //If currentFOV goes over, set equal to TargetFOV
                {
                    cam.orthographicSize = targetFOV;
                    didZoneShrink = false; //done shrinking
                }
            }
        }
    }

    public void ResetFOV()
    {
        cam.orthographicSize = initialFOV;
        targetFOV = initialFOV;
        didZoneShrink = false;
    }

}
