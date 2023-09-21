using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
<<<<<<< HEAD
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && !collision.gameObject.GetComponent<playerHealth>().getBarriered())
        {
            collision.gameObject.GetComponent<playerHealth>().setBarriered(true);
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }

=======
>>>>>>> 96ccee69dd647abe1e0f57836ae0c2b806889b2c
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !collision.gameObject.GetComponent<playerHealth>().getBarriered())
        {
            collision.gameObject.GetComponent<playerHealth>().setBarriered(true);
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
<<<<<<< HEAD
        else if(collision.gameObject.name == "Terrain")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            isDespawning = true;
=======
        else
        {
            Destroy(this.gameObject);
>>>>>>> 96ccee69dd647abe1e0f57836ae0c2b806889b2c
        }
    }
}
