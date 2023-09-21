using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
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

<<<<<<< HEAD
    private void OnCollisionEnter2D(Collision2D collision)
    {
=======
    private void OnCollisionEnter2D(Collision2D collision)
    {
>>>>>>> b4089623bb78d9d5202c41e3dcfbcf6c774e7dd7
        if (collision.gameObject.name == "Player" && !collision.gameObject.GetComponent<playerHealth>().getBarriered())
        {
            collision.gameObject.GetComponent<playerHealth>().setBarriered(true);
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(this.gameObject);
<<<<<<< HEAD
        }
=======
        }
>>>>>>> b4089623bb78d9d5202c41e3dcfbcf6c774e7dd7
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !collision.gameObject.GetComponent<playerHealth>().getBarriered())
        {
            collision.gameObject.GetComponent<playerHealth>().setBarriered(true);
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.name == "Terrain")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            isDespawning = true;
        }
    }
}
