using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Acceleration = 0.2f;
    public float MoveSpeed = 3;
    public float JumpHeight = 5;
    public Transform GroundCheck;
    public Camera camera;
    private bool isGrounded = false;
    private float MoveInput;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.3f, 3);
        if (isGrounded)
        {
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, new Vector2(MoveInput*MoveSpeed, rb.linearVelocity.y), Acceleration*Time.deltaTime*60);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x*0.75f,JumpHeight);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, new Vector2(MoveInput*MoveSpeed, rb.linearVelocity.y), (Acceleration*0.5f*Time.deltaTime*60)*math.abs(MoveInput));
        }
        camera.transform.position = Vector3.Lerp(camera.transform.position, transform.position + new Vector3(0,0,-10), 0.1f*Time.deltaTime*60);
        
    }
}
