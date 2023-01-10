using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for GO that contains sprite holders to be instantiated
/// </summary>
public class ActorController : MonoBehaviour
{   
    public List<Actor> actors = new List<Actor>();

    void Start()
    {
        if (actors.Count == 0)
        {
            foreach (Transform child in transform)
            {
                actors.Add(child.GetComponent<Actor>());
            }
        }

        transform.Rotate(GameManager.Instance.cfg.cam_tilt, 0, 0);
    }
    internal void SpawnSprite(GameObject spritePrefab, Vector3 position)
    {
        Instantiate(spritePrefab, transform);
    }

    public void FlipAndReverseActorsSprites(bool facing)
    {
        foreach (Actor actor in actors)
        {
            actor.Flip(facing);
            actor.ReverseRenderOrder();
        }
    }
}
