using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedRandomRoads : MonoBehaviour
{
    private int weight;
    private GameObject roadPrefab;

    public WeightedRandomRoads(GameObject _roadPrefab, int _weight)
    {
        weight = _weight;
        roadPrefab = _roadPrefab;
    }
   
    public void SetWeight(int newWeight)
    {
        weight = newWeight;
    }
    public int GetWeight()
    {
        return weight;
    }

    public void SetRoadPrefab(GameObject newRoadPrefab)
    {
        roadPrefab = newRoadPrefab;
    }
    public GameObject GetRoadPrefab()
    {
        return roadPrefab;
    }
}
