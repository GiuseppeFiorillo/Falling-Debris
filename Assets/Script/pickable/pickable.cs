using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    private int type;
    // Start is called before the first frame update
    void Start()
    {
        setType();
    }

    private bool isDespawning = false;
    private float timerDespawn = 3f;
    private void Update()
    {
        if (isDespawning)
        {
            timerDespawn -= Time.deltaTime;
            if (timerDespawn < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if(type < 50)
            {
                collision.GetComponent<Rigidbody2D>().mass += 2.5f;
            }
            
            if(type >= 50)
            {
                if(collision.GetComponent<Rigidbody2D>().mass == 0)
                {
                    return;
                }
                else
                {
                    collision.GetComponent<Rigidbody2D>().mass -= 2.5f;
                }
            }
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.name == "Terrain")
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
            isDespawning = true;
        }
    }

    private void setType()
    {
        type = Random.Range(0, 100);
        if(type < 50)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/powerup");
        }
        
        if(type >= 50)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/powerdown");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (type < 50)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().mass += 2.5f;
            }

            if (type >= 50)
            {
                if (collision.gameObject.GetComponent<Rigidbody2D>().mass == 0)
                {
                    return;
                }
                else
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().mass -= 2.5f;
                }
            }
            Destroy(this.gameObject);
        }
    }

}
