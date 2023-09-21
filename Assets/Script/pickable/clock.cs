using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock : MonoBehaviour
{
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("gameManager").GetComponent<gameManager>().setClock(true);
            Destroy(this.gameObject);
        }
    }
}
