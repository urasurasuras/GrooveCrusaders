using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Vector3 dirDiff;
    GameObject owner;
    GameObject crosshair;

    public float rotationDZ;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        owner = transform.parent.gameObject;
        crosshair = owner.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var diff = owner.transform.position - crosshair.transform.position;
        dirDiff = diff;
        if ((diff.magnitude > rotationDZ)) {
            diff.Normalize();

            transform.rotation = Quaternion.Euler(
            -20,
            0,
            Mathf.Atan2(
                diff.y,
                diff.x
                ) * Mathf.Rad2Deg - 180
            );

        }
    }
    public void Attack()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
    #region
    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(owner.transform.position, crosshair.transform.position);
    }
    #endregion
}
