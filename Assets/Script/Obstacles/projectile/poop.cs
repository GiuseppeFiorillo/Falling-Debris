using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !collision.gameObject.GetComponent<PlayerMovement2D>().isSlowed)
        {
            collision.gameObject.GetComponent<PlayerMovement2D>().speed = 4f;
            collision.gameObject.GetComponent<PlayerMovement2D>().isSlowed = true;
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.name == "Terrain")
        {
            Destroy(this.gameObject);
        }
    }
}
