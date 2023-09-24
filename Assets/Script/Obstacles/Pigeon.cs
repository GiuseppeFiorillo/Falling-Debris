using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    private float timerAlive = 5f;
    private bool direction;
    private float shootTimer = .5f;

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
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * -.3f);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * .3f);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            
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
            shootTimer = .5f;
            Instantiate(poop, transform.position - new Vector3(0, 1.5f, 0), transform.rotation);
        }
    }
}
