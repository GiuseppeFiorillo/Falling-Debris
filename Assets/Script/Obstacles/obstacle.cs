using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class roatationMeteor : MonoBehaviour
{
    private float rotationSpeed;
    [SerializeField]
    private float direction;

    [Header("Weight numbers")]
    [SerializeField]
    private int[] weights;


    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(direction, -direction);
        GetComponent<Rigidbody2D>().mass = weights[Random.Range(0, weights.Length)];

        scaleWeight();

        //PLACEHOLDER
        setColor();

        StartCoroutine(destroy());
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().AddForce(transform.right * rotationSpeed * Time.deltaTime);
    }

    public IEnumerator destroy()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            Destroy(this.gameObject);
        }
    }

    public void scaleWeight()
    {
        if(GetComponent<Rigidbody2D>().mass == 5)
        {
            this.transform.localScale = new Vector3(.5f, .5f, 1);
        }
        
        if(GetComponent<Rigidbody2D>().mass == 10)
        {
            this.transform.localScale = new Vector3(.75f, .75f, 1);
        }

        if (GetComponent<Rigidbody2D>().mass == 15)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    //PLACEHOLDER
    public void setColor()
    {
        if (GetComponent<Rigidbody2D>().mass == 5)
        {
            this.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
        
        if (GetComponent<Rigidbody2D>().mass == 10)
        {
            this.GetComponent<SpriteRenderer>().color = Color.cyan;
        }

        if (GetComponent<Rigidbody2D>().mass == 15)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
