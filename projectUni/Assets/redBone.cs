using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class redBone : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    GameObject shield;
    void Start()
    {
        player = GameObject.Find("Player");
        shield = GameObject.Find("shield");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("eyoo");
            shield.GetComponent<MeshRenderer>().enabled = true;
            PlayerController.hasRedBone = true;
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        StartCoroutine(countTime(10));       
    }
    IEnumerator countTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        shield.GetComponent<MeshRenderer>().enabled = false;
        PlayerController.hasRedBone = false;
    }
}
