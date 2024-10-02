using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    [SerializeField] private UnityEvent winGame;
    [SerializeField] private Transform winGameTransform;
    [SerializeField] private Camera mainCam;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(0);
        }
    }

    public void GameWin() {
        mainCam.transform.position = winGameTransform.position;
        winGame.Invoke();
    }
}
