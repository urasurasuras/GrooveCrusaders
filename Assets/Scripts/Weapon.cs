using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Vector3 dirDiff;

    [SerializeField] GameObject owner, crosshair;

    public GameObject sprite;
    public Actor spriteActor;
    public float rotationDZ;

    // public GameObject muzzle;

    public GameObject projectilePrefab;
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
            
            transform.rotation = Quaternion.Euler(0, 0,rotationZ);
            sprite.transform.rotation = Quaternion.Euler(0, 0,rotationZ);
        }
    }
    public void Attack()
    {
        // Instantiate(projectilePrefab, muzzle.transform.position, transform.rotation);
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
