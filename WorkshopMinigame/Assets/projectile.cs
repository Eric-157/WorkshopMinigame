using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float startLocation;
    // Start is called before the first frame update
    void Start()
    {
        startLocation = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 10.0f);
        
        if (transform.position.z < startLocation -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TallCar") {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        
    }
}
