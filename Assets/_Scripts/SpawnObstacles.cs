using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField]
    public Spawnable[] ObjectsToSpawn;

    [Space]
    public List<GameObject> DebrisList = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < ObjectsToSpawn.Length; i++)
        {
            SpawnPrefabs(ObjectsToSpawn[i]);
        }
    }

    public Vector2 SpawnPos()
    {
        float x = Random.Range(-GameParameters.instance.MapHalfExtends.x, GameParameters.instance.MapHalfExtends.x);
        float y = Random.Range(-GameParameters.instance.MapHalfExtends.y, GameParameters.instance.MapHalfExtends.y);

        Vector2 spawnPos = new Vector2(x, y);
        return spawnPos;
    }

    public void SpawnPrefabs(Spawnable spawnable)
    {
        for (int i = 0; i < spawnable.Quantity; i++)
        {
            GameObject Obstacle = Instantiate(spawnable.Prefab, SpawnPos(), Quaternion.identity);
            SpawnDebris(Obstacle, spawnable);
        }
    }

    public void SpawnDebris(GameObject obstacle, Spawnable spawnable)
    {
        if (spawnable.DebrisPrefab.Length == 0)
        {
            return;
        }
        else
        {
            float maxSpawn = spawnable.Prefab.GetComponent<_BaseHealth>().MaxHealth;
            int randomDebris = 0;

            while (maxSpawn > 0)
            {
                randomDebris = Random.Range(0, spawnable.DebrisPrefab.Length);
                GameObject newDebris = Instantiate(spawnable.DebrisPrefab[randomDebris]);

                maxSpawn -= newDebris.GetComponent<_BaseHealth>().MaxHealth;
                obstacle.GetComponent<_BaseHealth>().DebrisList.Add(newDebris);
                newDebris.SetActive(false);
            }
        }

    }
}
