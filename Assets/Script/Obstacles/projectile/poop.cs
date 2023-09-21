using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poop : MonoBehaviour
{
<<<<<<< HEAD

    private float timerDespawn = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !collision.gameObject.GetComponent<PlayerMovement2D>().isSlowed && !collision.gameObject.GetComponent<playerHealth>().getBarriered())
        {
            collision.gameObject.GetComponent<PlayerMovement2D>().speed = 3f;
            collision.gameObject.GetComponent<PlayerMovement2D>().isSlowed = true;
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.name == "Player" && !collision.gameObject.GetComponent<PlayerMovement2D>().isSlowed && collision.gameObject.GetComponent<playerHealth>().getBarriered())
        {
            collision.gameObject.GetComponent<playerHealth>().setBarriered(false);
            GameObject.Find("Player").transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
=======
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !collision.gameObject.GetComponent<PlayerMovement2D>().isSlowed)
        {
            collision.gameObject.GetComponent<PlayerMovement2D>().speed = 4f;
            collision.gameObject.GetComponent<PlayerMovement2D>().isSlowed = true;
            Destroy(this.gameObject);
        }
>>>>>>> 96ccee69dd647abe1e0f57836ae0c2b806889b2c
        else if(collision.gameObject.name == "Terrain")
        {
            Destroy(this.gameObject);
        }
    }
<<<<<<< HEAD

    private void Update()
    {
        timerDespawn -= Time.deltaTime;
        if(timerDespawn < 0)
        {
            Destroy(this.gameObject);
        }
    }
=======
>>>>>>> 96ccee69dd647abe1e0f57836ae0c2b806889b2c
}
