using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class greenBone : MonoBehaviour
{
    GameObject doublePointsHud;
    void Start()
    {

        doublePointsHud = GameObject.Find("doublePoints");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("eyoo");
            doublePointsHud.GetComponent<Image>().enabled = true;
            PlayerController.hasGreenBone = true;
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
        doublePointsHud.GetComponent<Image>().enabled = false;
        PlayerController.hasGreenBone = false;
    }
}
