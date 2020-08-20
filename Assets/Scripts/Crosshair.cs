using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    Player owner;
    SpriteRenderer SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        owner = transform.parent.gameObject.GetComponent<Player>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color tmp = SpriteRenderer.color;
        tmp.a = (transform.localPosition.magnitude * owner.cfg.ch_fade)- owner.cfg.ch_deadzone;
        SpriteRenderer.color = tmp;
    }
}
