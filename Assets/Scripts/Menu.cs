using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Camera gameCamera;
    public Camera menuCamera;
    public Button PlayButton;
    public Canvas menuCanvas;
    public Canvas gameCanvas;
    // Start is called before the first frame update


    void Start()
    {
        gameCanvas.enabled = false;
        gameCamera.enabled = false;
        menuCamera.enabled = true;
        menuCanvas.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStartPressed()
    {
        menuCanvas.enabled = false;
        menuCamera.enabled = false;
        gameCamera.enabled = true;
        gameCanvas.enabled = true;
    }
}
