using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;

    public void EndGame() {
        if (!gameHasEnded){
            Debug.Log("Game over");
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    public void CompleteLevel(){
        completeLevelUI.SetActive(true);
    }

    void Restart () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
