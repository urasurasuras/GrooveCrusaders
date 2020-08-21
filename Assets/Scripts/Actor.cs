using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MasterInput;

public class Actor : MonoBehaviour
{
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
        GetComponent<SpriteRenderer>().flipX = facing;
    }
}
