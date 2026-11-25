using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Acceleration = 0.2f;
    public float WalkSpeed = 3;
    public float SprintSpeed = 6;
    public float JumpHeight = 5;
    public float MaxSlope = 0.25f;
    private float LastMoveDirection = 1;
    public Transform GroundCheck;
    public GameObject SpriteHolder;
    public Camera camera;
    private bool isGrounded = false;
    private float MoveInput;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float MoveSpeed = 0;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = SprintSpeed;
        }
        else
        {
            MoveSpeed = WalkSpeed;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -2), 2, ~(1 << gameObject.layer));
        //SpriteHolder.transform.rotation = quaternion.Euler(0,0,MathF.Sin(Time.time*100)*0.25f);
        MoveInput = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, 3);
        if (isGrounded && math.abs(hit.normal.x) < MaxSlope)
        {
            SpriteHolder.transform.up = hit.normal;
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, new Vector2(MoveInput*MoveSpeed, rb.linearVelocity.y), Acceleration*Time.deltaTime*60);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x*0.75f,JumpHeight);
            }
        }
        else
        {
            SpriteHolder.transform.up = Vector2.up;
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, new Vector2(MoveInput*MoveSpeed, rb.linearVelocity.y), (Acceleration*0.5f*Time.deltaTime*60)*math.abs(MoveInput));
        }
        if (MoveInput > 0)
        {
            LastMoveDirection = 1;
        }
        else
        {
            LastMoveDirection = -1;
        }
        SpriteHolder.transform.localScale = new Vector3(LastMoveDirection,1,1);
        camera.transform.position = Vector3.Lerp(camera.transform.position, transform.position + new Vector3(0,0,-10), 0.1f*Time.deltaTime*60);
        
    }
}
