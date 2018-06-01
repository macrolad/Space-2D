using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public float MaxSpawn;
    public Spawnable[] ObjectsToSpawn;

    private void Start()
    {
        Spawn();
    }

    public Vector2 SpawnPos()
    {
        float x = Random.Range(-GameParameters.instance.MapHalfExtends.x, GameParameters.instance.MapHalfExtends.x);
        float y = Random.Range(-GameParameters.instance.MapHalfExtends.y, GameParameters.instance.MapHalfExtends.y);

        Vector2 spawnPos = new Vector2(x, y);
        return spawnPos;
    }

    public void Spawn()
    {
        float quantity = 0;
        int randomInt = 0;

        while (quantity < MaxSpawn)
        {
            randomInt = Random.Range(0, ObjectsToSpawn.Length);

            GameObject Obstacle = Instantiate(ObjectsToSpawn[randomInt].Prefab, SpawnPos(), Quaternion.identity);
            SpawnDebris(ObjectsToSpawn[randomInt], Obstacle);
            quantity += ObjectsToSpawn[randomInt].Size;
        }
    }

    public void SpawnDebris(Spawnable parentSP, GameObject parentGO)
    {
        if (parentSP.DebrisPrefab.Length == 0)
        {
            return;
        }
        float quantity = 0;
        int randomInt = 0;

        while (quantity < parentSP.Size)
        {
            randomInt = Random.Range(0, parentSP.DebrisPrefab.Length);

            GameObject debris = Instantiate(parentSP.DebrisPrefab[randomInt].Prefab, SpawnPos(), Quaternion.identity);
            SpawnDebris(parentSP.DebrisPrefab[randomInt], debris);
            quantity += parentSP.DebrisPrefab[randomInt].Size;

            parentGO.GetComponent<_BaseHealth>().DebrisList.Add(debris);
            debris.SetActive(false);
        }
    }
}
