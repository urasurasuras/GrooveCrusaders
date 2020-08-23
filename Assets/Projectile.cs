using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject owner;
    public float speed;
    private void Start()
    {
        if (speed == 0) return;
        Vector3 force = transform.right * speed;

        gameObject.GetComponent<Rigidbody2D>().velocity = force;
        //print(gameObject.GetComponent<Rigidbody2D>().velocity.ToString());
        Destroy(this, 5);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("HIT");
        }
        //Instantiate(particle);
        //gameObject.SetActive(false);
    }
}
