using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrigger : MonoBehaviour
{
    public GameObject destroyWaveVFX;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.transform.CompareTag("Player"))
        {
            Instantiate(destroyWaveVFX, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
