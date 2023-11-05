using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFall : MonoBehaviour
{
    public float speed = 2f;
    private DifficultyController diffControl;
    private float screenSize;
    // Start is called before the first frame update
    void Start()
    {
        diffControl = GameObject.Find("GameManager").GetComponent<DifficultyController>();
        screenSize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -speed * diffControl.scaleMultiplier *Time.deltaTime, 0);   
        if (transform.position.y < - screenSize){
            Destroy(gameObject);
        }
    }


}
