
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    public float zSpawn = 0;
    public float roadLenght = 100;
    public int numberOfRoads = 16;

    private List<GameObject> activeRoads = new List<GameObject>();

    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfRoads; i++)
        {
            if(i == 0)
            {
                SpawnRoad(0);
            }
            else
            {  
                //SpawnRoad(Random.Range(0, roadPrefabs.Length));
                SpawnRoad(GetRandomRoadIndex());
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z> zSpawn - (numberOfRoads * roadLenght))
        {
            SpawnRoad(Random.Range(0, roadPrefabs.Length));
            if (playerTransform.position.z - 100 > roadPrefabs[0].transform.position.z)
                DeleteTile(); 
        }
    }

    public void SpawnRoad(int roadIndex)
    {
        GameObject go = Instantiate(roadPrefabs[roadIndex], transform.forward * zSpawn, transform.rotation);
        activeRoads.Add(go);
        zSpawn += roadLenght;
    }

    private void DeleteTile()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);

    }

    public int GetRandomRoadIndex()
    {
        int[] weightList = new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 5, 5, 5, 5, 5, 5 };

        int totalWeight = 0;
        System.Array.ForEach(weightList, delegate (int i) { totalWeight += i; });

        int randomNumber = Random.Range(0, totalWeight);
        int selectedRoadIndex = 0;
        for(int i = 0; i < roadPrefabs.Length; i++)
        {
            if(randomNumber < weightList[i])
            {
                selectedRoadIndex = i;
                break;
            }

            randomNumber = randomNumber - weightList[i];
        }
        return selectedRoadIndex;
    }
}
