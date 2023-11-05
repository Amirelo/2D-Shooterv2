using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject boss;
    public bool canSpawn = true;
    public float delay = 200f;
    private GameObject enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.Find("Enemies");
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if(delay <=0 && canSpawn){
            canSpawn = false;
            Instantiate(boss, transform.position, transform.rotation);

            foreach(Transform enemy in enemySpawner.transform){
                enemy.GetComponent<Enemy>().OnBossAppeared();
            }

            Destroy(gameObject);
        }
    }
}
