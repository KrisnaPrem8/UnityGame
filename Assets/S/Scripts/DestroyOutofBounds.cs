using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    private float topBound = 11.0f;
    private float lowerBound = -15.0f;
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            spawnManager.GameOver();
        }
        
    }
}
