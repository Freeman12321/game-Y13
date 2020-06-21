using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
    public GameObject inGameEnemy;
    public float xPos;
    public float zPos;
    public float spawnCooldown = 2f;
    public int enemyCount = 0;
    // Use this for initialization
    void Start() {
        StartCoroutine(EnemySpawn());
    }
    // Update is called once per frame
    void Update() {
        spawnCooldown -= Time.deltaTime;
    }
    IEnumerator EnemySpawn() {
        /*
        if (spawnCooldown < 0) {
            xPos = Random.Range(-9, 9);
            zPos = Random.Range(-9, 9);
            Instantiate(inGameEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
            Debug.Log("spawning enemy");
            spawnCooldown = Random.Range(1, 3);
            yield return new WaitForSeconds(.5f);
        }
        */
        while (enemyCount < 100) {
            xPos = Random.Range(-50, 50);
            zPos = Random.Range(-50, 50);
            Instantiate(inGameEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
            Debug.Log("spawning enemy");
            spawnCooldown = Random.Range(1, 3);
            yield return new WaitForSeconds(spawnCooldown);
            enemyCount = enemyCount + 1;
        }
        

    }
}
