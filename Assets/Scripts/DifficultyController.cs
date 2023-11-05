using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    public float scaleMultiplier = 1f;
    public float scaleOverTime = 1.2f;
    public float maxMultiplier = 3f;
    public float delay = 2f;
    public float delayDefault = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if(delay <= 0 && maxMultiplier > scaleMultiplier){
            delay = delayDefault;
            scaleMultiplier *= scaleOverTime;
        }
    }
}
