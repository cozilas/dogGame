using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomObsticle : MonoBehaviour { 
    public GameObject fire;
    public GameObject barrel;
    public GameObject rockForSliding;
    public GameObject redBone;
    public GameObject greenBone;
    public GameObject blueBone;

    private float randomNum;
    // Start is called before the first frame update
    void Start()
    {
   
        randomNum = Random.Range(0f, 100f);

        if (randomNum < 5)//barel
        {
            Destroy(fire);
            Destroy(rockForSliding);
            Destroy(redBone);
            Destroy(greenBone);
            Destroy(blueBone);
        }
        else if (randomNum < 20)//rock
        {
            Destroy(fire);
            Destroy(barrel);
            Destroy(redBone);
            Destroy(greenBone);
            Destroy(blueBone);
        }
        else if (randomNum < 23)
        {
            gameObject.GetComponent<CharacterController>().enabled = false; 
            Destroy(fire);
            Destroy(barrel);
            Destroy(rockForSliding);
            randomNum = Random.Range(0, 3);
            Debug.Log(randomNum);
            if(randomNum == 0)
            {
                Destroy(greenBone);
                Destroy(blueBone);
            }else if (randomNum == 1)
            {
                Destroy(redBone);
                Destroy(blueBone);
            }
            else
            {
                Destroy(redBone);
                Destroy(greenBone);
            }
            
        }
        else {
            Destroy(barrel);
            Destroy(rockForSliding);
            Destroy(redBone);
            Destroy(greenBone);
            Destroy(blueBone);
        }

    }
}
