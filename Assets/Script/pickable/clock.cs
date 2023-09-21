using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock : MonoBehaviour
{
    private bool isDespawning = false;
    private float timerDespawn = 3f;
<<<<<<< HEAD
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
=======
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
>>>>>>> b4089623bb78d9d5202c41e3dcfbcf6c774e7dd7
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            GameObject.Find("gameManager").GetComponent<gameManager>().setClock(true);
            Destroy(this.gameObject);
        }
        if(collision.gameObject.name == "Terrain")
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
            isDespawning = true;
        }
    }

<<<<<<< HEAD
    private void OnCollisionEnter2D(Collision2D collision)
    {
=======
    private void OnCollisionEnter2D(Collision2D collision)
    {
>>>>>>> b4089623bb78d9d5202c41e3dcfbcf6c774e7dd7
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("gameManager").GetComponent<gameManager>().setClock(true);
            Destroy(this.gameObject);
<<<<<<< HEAD
        }
=======
        }
>>>>>>> b4089623bb78d9d5202c41e3dcfbcf6c774e7dd7
    }
}
