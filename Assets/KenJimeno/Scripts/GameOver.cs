using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private UnityEvent gameOver;
    [SerializeField] private Transform gameOverTransform;
    [SerializeField] private Camera mainCam;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(0);
        }
    }

    public void GameIsOver() {
        mainCam.transform.position = gameOverTransform.position;
        gameOver.Invoke();
    }
}
