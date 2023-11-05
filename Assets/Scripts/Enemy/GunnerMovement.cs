using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerMovement : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 targetPos;
    public float screenSize;

    void Start(){
        screenSize = Camera.main.orthographicSize;
        float randY = Random.Range(screenSize /2 , screenSize * 0.8f);
        targetPos = new Vector3(transform.position.x, randY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
