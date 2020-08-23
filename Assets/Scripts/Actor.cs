using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MasterInput;

public class Actor : MonoBehaviour
{
    public Sprite frontSprite;
    public Sprite backSprite;

    // Start is called before the first frame update
    void Start()
    {
        //var pc = GetComponent<IPlayerActions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Flip(bool facing)
    {
        if (facing)
        {
            GetComponent<SpriteRenderer>().sprite = backSprite;
        }else if (!facing)
        {
            GetComponent<SpriteRenderer>().sprite = frontSprite;
        }
        //GetComponent<SpriteRenderer>().flipX = facing;
    }
    public void ReverseRenderOrder()
    {
        GetComponent<SpriteRenderer>().sortingOrder *= -1;
        //print("New order is: " + GetComponent<SpriteRenderer>().sortingOrder);
    }
}
