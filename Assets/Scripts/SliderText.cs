using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    private Slider mainSlider;
    public Text text;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("myCanvas"))
        {
            mainSlider = (Slider)FindObjectOfType(typeof(Slider));
        }
    }

    // Update is called once per frame
    void Update()
    {
        time = mainSlider.value;

        text.text = "Time of Day " + time;
    }
}
