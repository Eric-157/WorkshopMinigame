using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float verticalInput;
    public float speed = 3.0f;
    public bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the chicken is alive, move forward with W and S, if not: disables movement
        if (alive == true)
        {
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.right * Time.deltaTime * speed * verticalInput);
        }
    }

    // Kills the chicken on collision with cars
    private void OnTriggerEnter(Collider other)
    {
        alive = false;
        Destroy(other.gameObject);
    }
}
