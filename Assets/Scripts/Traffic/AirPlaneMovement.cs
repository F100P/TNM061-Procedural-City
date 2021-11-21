using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneMovement : MonoBehaviour
{
    public Transform[] moveSpots;
    private int randomSpot;
    private int currentSpot;
   
    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, 10.0f * Time.deltaTime);
       

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, 10.0f*Time.deltaTime);
        transform.LookAt(moveSpots[randomSpot].position);
        

        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.1f)
        {

            
            //Store current spot
            currentSpot = randomSpot;


            //Get new spot
            randomSpot = RandomExcept(0, moveSpots.Length, currentSpot);

            //Adjust rotation according to postion
            transform.LookAt(moveSpots[randomSpot].position);

        }

   

    }

    public int RandomExcept(int min, int max, int except)
    {
        int random = Random.Range(min, max);
        if (random >= except) random = (random + 1) % max;
        return random;
    }
}
