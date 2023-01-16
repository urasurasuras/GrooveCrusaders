using SpatooGame.Interfaces;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Vector3 dirDiff;

    [SerializeField] GameObject owner, crosshair;
    Crosshair Crosshair;

    public GameObject sprite;
    public Actor spriteActor;
    public float rotationDZ;
    public LightningBolt2D LightningBolt;
    public LightningBolt2D Electrification;
    [SerializeField] GameObject tip;

    // Start is called before the first frame update
    void Start()
    {
        owner = transform.parent.gameObject;
        //crosshair = owner.transform.GetChild(0).gameObject;
        if (!spriteActor)
            spriteActor = sprite.GetComponent<Actor>();
        if (!crosshair)
            crosshair = transform.Find("Crosshair").gameObject;

        Crosshair = crosshair.GetComponent<Crosshair>();

        //lightningBolt = bolt.GetComponent<LightningBoltScript>();
        //lightningBolt.StartObject = tip;
        //lightningBolt.EndObject = crosshair;

    }

    void Update()
    {
        var diff = owner.transform.position - crosshair.transform.position;
        dirDiff = diff;
        if ((diff.magnitude > rotationDZ))
        {
            diff.Normalize();

            var rotationZ = Mathf.Atan2(
                diff.y,
                diff.x
            ) * Mathf.Rad2Deg - 180;


            // transform.Rotate(0,0, rotationZ);
            // sprite.transform.Rotate(0,0, rotationZ);

            transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, rotationZ);
            sprite.transform.localRotation = transform.localRotation;
        }

        LightningBolt.startPoint = new Vector3(tip.transform.position.x, tip.transform.position.y, tip.transform.position.z - 1.1f);

        var target = Crosshair.Target;
        if (target != null)
        {
            var x = target.Colliders[0].bounds.extents.x;
            var entPos = target.transform.position;
            Electrification.startPoint = entPos + new Vector3(-x, 0, -0.1f);
            Electrification.endPoint = entPos + new Vector3(x, 0, -0.1f);

        }
    }
    public void Attack()
    {
        LightningBolt.FireOnce();
        LightningBolt.endPoint = new Vector3(crosshair.transform.position.x, crosshair.transform.position.y, crosshair.transform.position.z - 1.1f);

        var target = Crosshair.Target;
        if (target != null)
        {
            Electrify((IElectrocutable)target);
            print(target);
        }
    }

    void Electrify(IElectrocutable target)
    {
        target.Electrocute();
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
