using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    public Transform[] moveSpots;
    public float speed;
    private bool pedestrianDetected = false;
    private int currentSpot;
    private LayerMask layermask;
    
  
    

    private int length;
    public GameObject crashDetector;
    
    // Start is called before the first frame update
    void Start()
    {

        currentSpot = 0;
        transform.position = moveSpots[currentSpot].position;
    
        length = moveSpots.Length - 1;
        layermask = LayerMask.GetMask("Player","Car");
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[currentSpot].position, speed * Time.deltaTime);   
        transform.LookAt(moveSpots[currentSpot].position);

     
    }

    // Update is called once per frame
    void Update()
    {

      
 

        if (Physics.CheckSphere(crashDetector.transform.position, 2.0f,layermask))
        {
            
            pedestrianDetected = true;

            
          
        }


        else
        {
            pedestrianDetected = false;
        }

        if (!pedestrianDetected)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpots[currentSpot].position, speed * Time.deltaTime);
   
        }

        

        if (Vector3.Distance(transform.position, moveSpots[currentSpot].position) < 0.1f)
        {

           

            if ((currentSpot) == length)
            {
                Destroy(gameObject);
               
            }

            else
            {
                currentSpot++;
            }

            

           


            //Adjust rotation according to postion
            transform.LookAt(moveSpots[currentSpot].position);
          

        }


    }


    private void OnDrawGizmos()
    {

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(crashDetector.transform.position, 2);
    }



}
