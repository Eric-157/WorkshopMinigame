using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class CarMove : MonoBehaviour
{
    public float speed = 3f;
    public float leftBound = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the car across the screen
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        // Destroy if x position greater than left limit
        if (transform.position.x > leftBound)
        {
            Destroy(gameObject);
        }
    }
}
