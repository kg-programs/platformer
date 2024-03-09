using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float groundCheckDistance = -1;
    [SerializeField] LayerMask enviromentOnly;
    [SerializeField] Animator ani;
    [SerializeField] PlayerStats stats;
    Rigidbody rb;
    float forwardMovementInput;
    float rightMovementInput;
    bool onGround = true;

    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        stats.health = stats.maxHealth;
        stats.coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        onGround = (Physics.Raycast(transform.position, Vector3.up * -1, groundCheckDistance*-1, enviromentOnly));
        forwardMovementInput = Input.GetAxis("Vertical");
        rightMovementInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            ani.SetTrigger("jump");
        }
        
        Debug.DrawLine(transform.position, transform.position + transform.up * groundCheckDistance, Color.red);

        var movementVector = new Vector3(forwardMovementInput, 0, rightMovementInput);
        
        ani.SetFloat("speed",movementVector.magnitude);
        ani.transform.forward = movementVector;
        if(transform.position.y < -5)
        {
            SceneManager.LoadScene("GameOver");
        }
        if(stats.health <=0 ) {
            SceneManager.LoadScene("GameOver");
        }
        if(stats.coins >= 10)
        {
            SceneManager.LoadScene("YouWin");
        }
    }

    private void FixedUpdate()
    {

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camForward.Normalize();

        camRight.y = 0;
        camRight.Normalize();

        Vector3 forwardRelative = forwardMovementInput * camForward;
        Vector3 rightRelative = rightMovementInput * camRight;

        Vector3 movementVector = ((forwardRelative)+(rightRelative)).normalized * speed;
        movementVector.y = rb.velocity.y;
        rb.velocity = movementVector;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            ani.SetTrigger("hit");
        }
    }
}
