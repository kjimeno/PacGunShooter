using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] projectileSets;
    [SerializeField] private float endYPos;

    private float attackSpeed = 15f;

    private bool isActive = false;
    private int randIdx;
    private Vector3 originPos;

    public void RandomAttack() {
        randIdx = Random.Range(0, projectileSets.Length);

        isActive = true;
    }

    public void ResetAttack() {
        GetComponent<Animator>().SetBool("BossAttack", false);
    }

    public void UpdateAttackSpeed(float addedSpeed) {
        attackSpeed += addedSpeed;
    }

    private void Start() {
        originPos = projectileSets[0].transform.position;
    }

    private void Update() {
        if (isActive) {
            projectileSets[randIdx].transform.Translate(Vector3.down * Time.deltaTime * attackSpeed);
            
            if (projectileSets[randIdx].transform.position.y < endYPos) {
                isActive = false;
                projectileSets[randIdx].transform.position = originPos;
            }
        }
    }
}
