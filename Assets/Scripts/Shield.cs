using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int health = 1;

    public void ShieldActivated(bool status){
        gameObject.SetActive(status);
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.transform.CompareTag("Enemy") || collider.gameObject.transform.CompareTag("EnemyBullet")){
            health -= 1;
            Destroy(collider.gameObject);
            if (health <= 0) {
                ShieldActivated(false);
            }
        }
    }
}
