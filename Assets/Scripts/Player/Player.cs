using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Acceleration = 0.5f;
    public float Friction = 0.95f;
    public float JumpHeight = 5;
    public Transform GroundCheck;
    private bool isGrounded = false;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.25f, 3);
        if (isGrounded)
        {
            rb.linearVelocity += new Vector2(Input.GetAxis("Horizontal")*(Acceleration*Time.deltaTime*60), 0);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x * Mathf.Pow(Friction, Time.deltaTime * 60f), rb.linearVelocity.y);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.linearVelocity += new Vector2(0,JumpHeight);
            }
        }
        else
        {

        }
        
    }
}
