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
    }

    // Update is called once per frame
    void Update()
    {
        if (outline){
            ToggleHighlight(true);
        }else{
            ToggleHighlight(false);
        }
        
        // print(this.name + _sr.material.GetFloat("_OutlineEnabled"));
    }
    public void Flip(bool facing)
    {
        if (facing)
        {
            _sr.sprite = backSprite;
        }else if (!facing)
        {
            _sr.sprite = frontSprite;
        }
        //GetComponent<SpriteRenderer>().flipX = facing;
    }
    public void ReverseRenderOrder()
    {
        _sr.sortingOrder *= -1;
        //print("New order is: " + GetComponent<SpriteRenderer>().sortingOrder);
    }

    public void ToggleHighlight(bool boolean)
    {
        if (boolean)        _sr.material.SetFloat("_OutlineEnabled", 1);
        else                _sr.material.SetFloat("_OutlineEnabled", 0);
    }
}
