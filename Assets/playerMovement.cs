using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb;
    public float jumpAmount = 1000;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        Vector3 tempVect = new Vector2(h, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
    }
}