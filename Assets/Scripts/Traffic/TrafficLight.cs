using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{

    [SerializeField] private Light red;
    [SerializeField] private Light yellow;
    [SerializeField] private Light green;
    [SerializeField] private Light redSecond;
    [SerializeField] private Light yellowSecond;
    [SerializeField] private Light greenSecond;
    public float delay;

    public float timer;

    private void Light_order()
    {
        
        if (timer > 5)
        {
            red.enabled = true;
            yellow.enabled = false;
            green.enabled = false;
            redSecond.enabled = true;
            yellowSecond.enabled = false;
            greenSecond.enabled = false;
        }
        else if (timer < 5 && timer > 4)
        {
            red.enabled = false;
            yellow.enabled = true;
            green.enabled = false;
            redSecond.enabled = false;
            yellowSecond.enabled = true;
            greenSecond.enabled = false;

        }
        else if (timer < 4)
        {
            red.enabled = false;
            yellow.enabled = false;
            green.enabled = true;

            redSecond.enabled = false;
            yellowSecond.enabled = false;
            greenSecond.enabled = true;

        }
        else
        {
            red.enabled = false;
            yellow.enabled = false;
            green.enabled = false;

            redSecond.enabled = false;
            yellowSecond.enabled = false;
            greenSecond.enabled = false;

        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 20;
        }

    }
    // Start is called before the first frame update
    private void Start()
    {
        timer = (timer + delay) % 10;
    }

    // Update is called once per frame
    void Update()
    {
        Light_order();
    }
}
