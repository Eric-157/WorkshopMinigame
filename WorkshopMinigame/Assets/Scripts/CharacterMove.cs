using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    public bool gun = false;
    public GameObject projectilePrefab;
    public float horizontalInput;
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
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.forward * Time.deltaTime * speed * -horizontalInput);
            if (jump == true && Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(jumpVector * jumpForce, ForceMode.Impulse);
            }
            if (gun == true && Input.GetKeyDown(KeyCode.LeftShift))
            {
                Instantiate(projectilePrefab, transform.position - new Vector3(0.0f, 0.0f, 1.0f), projectilePrefab.transform.rotation);
            }
        }
    }

    // Kills the chicken on collision with cars
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            alive = false;
            Destroy(other.gameObject);
            SceneManager.LoadScene("SampleScene");
        }
        if (other.tag == "TallCar")
        {
            alive = false;
            Destroy(other.gameObject);
            SceneManager.LoadScene("SampleScene");
        }
        if (other.tag == "Jump")
        {
            jump = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "Gun")
        {
            gun = true;
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
