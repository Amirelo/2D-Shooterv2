using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy config")]
    public int health = 1;
    public int killPoints = 1;

    [Header("Effect")]
    public GameObject bulletHitVFX;
    public bool canTouch = true;
    public enum EnemyType {
        Normal,
        Boss
    };
    public EnemyType enemyType = new EnemyType();
    private PlayerManager playerManager;
    private UIManager uiManager;

    void Start(){
        playerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.transform.CompareTag("Bullet") && canTouch)
        {
            OnHit(collider.gameObject);
        }
    }
    public void OnHit(GameObject hit)
    {
        health -= 1;
        if (health <= 0)
        {
            canTouch = false;
            Instantiate(bulletHitVFX, transform.position, transform.rotation);
            Destroy(gameObject);
            playerManager.updateKill(killPoints);
            if (enemyType == EnemyType.Boss){
                uiManager.OnGameFinish();
            }
        }
        Destroy(hit);
    }

    public void OnWaveHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(bulletHitVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void OnBossAppeared()
    {
        Instantiate(bulletHitVFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
