using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float verticalInput;
    public float speed = 3.0f;
    public bool alive = true;
    public bool jump = false;
    public float jumpForce = 4.5f;
    public bool isGrounded;
    public Vector3 jumpVector;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpVector = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // If the chicken is alive, move forward with W and S, if not: disables movement
        if (alive == true)
        {
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.right * Time.deltaTime * speed * verticalInput);
            if (jump == true && Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(jumpVector * jumpForce, ForceMode.Impulse);
            }
        }
    }

    // Kills the chicken on collision with cars
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car") {
            alive = false;
            Destroy(other.gameObject);
        }
        if (other.tag == "Jump")
        {
            jump = true;
            Destroy(other.gameObject);
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
