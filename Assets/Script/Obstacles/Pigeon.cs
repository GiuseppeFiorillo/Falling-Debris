using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    private float timerAlive = 5f;
    private bool direction;
    private float shootTimer = 1f;

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
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * -.5f);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * .5f);
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
            shootTimer = 1f;
            Instantiate(poop, transform.position, transform.rotation);
        }
    }
}
