using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    public float lifeTime = 0.5f;
    public int bombDamage = 10;

    void Update(){
        lifeTime -= Time.deltaTime;
        transform.localScale += new Vector3(0.1f,0.1f,0.1f);
        if (lifeTime <= 0){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Enemy")){
            collider.gameObject.GetComponent<Enemy>().OnWaveHit(bombDamage);
        }
        if(collider.gameObject.CompareTag("BulletEnemy")){
            Destroy(collider.gameObject);
        }
    }
}
