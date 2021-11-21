using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianMovement : MonoBehaviour
{
    private float speed;
    public Transform[] moveSpots;
    private int randomSpot;
    private int currentSpot;
    private int prevSpot;
    private Animator m_Animator;
    private bool isDiagonal;
    public int moveSpotsLength;
    private int limiter, loopCap;
    public GameObject crashDetector;
    private LayerMask layermask;





    // Start is called before the first frame update
    void Start()
    {

        limiter = 0;
        loopCap = 1000;
        randomSpot = Random.Range(0, moveSpotsLength);
        layermask = LayerMask.GetMask("Player");
        //Set diagonal boolean



        isDiagonal = (Mathf.Abs(transform.position.x - moveSpots[randomSpot].position.x) > 5.0f) && (Mathf.Abs(transform.position.z - moveSpots[randomSpot].position.z) > 5.0f);

        //Get random spot
        while (isDiagonal && limiter < loopCap)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
            isDiagonal = (Mathf.Abs(transform.position.x - moveSpots[randomSpot].position.x) > 5.0f) && (Mathf.Abs(transform.position.z - moveSpots[randomSpot].position.z) > 5.0f);
            limiter++;
        }

        if (limiter >= loopCap)
        {
            Debug.Log("Something went wrong. Infinite loop avoided...");
        }

        currentSpot = randomSpot;
        prevSpot = currentSpot;

        
        //Set random position
        // transform.position = moveSpots[randomSpot].position;

        //Adjust rotation according to postion
        

        //Get the animator
        m_Animator = gameObject.GetComponent<Animator>(); 

       
        //Set a random speed 
        speed = Random.Range(2, 4);

        //Adjust animation according to speed
        m_Animator.speed = 0.5f * speed; 


    }

    // Update is called once per frame
    void Update()
    {

        limiter = 0;


        //Move towards a random position
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        //Adjust rotation according to postion
        transform.LookAt(moveSpots[randomSpot].position);

        //Check if close to position
        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.1f)
        {
            //Store current spot
            currentSpot = randomSpot;


            //Get new spot
            randomSpot = RandomExcept(0, moveSpots.Length, currentSpot);

            //Set diagonal boolean
            isDiagonal = (Mathf.Abs(moveSpots[currentSpot].position.x - moveSpots[randomSpot].position.x) > 5.0f) && (Mathf.Abs(moveSpots[currentSpot].position.z - moveSpots[randomSpot].position.z) > 5.0f);

            
            //Prevent same position and diagonal movement
            while ( (prevSpot == randomSpot) || isDiagonal && limiter < loopCap)
            {
                randomSpot = RandomExcept(0, moveSpots.Length, currentSpot);
                isDiagonal = (Mathf.Abs(moveSpots[currentSpot].position.x - moveSpots[randomSpot].position.x) > 5.0f) && (Mathf.Abs(moveSpots[currentSpot].position.z - moveSpots[randomSpot].position.z) > 5.0f);
                ++limiter;

            }

            if (limiter >= loopCap)
            {
                Debug.Log("Something went wrong. Infinite loop avoided...");
            }

           


            //Adjust rotation according to postion
            transform.LookAt(moveSpots[randomSpot].position);

        }

        //Store previous position
        prevSpot = currentSpot;


        if (Physics.CheckSphere(crashDetector.transform.position, 1.0f, layermask))
        {

            

        
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self);



        }


    }



    //Function to generate a random number with exception (current pos)
    public int RandomExcept(int min, int max, int except)
    {
        int random = Random.Range(min, max);
        if (random >= except) random = (random + 1) % max;
        return random;
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(crashDetector.transform.position, 1);
    }


}
