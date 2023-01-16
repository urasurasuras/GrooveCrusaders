using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Material))]
public class Actor : MonoBehaviour
{
    SpriteRenderer _sr;
    public Sprite frontSprite;
    public Sprite backSprite;
    public bool outline;

    // Start is called before the first frame update
    void Start()
    {
        //var pc = GetComponent<IPlayerActions>();
        _sr = GetComponent<SpriteRenderer>();
        // print($"old order of {this} is: {_sr.sortingOrder}");

    }

    // Update is called once per frame
    void Update()
    {
        ToggleHighlight(outline);
        // print(this.name + _sr.material.GetFloat("_OutlineEnabled"));
    }
    public void Flip(bool facing)
    {
        if (facing)
        {
            _sr.sprite = backSprite;
        }
        else if (!facing)
        {
            _sr.sprite = frontSprite;
        }
        //GetComponent<SpriteRenderer>().flipX = facing;
    }
    public void ReverseRenderOrder()
    {
        // print($"old order of {this} is: {_sr.sortingOrder}");
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            transform.localPosition.y,
            transform.localPosition.z * -1);
        // print(transform.localPosition);
        // print(transform.position);
    }

    public void ToggleHighlight(bool boolean)
    {
        if (boolean) _sr.material.SetFloat("_OutlineEnabled", 1);
        else _sr.material.SetFloat("_OutlineEnabled", 0);
    }
}
