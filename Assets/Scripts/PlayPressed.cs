using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPressed : MonoBehaviour
{
    public Slider TimeSlider;
    public bool Isrunning;
    // Start is called before the first frame update
    void Start()
    {
        Isrunning = !Isrunning;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
