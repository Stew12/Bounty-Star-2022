using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls;

    public GameObject ship;

    public GameObject laser;

    /* For where the laser appears on the ship body */
    public float laserSpawnDist = 10.0f;
    public float laserSpawnVert = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        controls.Gameplay.Fire.performed += ctx => FirePrimaryShot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirePrimaryShot()
    {
        /* Twin lasers */
        GameObject firedLaser = Instantiate(laser, new Vector3(ship.transform.position.x + laserSpawnDist, ship.transform.position.y + laserSpawnVert, ship.transform.position.z), Quaternion.identity);
        
        firedLaser.GetComponent<PlayerLaser>().shipSpeed = transform.parent.transform.parent.GetComponent<RailMove>().speed;

        firedLaser = Instantiate(laser, new Vector3(ship.transform.position.x - laserSpawnDist, ship.transform.position.y + laserSpawnVert, ship.transform.position.z), Quaternion.identity);

        firedLaser.GetComponent<PlayerLaser>().shipSpeed = transform.parent.transform.parent.GetComponent<RailMove>().speed;
    }

}
