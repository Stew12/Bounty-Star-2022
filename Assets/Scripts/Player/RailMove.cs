using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMove : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
    }
}
