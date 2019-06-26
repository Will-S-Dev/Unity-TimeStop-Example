using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public bool TimeIsStopped;
    
   public void ContinueTime()
    {
        TimeIsStopped = false;

        var objects = FindObjectsOfType<TimeBody>();  //Find Every object with the Timebody Component
        for (var i = 0; i < objects.Length; i++)
        {
            objects[i].GetComponent<TimeBody>().ContinueTime(); //continue time in each of them
        }
   
    }
    public void StopTime()
    {
        TimeIsStopped = true;
    }
}
