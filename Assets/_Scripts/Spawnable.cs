﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Spawnable", menuName = "Space2D/Spawnable", order = 1)]
public class Spawnable : ScriptableObject
{
    public GameObject Prefab;
    public float Size;

    public Spawnable[] DebrisPrefab;
}
