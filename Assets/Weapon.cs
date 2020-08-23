using UnityEngine;

public class Weapon : MonoBehaviour
{
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
        var diff = transform.position - crosshair.transform.position;
        if ((diff.magnitude > rotationDZ)) {
            diff.Normalize();

            transform.rotation = Quaternion.Euler(
            0,
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
}
