using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseColorChange : MonoBehaviour
{
    public Material m_Material;

    // Start is called before the first frame update
    void Start()
    {
        int randColor = Random.Range(1, 4);
        if (randColor == 1) m_Material.color = Color.blue;
        else if (randColor == 2) m_Material.color = Color.red;
        else if (randColor == 3) m_Material.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
