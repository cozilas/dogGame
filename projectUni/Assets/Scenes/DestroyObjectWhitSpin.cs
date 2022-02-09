using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DestroyObjectWhitSpin : MonoBehaviour
{    private GameObject myObject;
    void Start()
    {
        myObject = GameObject.Find("Player");
    }
     void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    bool flag = false;
    void Update()
    {   if(flag)
         if(Input.GetKeyDown("s") || myObject.GetComponent<PlayerController>().IsDoubleTap())
        {
           DestroyGameObject();
        }
    }
    void OnTriggerStay (Collider player)
    {
       if(player.tag == "Player")
        {
            flag = true;
           
        }
    }
    void OnTriggerExit (Collider player)
    {
        if(player.tag == "Player")
        {
            flag = false;
           
        }
    }
}
