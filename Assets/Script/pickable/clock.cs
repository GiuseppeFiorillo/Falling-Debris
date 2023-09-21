using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock : MonoBehaviour
{
<<<<<<< HEAD
    private bool isDespawning = false;
    private float timerDespawn = 3f;
    private void Update()
    {
        if(isDespawning)
        {
            timerDespawn -= Time.deltaTime;
            if(timerDespawn < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
=======
>>>>>>> 96ccee69dd647abe1e0f57836ae0c2b806889b2c
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            GameObject.Find("gameManager").GetComponent<gameManager>().setClock(true);
            Destroy(this.gameObject);
        }
        if(collision.gameObject.name == "Terrain")
        {
<<<<<<< HEAD
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
            isDespawning = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("gameManager").GetComponent<gameManager>().setClock(true);
=======
>>>>>>> 96ccee69dd647abe1e0f57836ae0c2b806889b2c
            Destroy(this.gameObject);
        }
    }
}
