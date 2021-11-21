using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MuteButton : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource myAudio;
    public bool soundOn = true;
    public Button thisButton;
    public Sprite ON;
    public Sprite OFF;

    private void Awake()
    {
      
    }
    void Start()
    {
        soundOn = true;
}

    // Update is called once per frame
    void Update()
    {
        if (soundOn)
        {
            myAudio.mute = false;
            thisButton.image.sprite = ON;

        }
        else if (soundOn == false)
        {
            myAudio.mute = true;
            thisButton.image.sprite = OFF;
        }
        
    }

    public void isMutePressed()
    { 
        soundOn = !soundOn;
    }
}
