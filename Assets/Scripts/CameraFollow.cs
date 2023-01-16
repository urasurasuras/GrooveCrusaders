using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    public GameObject Crosshair;
    public Vector3 Offset;

    // Update is called once per frame
    void Update()
    {
        float distance = (Player.transform.position - Crosshair.transform.position).magnitude;
        // print(distance);
        transform.position = Vector3.Lerp(Player.transform.position, Crosshair.transform.position, 0.5f);
        // Offset *= distance;
        transform.position += Offset;
    }
}
