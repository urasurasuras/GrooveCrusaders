using System.Collections;
using System.Collections.Generic;
using SpatooGame.Interfaces;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamagableWithHealth, IElectrocutable
{

    Rigidbody2D _rb;

    public float currentHP { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public float maxHP => throw new System.NotImplementedException();

    public bool isSupposedToHaveShield => throw new System.NotImplementedException();

    public float currentSP { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public float maxSP => throw new System.NotImplementedException();

    [SerializeField] List<Collider2D> _colliders;
    public List<Collider2D> Colliders => _colliders;

    public UnityEvent Death => throw new System.NotImplementedException();
    public LightningBolt2D LightningBolt2D;

    public Vector3 offsetStart = new Vector3(-0.18f, 1.24f);
    public Vector3 offsetEnd = new Vector3(0.18f, 1.24f);
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(new Vector2(1.1f, 1.1f), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        LightningBolt2D.startPoint = transform.position + offsetStart;

        LightningBolt2D.endPoint = transform.position + offsetEnd;

        // LightningBolt2D.transform.position.Set(
        //     LightningBolt2D.transform.position.x,
        //     LightningBolt2D.transform.position.y,
        //     offsetStart.z
        //  );
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // _rb.velocity = Vector2.Reflect(_rb.velocity.normalized, col.contacts[0].normal) * ;
    }

    void TakeDamage(float damage)
    {
        print($"Taken {damage} damage");
    }

    public void TakeDamage(float damageAmount, Transform damageSource, DamageSourceType damageSourceType)
    {
        throw new System.NotImplementedException();
    }

    public void Electrocute()
    {
        LightningBolt2D.FireOnce();
    }
}
