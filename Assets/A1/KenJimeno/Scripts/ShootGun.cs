using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR;

public class ShootGun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private SpriteRenderer charRenderer;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float xPosOffset;
    [SerializeField] private float yPosOffset;

    private AudioSource shootSource;

    private void Start() {
        shootSource = GetComponent<AudioSource>();
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Z)) {
            shootSource.Play();
            float xOffset = charRenderer.flipX ? -xPosOffset : xPosOffset;
            int xDir = charRenderer.flipX ? -1 : 1;

            Vector3 spawnPos = playerTransform.position;
            spawnPos.x += xOffset;
            spawnPos.y += yPosOffset;

            GameObject bulletPrefab = Instantiate(bullet, spawnPos, Quaternion.identity);
            bulletPrefab.GetComponent<Bullet>().xDirection = xDir;

            Destroy(bulletPrefab, 1.5f);
        }
    }
}
