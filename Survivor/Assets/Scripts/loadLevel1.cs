using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // allow this script to use Unity's SceneManagement 
public class loadLevel1 : MonoBehaviour {

    public void loadNextLevel() { 
        Debug.Log("Next Level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // loads the next scene in the build index
    }
}
