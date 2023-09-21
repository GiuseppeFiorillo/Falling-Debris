using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    private bool isDying = false;
    private float dyingTimer = 3f;

    // Update is called once per frame
    void Update()
    {
        if(isDying)
        {
            dyingTimer -= Time.deltaTime;
            if(dyingTimer < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if(collision.GetComponent<playerHealth>().takeDamage()) { Destroy(this.gameObject); }
        }
        else
        {
            GetComponent<BoxCollider2D>().isTrigger = false;   
            isDying = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<playerHealth>().takeDamage();
            if(collision.gameObject.GetComponent<playerHealth>().getCanTakeDamage())
                Destroy(this.gameObject);
        }
    }
}
