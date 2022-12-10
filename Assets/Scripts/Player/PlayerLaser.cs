using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    //public GameObject player;

    private float moveSpeed = 3.5f;

    public float travelTime = 0.2f;

    [HideInInspector] public float shipSpeed;

    [SerializeField] private float speedMultiplier;

    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = GameObject.FindGameObjectWithTag("FarReticle").transform.position;

        transform.LookAt(targetPos);
    }

    // Update is called once per frame
    void Update()
    {
        travelTime -= Time.deltaTime;

        moveSpeed = shipSpeed * speedMultiplier;

        Debug.Log(moveSpeed);

        float step = moveSpeed * Time.deltaTime;

        transform.position += transform.forward * step;

        if (travelTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
