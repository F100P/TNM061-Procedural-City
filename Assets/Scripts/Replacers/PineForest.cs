using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineForest : MonoBehaviour
{
    // Use the inspector to set a list of parcels; this script will pick one at random
    public GameObject[] parcelSet;

    private GameObject spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        int randomParcel = Random.Range(0, parcelSet.Length);
        int randomRot = Random.Range(0, 3);

        // Instantiate the chosen parcel with the position and rotation of the placeholder
        spawnedObject = Instantiate(parcelSet[randomParcel], gameObject.transform.position, Quaternion.Euler(0f, 90*randomRot, 0f));
        spawnedObject.transform.localScale = gameObject.transform.localScale;

        // Destroy the placeholder object
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
