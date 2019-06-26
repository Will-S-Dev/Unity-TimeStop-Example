using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
public class Player : MonoBehaviour
{
    private TimeManager timemanager;
    public GrayscaleLayers Grayscale;
    // Start is called before the first frame update
    void Start()
    {
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) //Stop Time when Q is pressed
        {
            timemanager.StopTime();
            Grayscale.enabled = true;
        }
        if(Input.GetKeyDown(KeyCode.E) && timemanager.TimeIsStopped)  //Continue Time when E is pressed
        {
            timemanager.ContinueTime();
            Grayscale.enabled = false;

        }
    }
}
