using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 1;
    public float speed = 2f;
    public List<GameObject> gunList;
    public GameObject playerDeathVFX;
    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
        foreach (Transform gunPos in transform)
        {
            gunList.Add(gunPos.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = Vector2.MoveTowards(transform.position, worldPos, speed * Time.deltaTime);
    }



    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.transform.CompareTag("Enemy") || collider.gameObject.transform.CompareTag("BulletEnemy"))
        {
            health -= 1;
            if (health <= 0)
            {
                Instantiate(playerDeathVFX, transform.position, transform.rotation);
                uiManager.OnGameFinish();
                Destroy(collider.gameObject);
                Destroy(gameObject);
            }
        }

    }
}
