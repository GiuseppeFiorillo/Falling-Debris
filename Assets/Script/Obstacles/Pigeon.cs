using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    private float timerAlive = 5f;
    private bool direction;
<<<<<<< HEAD
    private float shootTimer = .5f;
=======
    private float shootTimer = 1f;
>>>>>>> 96ccee69dd647abe1e0f57836ae0c2b806889b2c

    [SerializeField]
    private GameObject poop;

    // Start is called before the first frame update
    void Start()
    {
        getPath();
    }

    // Update is called once per frame
    void Update()
    {
        delete();
        setPath();
        shoot();
    }

    void delete()
    {
        timerAlive -= Time.deltaTime;
        if (timerAlive < 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void setPath()
    {
        if(direction)
        {
<<<<<<< HEAD
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * -.1f);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * .1f);
=======
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * -.5f);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * .5f);
>>>>>>> 96ccee69dd647abe1e0f57836ae0c2b806889b2c
        }
    }
    private void getPath()
    {
        if (transform.position.x - GameObject.Find("gameManager").transform.position.x > 0)
            direction = true;
        else
            direction = false;
    }
    private void shoot()
    {
        shootTimer -= Time.deltaTime;
        if(shootTimer < 0)
        {
<<<<<<< HEAD
            shootTimer = .5f;
=======
            shootTimer = 1f;
>>>>>>> 96ccee69dd647abe1e0f57836ae0c2b806889b2c
            Instantiate(poop, transform.position, transform.rotation);
        }
    }
}
