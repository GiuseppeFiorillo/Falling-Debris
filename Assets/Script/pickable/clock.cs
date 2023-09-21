using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            GameObject.Find("gameManager").GetComponent<gameManager>().setClock(true);
            Destroy(this.gameObject);
        }
        if(collision.gameObject.name == "Terrain")
        {
            Destroy(this.gameObject);
        }
    }
}
