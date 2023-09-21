using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;

    [SerializeField]
    private int SpawnRange;

    [HideInInspector]
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CallSpawner());
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
