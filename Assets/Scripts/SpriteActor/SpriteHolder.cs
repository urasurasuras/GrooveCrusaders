using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for GO that contains sprite holders to be instantiated
/// </summary>
public class SpriteHolder : MonoBehaviour
{   

    internal void SpawnSprite(GameObject spritePrefab, Vector3 position)
    {
        Instantiate(spritePrefab, transform);
    }
}
