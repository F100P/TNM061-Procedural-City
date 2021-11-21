using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class randomize : MonoBehaviour
{
    public GameObject[] plotSet;

    //Cars and pedestrians
    public Transform[] pedestrianMoveSpotsIntersect;
    public Transform[] pedestrianMoveSpotsGlesbygd;
    public Transform[] pedestrianMoveSpotsForserum;
    public Transform[] pedestrianMoveSpotsRaceBana;
    public Toggle myToggle;
    
    public Transform[] carWayPointsIntersectA;
    public Transform[] carWayPointsIntersectB;
    public Transform[] carWayPointsGlesbygd;
    public Transform[] carWayPointsForserumA;
    public Transform[] carWayPointsForserumB;
    public Transform[] carWayPointsRaceBana;
    private int randomPlot;
    public float spawnTimeCars;
    public int numberOfPersonsToSpawn;
    private int randomPedestrianSpot;
    public GameObject pedestrian;
    public GameObject[] listOfCars;
    private GameObject pedestrianInstance;
    private GameObject pedestrianChild;
    private Material shirt;
    private GameObject car;
    private Transform[] newSpots;
   

    public void OnButtonPress()
    {
        //Cancel the previous invoke repeat 
        CancelInvoke();

        // Clean up existing objects before generating new ones

        var parcels = GameObject.FindGameObjectsWithTag("Parcel");
        foreach (GameObject item in parcels)
        {
            Destroy(item);
        }
        var plots = GameObject.FindGameObjectsWithTag("Plot");
        foreach (GameObject item in plots)
        {
            Destroy(item);
        }



        // Generate a new plot, which will automatically generate new parcels from the spawners in the plot

        if (myToggle.isOn)
        {
            randomPlot = Random.Range(0, plotSet.Length);
            Instantiate(plotSet[randomPlot], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else

        {
            randomPlot = 0;
            Instantiate(plotSet[0], new Vector3(0, 0, 0), Quaternion.identity);
        }
        


        //Generate new car with repeat
        InvokeRepeating("SpawnCar", 0, spawnTimeCars);

        //Spawn new pedestrians
        SpawnPedestrians();


    }

    // Start is called before the first frame update
    void Start()
    {

        randomPlot = 0;
        InvokeRepeating("SpawnCar", 0, spawnTimeCars);
        SpawnPedestrians();


    }

   

    void SpawnCar()
    {
       

        //Get a random car model
        car = listOfCars[Random.Range(0, listOfCars.Length)];

        GameObject carCopy = Instantiate(car);

        CarMovement carScript = carCopy.GetComponent<CarMovement>();

        //Set moveSpots according to the plot
        if (randomPlot == 0)
        {
            //Set one of two routes
            if (Random.Range(0, 2) == 1)
            {
                carScript.moveSpots = carWayPointsIntersectA;
            }

            else
            {
                carScript.moveSpots = carWayPointsIntersectB;

            }
            
            
            
        }

        else if(randomPlot == 1)
        {
            carScript.moveSpots = carWayPointsGlesbygd;
            
        }

        else if(randomPlot == 2)
        {
            if(Random.Range(0,2) == 1)
            {
                carScript.moveSpots = carWayPointsForserumA;
            }

            else
            {
                carScript.moveSpots = carWayPointsForserumB;
            }
            
        }
        else if(randomPlot == 3)
        {

            carScript.moveSpots = carWayPointsRaceBana;
        }
        else
        {
            Debug.Log("Error setting the Car MoveSpots..");
        }

        


    }

    void SpawnPedestrians()
    {
      


        if (randomPlot == 0)
        {
            newSpots = pedestrianMoveSpotsIntersect;
        }

        
        else if(randomPlot == 1)
        {

            newSpots = pedestrianMoveSpotsGlesbygd;

        }

        else if(randomPlot == 2)
        {
            newSpots = pedestrianMoveSpotsForserum;
        }

        else if(randomPlot == 3)
        {
            newSpots = pedestrianMoveSpotsRaceBana;
        }

        else{
            Debug.Log("Error setting the Pedestrian moveSpots..");
        }
         
            //Generate new players
            for (int i = 0; i < (numberOfPersonsToSpawn); i++)
            {

              
                        //Get random pedestrian spot
                        randomPedestrianSpot = Random.Range(0, (newSpots.Length));
                        pedestrianInstance = Instantiate(pedestrian, newSpots[randomPedestrianSpot].position, newSpots[randomPedestrianSpot].rotation);
                        PedestrianMovement pedestrianScript = pedestrianInstance.GetComponent<PedestrianMovement>();
                        pedestrianScript.moveSpots = newSpots;
                        pedestrianChild = pedestrianInstance.transform.GetChild(0).gameObject;
                        shirt = pedestrianChild.GetComponent<Renderer>().material;
                        shirt.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                        
                }
              

        }

    //Function to generate a random number with exception (current pos)
    public int RandomExcept(int min, int max, int except)
    {
        int random = Random.Range(min, max);
        if (random >= except) random = (random + 1) % max;
        return random;
    }

}
