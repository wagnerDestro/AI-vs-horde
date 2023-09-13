using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int enemyOnScreen { get; private set; } = 0;
    private GenerateEnemies generateEnemies;
    public GameObject enemyGenerator;
    void Start()
    {
        generateEnemies = enemyGenerator.GetComponent<GenerateEnemies>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyOnScreen != 0 && generateEnemies.enemyCount == 0){
            enemyOnScreen = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
    if (collider.gameObject.CompareTag("enemy")) {
        enemyOnScreen++;
        BaseEnemy baseEnemy = collider.gameObject.GetComponent<BaseEnemy>();
        baseEnemy.onScreen = true;
    }
}
}
