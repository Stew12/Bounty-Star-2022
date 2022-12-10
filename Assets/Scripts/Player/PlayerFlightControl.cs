using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlightControl : MonoBehaviour
{
    [HideInInspector] public PlayerControls controls;

    [SerializeField] private PlayerDash playerDash;

    public GameObject Player;

    public float moveSpeed = 75.0f;

    private Vector2 move;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Fire.performed += ctx => Fire();

        controls.Gameplay.Dash.performed += ctx => playerDash.Dash(move);

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime * moveSpeed;

        if (!playerDash.isDashing)
        {
            transform.Translate(m, Space.World);
        }
    }

    void Fire()
    {
        Player.GetComponent<PlayerShoot>().FirePrimaryShot();   
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
