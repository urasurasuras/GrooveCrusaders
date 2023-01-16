using System.Collections;
using System.Collections.Generic;
using SpatooGame.Interfaces;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamagableWithHealth, IElectrocutable
{

    Rigidbody2D _rb;

    // HEALTH POINTS
    [SerializeField]
    private float _currentHP = 100;
    public float currentHP
    {
        get { return _currentHP; }
        set { _currentHP = value; }
    }

    // HEALTH POINTS
    [SerializeField]
    private float _maxHP = 100;
    public float maxHP
    {
        get { return _maxHP; }
        set { _maxHP = value; }
    }
    public bool isSupposedToHaveShield => throw new System.NotImplementedException();

    public float currentSP { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public float maxSP => throw new System.NotImplementedException();

    [SerializeField] List<Collider2D> _colliders;
    public List<Collider2D> Colliders => _colliders;

    UnityEvent _death = new UnityEvent();
    public UnityEvent Death => _death;
    public LightningBolt2D LightningBolt2D;

    public Vector3 offsetStart = new Vector3(-0.18f, 1.24f);
    public Vector3 offsetEnd = new Vector3(0.18f, 1.24f);
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(new Vector2(1.1f, 1.1f), ForceMode2D.Impulse);
        Death.AddListener(delegate
        {
            Destroy(gameObject);
        });
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

    public void Electrocute()
    {
        LightningBolt2D.FireOnce();
    }

    public void TakeDamage(float damageAmount, Transform damageSource)
    {
        print($"Taken {damageAmount} damage");
        _currentHP = Mathf.Clamp(_currentHP - damageAmount, 0, _maxHP);
        if (_currentHP <= 0)
            Death.Invoke();
    }
}
