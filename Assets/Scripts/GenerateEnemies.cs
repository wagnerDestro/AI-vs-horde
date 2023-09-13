using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{

    public GameObject enemy;

    public int enemyCount {get; private set;} = 0;

    public int maxEnemies = 10;

    public GameObject[] spawnAreas;

    private float waitTime = 3f;

    private bool wait = false;
    
    private float timeCurrentWaiting = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!wait && enemyCount < maxEnemies){
            Vector3 spawnCoordinates;
            GameObject spawnAreaSelected = spawnAreas[Random.Range(0, spawnAreas.Length)];
            spawnCoordinates = GetRandomPositionInArea(spawnAreaSelected.transform);
            Instantiate(enemy, spawnCoordinates, Quaternion.identity);
            enemyCount++;
            wait = true;
        }else{
            timeCurrentWaiting += Time.deltaTime;
            if (timeCurrentWaiting >= waitTime){
                wait = false;
                timeCurrentWaiting = 0f;
            }
        }
    }

    private Vector3 GetRandomPositionInArea(Transform spawnArea){
        // Aqui você pode calcular uma posição aleatória dentro da área de spawn.

        float randomX = Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2);
        float randomY = Random.Range(spawnArea.position.y - spawnArea.localScale.y / 2, spawnArea.position.y + spawnArea.localScale.y / 2);
        float zPosition = 0; // Define a posição Z como necessário.

        return new Vector3(randomX, randomY, zPosition);
    }
}
