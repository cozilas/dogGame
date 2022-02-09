using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] GameObject[] tilePrefabs;
    [SerializeField] float zSpawn = 0;
    [SerializeField] float tileLength=31;
    [SerializeField] int numberOfTiles = 5;
    [SerializeField] Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
       for(int i=0;i < numberOfTiles;i++){
           if(i==0){
               SpawnTile(0);
           }else{
                SpawnTile(Random.Range(1,tilePrefabs.Length));
           }
       }
    }
    void Update()
    {
        if(playerTransform.position.z - 35>zSpawn-(numberOfTiles*tileLength)){
            SpawnTile(Random.Range(0,tilePrefabs.Length));

            StartCoroutine(countTime(20));
        }
    }

    public void SpawnTile(int tileIndex){
        GameObject go = Instantiate(tilePrefabs[tileIndex],transform.forward * zSpawn,transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile(){
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    IEnumerator countTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        DeleteTile();
    }
}
