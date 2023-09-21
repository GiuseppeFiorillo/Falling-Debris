using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !collision.gameObject.GetComponent<playerHealth>().getBarriered())
        {
            collision.gameObject.GetComponent<playerHealth>().setBarriered(true);
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
