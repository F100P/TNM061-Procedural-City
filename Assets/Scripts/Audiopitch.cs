using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audiopitch : MonoBehaviour
{
    public Slider MainSlider;
    public AudioSource thisAudio;
    public Button mute;
    public float speed;
    private float pre_speed;
    private bool running;
    public bool soundOn;

    // Start is called before the first frame update
    private void Awake()
    {
        thisAudio.Play();
        thisAudio.playOnAwake = true;
    }
    void Start()
    {
        speed = MainSlider.GetComponent<SliderValue>().Speed;
        running = MainSlider.GetComponent<SliderValue>().isRunning;
        soundOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        running = MainSlider.GetComponent<SliderValue>().isRunning;
        speed = MainSlider.GetComponent<SliderValue>().Speed;
        soundOn = mute.GetComponent<MuteButton>().soundOn;
        if (running && soundOn)
        {
            thisAudio.mute = false;
            if (speed != pre_speed)
            {

                if (speed < 1)
                {


                    //Blir inte samma värde om man spolar fram och sen bak, kolla på detta imorgon
                    if (speed > pre_speed)
                    {
                        thisAudio.pitch += 0.03f;
                    }
                    if (speed < pre_speed)
                    {
                        thisAudio.pitch -= (0.03f); //fulkod
                    }
                }
                else
                {
                    if (speed == 1f)
                    {
                        thisAudio.pitch = 1f;
                    }

                    else if (speed > pre_speed)
                    {
                        thisAudio.pitch += (0.02f);
                    }
                    else if (speed < pre_speed)
                    {
                        thisAudio.pitch -= (0.02f);
                    }
                }
            }
            pre_speed = speed;
        }
        else
        {
            thisAudio.mute = true;
        }
    }
   
}
