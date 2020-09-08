using UnityEngine;
using UnityEngine.InputSystem;
using Debooger;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    Player owner;
    SpriteRenderer SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (!owner)//TODO: make this a convention
        owner = transform.parent.gameObject.GetComponent<Player>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Color tmp = SpriteRenderer.color;
        //tmp.a = (transform.localPosition.magnitude * owner.cfg.ch_fade)- owner.cfg.ch_deadzone;
        //SpriteRenderer.color = tmp;
    }
    public void Aim(InputAction.CallbackContext ctx)
    {
        owner.aim = ctx.ReadValue<Vector2>();
        //print(owner.aim.ToString());

        if (ctx.control.shortDisplayName == "RS")
        {
            transform.localPosition = owner.aim * owner.range;
        }
        else
        {
            GetWors();
        }
    }
    void GetWors()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        Vector2 mousePos = owner.aim;

        // Get raycast using collider
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out var hit))
        {
            // transform.position = hit.point;
            transform.position = new Vector3(
                hit.point.x,
                hit.point.y,
                -.1f)
                ;
            //print(hit.collider.ToString());
        }

        // transform.position = point;

        //print("Screen pixels: " + Camera.main.pixelWidth + ":" + Camera.main.pixelHeight);
        //print("Mouse position: " + mousePos);
        //print("World position: " + hit.point.ToString("F3"));
        DebugManager.Instance.Deboog("World pos", hit.point);
    }
}
