using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    private int score = 0;




    private void Update()
    {
        restartGame();
        scoreUpdate();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CallSpawner());
    }

    private void restartGame()
    {
        if(gameOver)
        {
            timerGameOver -= Time.deltaTime;
            if(timerGameOver <= 0)
            {
                timerGameOver = 3f;
                SceneManager.LoadScene(0);
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

    public IEnumerator CallSpawner()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(2f);
            SpawnObstacles();
        }
    }

    public void SpawnObstacles()
    {
        int num = Random.Range(0, 100);
        if(num < 60)
        {
            Instantiate(obstacles[0], transform.position + new Vector3(Random.Range(-SpawnRange, SpawnRange), 0), transform.rotation);
        }
        else
        {
            Instantiate(obstacles[1], transform.position + new Vector3(Random.Range(-SpawnRange, SpawnRange), 0), transform.rotation);
        }
    }

}
