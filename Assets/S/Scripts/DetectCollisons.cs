using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DetectCollisons : MonoBehaviour
{
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();  

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
        spawnManager.UpdateScore(1);
    }

   
}
