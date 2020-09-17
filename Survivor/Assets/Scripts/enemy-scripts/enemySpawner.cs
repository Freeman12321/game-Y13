using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
    public GameObject inGameEnemy; // the enemy we will spawn
    public float xPos; // holds the x position of the spawn
    public float zPos; // holds the y position of the spawn
    public float spawnCooldown = 2f; // time between spawn
    public int enemyCount = 0; // how many enemies are there
    // Use this for initialization
    void Start() {
        StartCoroutine(EnemySpawn()); // activates the iEnumerator
    }
    // Update is called once per frame
    void Update() {
        spawnCooldown -= Time.deltaTime; // subtracts the time it took to complete the frame every frame thus every frame rate will produce the same decrease in the cooldown 
    }
    IEnumerator EnemySpawn() {
<<<<<<< HEAD
        /* This code did not work optimally because it is not conditional and should be looped hence
=======
        /* This code did not work because it is not conditional and should be looped hence
>>>>>>> 4be645352fa7435b49f0624285de94fb540b56fb
        if (spawnCooldown < 0) {
            xPos = Random.Range(-9, 9);
            zPos = Random.Range(-9, 9);
            Instantiate(inGameEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
            Debug.Log("spawning enemy");
            spawnCooldown = Random.Range(1, 3);
            yield return new WaitForSeconds(.5f);
        }
        */
        while (enemyCount < 100) { // while there are less than 100 enemies
            xPos = Random.Range(-50, 50); // set an x position (random)
            zPos = Random.Range(-50, 50); // set a z position (random)
            Instantiate(inGameEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity); //spawn an enemy at the random positions and the original rotation
            Debug.Log("spawning enemy");
            spawnCooldown = Random.Range(1, 3); // set the spawn cooldown to 
            yield return new WaitForSeconds(spawnCooldown); // Creates a yield instruction to wait for spawnCooldown seconds to satisfy the IEnumerator
            enemyCount = enemyCount + 1; // increase the enemy count by 1 
        }
        

    }
}
