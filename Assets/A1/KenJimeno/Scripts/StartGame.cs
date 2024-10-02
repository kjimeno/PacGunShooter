using UnityEngine;
using UnityEngine.Events;

public class StartGame : MonoBehaviour
{
    [SerializeField] private UnityEvent startGame;
    [SerializeField] private Camera mainCam;
    [SerializeField] private Transform firstLevelPos;

    [HideInInspector] public bool gameStarted = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            gameStarted = true;
            startGame.Invoke();
            mainCam.transform.position = firstLevelPos.position;
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }
    }
}
