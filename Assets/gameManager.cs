using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CallSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator CallSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            SpawnObstacles();
        }
    }

    public void SpawnObstacles()
    {
        Instantiate(obstacle, Vector3()));
    }

}
