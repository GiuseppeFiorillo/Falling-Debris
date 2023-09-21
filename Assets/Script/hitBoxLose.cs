using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoxLose : MonoBehaviour
{

    [SerializeField]
    private GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
            gameOverScreen.gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("manager").GetComponent<gameManager>().gameOver = true;
        }
        else if(collision.gameObject.name == "Meteor")
        {
            Destroy(collision.gameObject);
        }
    }
}
