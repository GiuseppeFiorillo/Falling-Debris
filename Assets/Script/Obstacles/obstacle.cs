using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class roatationMeteor : MonoBehaviour
{
    private float rotationSpeed;
    [SerializeField]
    private float direction;

    [Header("Weight numbers")]
    [SerializeField]
    private int[] weights;

    private float timerDestroy = 5f;


    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(direction, -direction);
        GetComponent<Rigidbody2D>().mass = weights[Random.Range(0, weights.Length)];
        scaleWeight();

        //PLACEHOLDER
        setSprite();

        //CLOCK POWER CHECKER
        clockPowerON();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().AddForce(transform.right * rotationSpeed * Time.deltaTime);
        destroy();
    }

    public void destroy()
    {
        timerDestroy -= Time.deltaTime;
        if(timerDestroy < 0 )
        {
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
    public void setSprite()
    {
        Sprite newSprite;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null) 
        {
            if (GetComponent<Rigidbody2D>().mass == 5)
            {
                newSprite = Resources.Load<Sprite>("Sprites/rock");
                if (newSprite != null)
                {
                    // Assegna la nuova Sprite
                    spriteRenderer.sprite = newSprite;
                }
                else
                {
                    Debug.LogWarning("SpriteRenderer o newSprite non impostati correttamente.");
                }    
            }
            
            // Rock
            else if (GetComponent<Rigidbody2D>().mass == 10)
            {
                newSprite = Resources.Load<Sprite>("Sprites/brick");
                if (newSprite != null)
                {
                    // Assegna la nuova Sprite
                    spriteRenderer.sprite = newSprite;
                }
                else
                {
                    Debug.LogWarning("SpriteRenderer o newSprite non impostati correttamente.");
                }
            }

            // Anvil
            else if (GetComponent<Rigidbody2D>().mass == 15)
            {
                newSprite = Resources.Load<Sprite>("Sprites/anvil");
                if (newSprite != null)
                {
                    // Assegna la nuova Sprite
                    spriteRenderer.sprite = newSprite;
                }
                else
                {
                    Debug.LogWarning("SpriteRenderer o newSprite non impostati correttamente.");
                }

            }
        }
    }

    public void clockPowerON()
    {
        if (GameObject.Find("gameManager").GetComponent<gameManager>().getClock())
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.25f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().speed = 0f;
    }
}
