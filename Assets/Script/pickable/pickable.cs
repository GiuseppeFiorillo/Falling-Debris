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
        StartCoroutine(destroy());
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
        }

        Destroy(this.gameObject);
    }

    private void setType()
    {
        type = Random.Range(0, 100);
        if(type < 50)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        
        if(type >= 50)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
    public IEnumerator destroy()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            Destroy(this.gameObject);
        }
    }
}
