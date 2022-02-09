using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueBone : MonoBehaviour
{
    GameObject magnetCollider;
    void Start()
    {

        magnetCollider = GameObject.Find("magnetCollider");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("eyoo");
            magnetCollider.GetComponent<BoxCollider>().enabled = true;
            PlayerController.hasBlueBone = true;
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
        magnetCollider.GetComponent<BoxCollider>().enabled = false;
        PlayerController.hasBlueBone = false;
    }
}
