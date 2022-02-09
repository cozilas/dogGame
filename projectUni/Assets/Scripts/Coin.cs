using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    bool pullCoinTowardsPlayer = false;
    GameObject playerPos;
    private void Start()
    {
        playerPos = GameObject.Find("Player");
    }
    void Update()
    {
        transform.Rotate(80*Time.deltaTime,0,0);

        if (pullCoinTowardsPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, playerPos.transform.position , 7 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (other.tag == "Player"){

            AudioManager.instance.Play("PickUpCoin");
            if (PlayerController.hasGreenBone)
            {
                PlayerManager.numberOfCoins += 1*2;
            }
            else
            {
                PlayerManager.numberOfCoins += 1;
            }
            
            Destroy(gameObject);
        }else if (other.tag == "magnetCollider" && PlayerController.hasBlueBone)
        {
            pullCoinTowardsPlayer = true;
            Debug.Log("boing");
        }


        if (other.tag == "Obstacle")
        {
            Destroy(gameObject);
        }

    }

}
