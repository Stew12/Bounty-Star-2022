using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{   

    PlayerControls controls;

    [SerializeField] private Vector3 moveDirection;

    [SerializeField] private TrailRenderer trail;

    [SerializeField] private GameObject movePoint;

    [SerializeField] private Transform target;

    private Rigidbody rb;

    //[SerializeField] private PlayerFlightControl playerFlightControl;

    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;

    private bool canDash = true;
    public bool isDashing;

    private Vector2 controlStickXY;

    private Vector3 directionVector;


    // Start is called before the first frame update
    void Awake()
    {
        //controls = playerFlightControl.controls;
        

        //controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        //controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDashing)
        {
            //movePoint.transform.position = new Vector3 (movePoint.transform.position.x + moveDirection.x * Time.deltaTime * dashingPower, movePoint.transform.position.y + moveDirection.y * Time.deltaTime * dashingPower, movePoint.transform.position.z);;
            //target.transform.position = new Vector3 (target.transform.position.x + moveDirection.x * Time.deltaTime * dashingPower, target.transform.position.y + moveDirection.y * Time.deltaTime * dashingPower, target.transform.position.z);;
            //transform.parent.transform.position = new Vector3 (transform.parent.transform.position.x + moveDirection.x * Time.deltaTime * dashingPower, transform.parent.transform.position.y + moveDirection.y * Time.deltaTime * dashingPower, transform.parent.transform.position.z);
            //transform.position = new Vector3 (transform.position.x + moveDirection.x * Time.deltaTime * dashingPower, transform.position.y + moveDirection.y * Time.deltaTime * dashingPower, transform.parent.transform.position.z);
            //transform.position = new Vector3(transform.position.x + moveDirection.x * dashingPower * Time.deltaTime, transform.position.y + moveDirection.y * dashingPower * Time.deltaTime, transform.position.z);
            
            //transform.Translate(new Vector3(controlStickXY.x, controlStickXY.y, 0) * dashingPower, Space.World);
            movePoint.transform.Translate(new Vector3(controlStickXY.x, controlStickXY.y, 0) * dashingPower, Space.World);
            target.transform.Translate(new Vector3(controlStickXY.x, controlStickXY.y, 0) * dashingPower, Space.World);
        }
    }

    public void Dash(Vector2 xy)
    {
        Debug.Log("DASH");
        if (canDash)
        {
            Vector3 forward = Vector3.forward;
            forward.y = 0;
            forward = forward.normalized;
            Vector3 right = new Vector3(forward.z, 0, -forward.x);
            moveDirection = (xy.x * right + xy.y * forward).normalized;
            //moveDirection = target.position;
            
            controlStickXY = xy;

            StartCoroutine(DashAction());
        }
    }

    private IEnumerator DashAction()
    {
        canDash = false;
        isDashing = true;
        //rb.useGravity = false;
        //rb.velocity = moveDirection * dashingPower;

        //directionVector = (target.position - transform.position).normalized;
        //directionVector.z = 0;

        if (trail != null) trail.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        StartCoroutine(EndDash());
    }

    private IEnumerator EndDash()
    {
        if (trail != null) trail.emitting = false;
        isDashing = false;
       // rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
