using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscrpit : MonoBehaviour
{

    public GameObject plane;
    public GameObject sppnt;
    public Rigidbody rb;

    public float thrust;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (transform.position.y < plane.transform.position.y - 10)
        {
            Debug.Log("getting back to initial position");
            rb.velocity = Vector3.zero;
            transform.position = sppnt.transform.position;

        }

    }
}