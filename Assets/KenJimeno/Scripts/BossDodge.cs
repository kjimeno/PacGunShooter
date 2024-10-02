using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class BossDodge : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bossRenderer;
    [SerializeField] private Collider2D bossCollider;
    [SerializeField] [Range(1f, 5f)] private float maxDodgeTimer;
    [SerializeField] [Range(0, 1f)] private float dodgeTransparency;
    [SerializeField] private float timeBetweenDodge;
    
    private float dodgeTimer = 0;
    private float debounceTimer = 0;

    private void Update() {
        if (debounceTimer > timeBetweenDodge) {
            Debug.Log("GOINGOING");
            bossRenderer.color = new Color(255, 0, 0, 0);
            bossCollider.enabled = false;
        } else {
            debounceTimer += Time.deltaTime;
        }
    }


    private IEnumerator Dodge() {
        dodgeTimer = Random.Range(1f, maxDodgeTimer);
        Debug.Log("ISACTIVE!");
        
        bossRenderer.color = new Color(255, 0, 0, dodgeTransparency);
        bossCollider.enabled = false;

        yield return new WaitForSeconds(dodgeTimer);

        bossRenderer.color = new Color(255, 255, 255, 1);
        bossCollider.enabled = true;
        Debug.Log("ISACTIVE!");
    }

}
