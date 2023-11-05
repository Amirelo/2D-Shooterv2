using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurret : MonoBehaviour
{
    private GameObject player;
    private Transform attackPoint;
    public GameObject shootEffect;
    public GameObject bullet;
    public float delay;
    public float delayDefault = 2f;
    // Start is called before the first frame update
    void Start()
    {
        delay = delayDefault;
        player = GameObject.Find("Player");
        foreach (Transform item in transform){
            if (item.name == "AttackPoint"){
                attackPoint = item;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        LookAtPlayer();
        ShootAtPlayer();
    }

    void LookAtPlayer()
    {
        if (player != null)
        {
            Vector3 diff = player.transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }

    }

    void ShootAtPlayer()
    {
        if (delay <= 0 && player != null)
        {
            delay = delayDefault;
            GameObject effect = Instantiate(shootEffect, attackPoint.position, transform.rotation);
            Instantiate(bullet, attackPoint.position, transform.rotation);
            effect.transform.SetParent(transform);
        }

    }
}
