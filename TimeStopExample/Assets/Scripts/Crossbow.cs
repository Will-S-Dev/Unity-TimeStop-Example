using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public Transform ArrowLaunch;
    public float ArrowSpeed;
    public float FireRate;
    private float firetimer;


    private Camera cam;
    private Animator anim;
    void Start()
    {
        cam = GetComponentInParent<Camera>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        firetimer -= Time.deltaTime;                                                                 //minus 1 per second

        if(Input.GetButtonDown("Fire1") && firetimer <=0f)                                            //if left click and fire timer less than zero
        {
            Vector3 middleofScreen = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 100f));          //Find the middle of the screen with z offset of 100f (fakes shooting to the middle)
            ArrowLaunch.LookAt(middleofScreen);                                                       //makes the launchtransform look at it

            GameObject arrow = Instantiate(ArrowPrefab, ArrowLaunch.position, ArrowLaunch.rotation); //Instantiate the arrow
            arrow.GetComponent<Rigidbody>().velocity = arrow.transform.forward * ArrowSpeed;        //Set the velocity of the arrow
            firetimer = FireRate;                                                                  // Makes the firetimer go back to the default firerate;

            anim.Play("Shoot");                                                                      //Play Shoot Animation

        }
    }
}
