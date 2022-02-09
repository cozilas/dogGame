using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsticleManager : MonoBehaviour
{
    public GameObject[] coinRow1;
    public GameObject[] coinRow2;
    public GameObject[] coinRow3;

    public GameObject[] fireRow1;
    public GameObject[] fireRow2;
    public GameObject[] fireRow3;

    private int shouldItHaveCoins;
    private int makeLessFires;

    private int currRandom=2;

    void Start()
    {
      
        shouldItHaveCoins = Random.Range(0, 10);
        if (shouldItHaveCoins == 0)
        {
          
 
            for (int i = 0; i < 11; i++)
            {
                Destroy(coinRow1[i]);
                Destroy(coinRow2[i]);
                Destroy(coinRow3[i]);
            }
        }
        else
        {           
            for (int i = 0; i < 11; i++)
            {

                if (currRandom == 1)
                {
                    Destroy(coinRow2[i]);
                    Destroy(coinRow3[i]);
                    currRandom = Random.Range(1, 3);
                    continue;
                }
                if (currRandom == 2)
                {
                    Destroy(coinRow1[i]);
                    Destroy(coinRow3[i]);
                    currRandom = Random.Range(1, 4);
                    continue;
                }
                if (currRandom == 3)
                {
                    Destroy(coinRow2[i]);
                    Destroy(coinRow1[i]);
                    currRandom = Random.Range(2, 4);
                    continue;
                }
            }
        }
        currRandom = Random.Range(1, 4);


        for (int i = 0; i < 6; i++)
        {
            makeLessFires = Random.Range(0, 3);
            if (currRandom == 1)
            {
                if (makeLessFires != 0) Destroy(fireRow1[i]);
                Destroy(fireRow2[i]);
                Destroy(fireRow3[i]);
                currRandom = Random.Range(1, 3);
                continue;
            }
            if (currRandom == 2)
            {
                if (makeLessFires != 0) Destroy(fireRow2[i]);
                Destroy(fireRow1[i]);
                Destroy(fireRow3[i]);
                currRandom = Random.Range(1, 4);
                continue;
            }
            if (currRandom == 3)
            {
                if (makeLessFires != 0) Destroy(fireRow3[i]);
                Destroy(fireRow2[i]);
                Destroy(fireRow1[i]);
                currRandom = Random.Range(2, 4);
                continue;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
