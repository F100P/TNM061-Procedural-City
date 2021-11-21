using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacerTREE : MonoBehaviour
{
    public GameObject[] parcelSet;

    private GameObject spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        int randomParcel = Random.Range(0, parcelSet.Length);

        spawnedObject = Instantiate(parcelSet[randomParcel], gameObject.transform.position, gameObject.transform.rotation);
        spawnedObject.transform.localScale = gameObject.transform.localScale;

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
