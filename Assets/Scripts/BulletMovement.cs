using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 2f;
    private float screenSize;
    // Start is called before the first frame update
    void Start()
    {
        screenSize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        if(transform.position.y < - screenSize || transform.position.y > screenSize){
            Destroy(gameObject);
        }
    }

}
