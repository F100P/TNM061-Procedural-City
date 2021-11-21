using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitch : MonoBehaviour
{
    //Strul med scriptet. prefaben m�ste laddas om f�r att kunna st�nga av Emission...
    public Material WindowsMaterial;
    public bool Light;
    private bool flag = true;
    public GameObject preFab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Light)
        {
            if (flag)
            {
                WindowsMaterial.EnableKeyword("_EMISSION");
                //Instantiate(preFab);
                
                flag = false;
            }
        }
        else {
            if (!flag)
            {
                WindowsMaterial.DisableKeyword("_EMISSION");
                //Instantiate(preFab);
               
                flag = true;
            }
        }
    }
}
