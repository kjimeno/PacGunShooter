using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private UnityEvent deathEvent;
    [SerializeField] private ScoreHandler scoreHandler;
    
    [Header("Boss Properties:")]
    [SerializeField] private bool isBoss;
    [SerializeField] private UnityEvent bossAttack;
    [SerializeField] private float healthStartInjured;
    [SerializeField] [Range(0, 2f)] private float bossInjuredSpeed;
    [SerializeField] private float healthStartAttack;
    [SerializeField] private float healthEndAttack;
    [SerializeField] private StartGame startGame;
    [SerializeField] private WinGame winGame;
    [SerializeField] private AudioSource attackedSource;
    
    [Header("isAJumpingGhost:")]
    [SerializeField] private bool isJumpingGhost;
    [SerializeField] private Rigidbody2D jumpingBody;

    private const int SCORE_ON_DEATH = 100;
    private const int SCORE_ON_HIT = 20;


    public void UpdateHealth(int dmg) {
        if (isBoss)
            attackedSource.Play();

        health -= dmg;

        if (isBoss && health <= healthStartInjured) {
            GetComponent<Animator>().speed = bossInjuredSpeed;
        }
        if (isBoss && health <= healthStartAttack && health >= healthEndAttack) {
            bossAttack.Invoke();
        }
        if (isBoss && health < healthEndAttack) {
            winGame.enabled = true;
            winGame.GameWin();
            startGame.gameStarted = false;
        }

        if (health <= 0) {
            deathEvent.Invoke();
            scoreHandler.UpdateScore(SCORE_ON_DEATH);

            if (isJumpingGhost)
                jumpingBody.velocity = Vector3.zero;
        } else {
            scoreHandler.UpdateScore(SCORE_ON_HIT);
        }
    }

    
}
