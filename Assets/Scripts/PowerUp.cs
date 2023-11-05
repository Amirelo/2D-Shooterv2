using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject powerUpVFX;
    public float cooldownDecrease = 0.1f;
    public float cooldownMax = 0.2f;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Instantiate(powerUpVFX, transform.position, transform.rotation);

            if (playerController.gunList[1].activeSelf == true)
            {
                playerController.gunList[2].SetActive(true);
            }

            if (playerController.gunList[1].activeSelf == false)
            {
                playerController.gunList[1].SetActive(true);
            }


            if (cooldownMax <= playerController.gunList[0].transform.GetChild(0).gameObject.GetComponent<GunShoot>().delayDefault)
            {
                for (int i = 0; i < playerController.gunList.Count; i++)
                {
                    playerController.gunList[i].transform.GetChild(0).gameObject.GetComponent<GunShoot>().delayDefault -= cooldownDecrease;
                }
            }


            Destroy(gameObject);
        }
    }
}
