using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite Pause;
    public Sprite Play;
    public Button button;
    void Start()
    {
        button.image.sprite = Pause;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
