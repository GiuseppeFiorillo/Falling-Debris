using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    private bool isDying = false;
    private bool isGrabbing = false;
    private float dyingTimer = 3f;
    private float grabbingTimer = 2f;

    // Update is called once per frame
    void Update()
    {
        if(isDying && !isGrabbing)
        {
            dyingTimer -= Time.deltaTime;
            if(dyingTimer < 0)
            {
                Destroy(this.gameObject);
            }
        }

	 if(isGrabbing)
        {
            grabbingTimer -= Time.deltaTime;
            if(grabbingTimer <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Terrain" && GameObject.Find("Player") != null)
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            GetComponent<Animator>().SetBool("isFalling", false);
            Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), GameObject.Find("Player").GetComponent<CircleCollider2D>());
            isDying = true;
        }
        else if (collision.gameObject.name == "Player" && collision.gameObject.GetComponent<playerHealth>().takeDamage())
        {
            isGrabbing = true;
            collision.gameObject.GetComponent<PlayerMovement2D>().setGrabbed(true);
        }
    }
}
