using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] obstacles;

    [SerializeField]
    private int SpawnRange;

    [HideInInspector]
    public bool gameOver = false;

    [SerializeField]
    private GameObject scoreText;

    private float timerGameOver = 3f;
    private float timerScore = .5f;
    private float timerClock = 10f;

    [SerializeField]
    private float timerSpawn;

    private float timerSpawnObj;

    private int score = 0;

    //STATE
    private bool clockON = false;

    private void Update()
    {
        terrainMassHandler();
        restartGame();
        scoreUpdate();
        updateWeightPlayerHUD();

        //GESTORE CLOCK POWER
        setClockOff();

        CallSpawner();

        pauseGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        timerSpawnObj = timerSpawn;
    }

    void pauseGame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void restartGame()
    {
        if(gameOver)
        {
            GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            Destroy(GameObject.Find("Player"));
            timerGameOver -= Time.deltaTime;
            if(timerGameOver <= 0)
            {
                timerGameOver = 3f;
                SceneManager.LoadScene(1);
            }
        }
    }

    private void scoreUpdate()
    {
        if(!gameOver)
        {
            timerScore -= Time.deltaTime;
            if(timerScore <= 0)
            {
                timerScore = .5f;
                score += 1;
            }
            scoreText.GetComponent<TextMeshProUGUI>().text = "SCORE = " + score;
        }
    }
    public void CallSpawner()
    {
        timerSpawnObj -= Time.deltaTime;
        if(timerSpawnObj <= 0)
        {
            timerSpawnObj = timerSpawn;
	        if(timerSpawn > .67f)
                timerSpawn -= 0.01f;
            SpawnObstacles();
        }
    }

    public void SpawnObstacles()
    {
        int num = Random.Range(0, 100);
        if(num <= 65)
        {
            //WEIGHTS
            Instantiate(obstacles[0], transform.position + new Vector3(Random.Range(-SpawnRange, SpawnRange), 5), transform.rotation);
        }
        else if(num >= 66 && num <= 71)
        {
            //BIBITE
            Instantiate(obstacles[1], transform.position + new Vector3(Random.Range(-SpawnRange, SpawnRange), 2), transform.rotation);
        }
        else if(num >= 72 && num <= 77)
        {
            //CLOCK
            Instantiate(obstacles[2], transform.position + new Vector3(Random.Range(-SpawnRange, SpawnRange), 2), transform.rotation);
        }
        else if(num >= 78 && num <= 88)
        {
            //PLANT
            Instantiate(obstacles[3], transform.position + new Vector3(Random.Range(-SpawnRange, SpawnRange), 2), transform.rotation);
        }
        else if(num >= 89 && num <= 94)
        {
            //BARRIER
            Instantiate(obstacles[4], transform.position + new Vector3(Random.Range(-SpawnRange, SpawnRange), 2), transform.rotation);
        }
        else
        {
            //PIGEON
            Instantiate(obstacles[5], transform.position + new Vector3(Random.Range(-SpawnRange, SpawnRange), 0), transform.rotation);
        }
    }
    
    public void setClock(bool val)
    {
        clockON = val;
    }
    public bool getClock()
    { return clockON; }
    private void setClockOff()
    {
        if(clockON)
        {
            GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(true);
            timerClock -= Time.deltaTime;
            if(timerClock < 0)
            {
                GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(false);
                clockON = false;
                timerClock = 10f;
            }
        }
    }

    private void updateWeightPlayerHUD()
    {
        if(!gameOver)
            GameObject.Find("Canvas").transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "WEIGHT = " + GameObject.Find("Player").GetComponent<Rigidbody2D>().mass;
    }

    private float terrainMassHandlerTimer = 1f;
    private void terrainMassHandler()
    {
        if (GameObject.Find("Terrain").GetComponent<Rigidbody2D>().mass > 10)
        { 
            terrainMassHandlerTimer -= Time.deltaTime;
            if (terrainMassHandlerTimer <= 0)
            {
                terrainMassHandlerTimer = 1f;
                GameObject.Find("Terrain").GetComponent<Rigidbody2D>().mass -= 1;
            }
        }
    }
}
