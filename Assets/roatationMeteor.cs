using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class roatationMeteor : MonoBehaviour
{
    private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(-250, -750);   
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().AddForce(transform.right * rotationSpeed * Time.deltaTime);
    }
}
