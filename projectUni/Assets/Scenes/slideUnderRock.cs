using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideUnderRock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject plus5;
    void Start()
    {
        plus5.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"&& !PlayerController.hasRedBone)
        {
            plus5.SetActive(true);
            StartCoroutine(destroy(1));
            PlayerManager.numberOfCoins += 5;
        }
    }
    IEnumerator destroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        plus5.SetActive(false);
    }
}
