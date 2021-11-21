using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour



{

    [SerializeField] private Light red;
    public Collider collider;

   

    // Update is called once per frame
    void Update()
    {

        if (red.enabled)
        {

            collider.enabled = true;


        }

        else
        {
            collider.enabled = false;
        }
    }
}
