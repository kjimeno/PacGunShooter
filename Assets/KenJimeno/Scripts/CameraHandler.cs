
using System;
using System.Collections;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform[] camPositions;
    [SerializeField] private GameObject[] levelBorders;
    [SerializeField] private GameObject bossAttack;
    [SerializeField] GameObject bossGhost;

    private static int level = 0;
    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            levelBorders[level].SetActive(true);
            cam.transform.position = camPositions[++level].position;
            
            if (level < camPositions.Length - 1) {
                gameObject.SetActive(false);   
            } else if (level == camPositions.Length - 1) {
                spriteRenderer.enabled = false;
                GetComponent<Collider2D>().enabled = false;
                bossGhost.SetActive(true);
                StartCoroutine(EnableBossAttacks());
            }
        }
    }

    public void ResetLevel() {
        level = 0;
    }

    private IEnumerator EnableBossAttacks() {
        yield return new WaitForSeconds(2);

        bossAttack.SetActive(true);
        gameObject.SetActive(false);   
    }
}
