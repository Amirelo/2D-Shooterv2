using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject spawn;
    public GameObject group;
    public float delay = 0f;
    public float delayDefault = 2f;
    public float delayMultiplier = 1f;
    public float minDelay = 0.5f;
    private float boundaryX; 
    
    // Start is called before the first frame update
    void Start()
    {
        boundaryX = Camera.main.orthographicSize / 2;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;

        float randomX = Random.Range(-boundaryX, boundaryX);
        Vector3 spawnPos = new Vector3(randomX,transform.position.y,0);
        
        if(delay <= 0){
            if (delayDefault <= minDelay){
                delayDefault = minDelay;
            } else{
                delayDefault *= delayMultiplier;
            }
            delay = delayDefault;
            GameObject spawned = Instantiate(spawn, spawnPos, Quaternion.identity);
            spawned.transform.SetParent(group.transform);
        }
    }
}
