using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Blinky : MonoBehaviour
{
    [SerializeField] private Light myLight;
    public Slider timeSlider;
    public float time;



    void BlinkyLight()
    {

        


        if (time > 6f && time < 16)
        {
            myLight.enabled = false;
        }
        else
        {
            myLight.enabled = true;
        }

        return;

    }

    

    // Start is called before the first frame update
    void Start()
    {

        if (GameObject.FindGameObjectWithTag("myCanvas"))
        {
            timeSlider = (Slider)FindObjectOfType(typeof(Slider));
        }


    }

    // Update is called once per frame
    void Update()
    {

        time = timeSlider.value;

        BlinkyLight();
    }
}
