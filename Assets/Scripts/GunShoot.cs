using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shootEffect;
    private GameObject shootPoint;
    public float delay = 0f;
    public float delayDefault = 2f;
    // Start is called before the first frame update
    void Start()
    {
        shootPoint = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        Attack();
    }

    void Attack(){
        if(Input.GetMouseButton(0) && delay <= 0){
            delay = delayDefault;
            Instantiate(bullet, shootPoint.transform.position, transform.rotation);
            GameObject effect = Instantiate(shootEffect, shootPoint.transform.position, transform.rotation);
            effect.transform.SetParent(transform);
        }
    }
}
