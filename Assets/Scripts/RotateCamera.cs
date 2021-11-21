using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    
    public float speed;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
      
        
        
    }

    // Update is called once per frame
    void Update()
    {

        //transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);


        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
           
        }

       if (Input.GetKey(KeyCode.D))
        {

            transform.RotateAround(target.transform.position, -Vector3.up, 20 * Time.deltaTime);
        }
            
        
        

    }
}
