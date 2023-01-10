using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Vector3 dirDiff;

    [SerializeField] GameObject owner, crosshair;

    public GameObject sprite;
    public Actor spriteActor;
    public float rotationDZ;
    public GameObject LightningBoltGameObject;
    LightningBolt2D lightningBolt;
    [SerializeField] GameObject tip;

    // Start is called before the first frame update
    void Start()
    {
        owner = transform.parent.gameObject;
        //crosshair = owner.transform.GetChild(0).gameObject;
        if (!spriteActor)
            spriteActor = sprite.GetComponent<Actor>();
        spriteActor.GetComponent<SpriteRenderer>().sortingOrder = 1;
        if (!crosshair)
            crosshair = transform.Find("Crosshair").gameObject;

        lightningBolt = LightningBoltGameObject.GetComponent<LightningBolt2D>();
        
        //lightningBolt = bolt.GetComponent<LightningBoltScript>();
        //lightningBolt.StartObject = tip;
        //lightningBolt.EndObject = crosshair;

    }

    void Update()
    {
        var diff = owner.transform.position - crosshair.transform.position;
        dirDiff = diff;
        if ((diff.magnitude > rotationDZ)) {
            diff.Normalize();

            var rotationZ = Mathf.Atan2(
                diff.y,
                diff.x
            ) * Mathf.Rad2Deg - 180;
            
            
            // transform.Rotate(0,0, rotationZ);
            // sprite.transform.Rotate(0,0, rotationZ);
            
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotationZ);
            sprite.transform.rotation = transform.rotation;
        }

        lightningBolt.startPoint = new Vector3(tip.transform.position.x, tip.transform.position.y, tip.transform.position.z - 1.1f);
        lightningBolt.endPoint = new Vector3(crosshair.transform.position.x, crosshair.transform.position.y, crosshair.transform.position.z - 1.1f);
    }
    public void Attack()
    {
        lightningBolt.FireOnce();

        print("Attack");
    }

    public void WeaponFlipSprite(bool nextFacing)
    {
        spriteActor.Flip(nextFacing);
        spriteActor.ReverseRenderOrder();
        
    }

    #region Debug
    #if UNITY_EDTIOR
    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(owner.transform.position, crosshair.transform.position);
    }
    #endif
    #endregion
}
