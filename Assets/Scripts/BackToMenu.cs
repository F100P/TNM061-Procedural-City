using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas mainCanvas;
    public Canvas menuCanvas;
    public Camera mainCamera;
    public Camera menuCamera;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuCanvas.enabled = true;
            menuCamera.enabled = true;
            mainCamera.enabled = false;
            mainCanvas.enabled = false;
        }
    }
}

