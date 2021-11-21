using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderValue : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider mainSlider;
    
    public bool isRunning = true;
    public float Speed = 1;
    public Text currentSpeed;
    public Sprite Pause;
    public Sprite Play;
    public Button button;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            button.image.sprite = Pause;
            mainSlider.value += Time.deltaTime*Speed;
            mainSlider.value %= 24; //gör värdet mellan 0-24
        }
        else { button.image.sprite = Play; }

        currentSpeed.text = "Speed:" + Speed.ToString();
    }

    public void ForwardPressed()
    {
        if (Speed <= 4f && isRunning)
        {
            Speed = Speed*2f;
        }
    }
    public void BackwardPressed()
    {
        if (Speed >= 0.2f && isRunning)
        {
            Speed = Speed / 2f;
        }
    }
    public void playPressed()
    {
        
        isRunning = !isRunning;
        
    }
}

