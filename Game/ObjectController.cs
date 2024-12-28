using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectController : MonoBehaviour
{
    public float jumpForce = 7.0f;            
    public float groundCheckDistance = 0.1f;  
    public LayerMask groundLayer;              

    private Rigidbody rb;                     
    private bool isGrounded;                  

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        CheckGroundStatus();

        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void CheckGroundStatus()
    {
        
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    private void Jump()
    {
        
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); 
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
