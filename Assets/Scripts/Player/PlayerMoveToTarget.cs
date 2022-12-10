using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveToTarget : MonoBehaviour
{
    public float moveSpeed = 25.0f;

    public float dashSpeed = 50.0f;

    private PlayerDash playerDash;

    public Transform target;

    public GameObject ship;

    private Vector2 position;
    private Camera cam;

    void Start()
    {
        position = gameObject.transform.position;

        playerDash = GetComponent<PlayerDash>();

        cam = Camera.main;
    }

    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        float dashStep = dashSpeed * Time.deltaTime;

        // move sprite towards the target location
        if (!playerDash.isDashing)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else
        {
            //transform.position = Vector3.MoveTowards(transform.position, target.position, dashStep);

            

        }
    }
}
