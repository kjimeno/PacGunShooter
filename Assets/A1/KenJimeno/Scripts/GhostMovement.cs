using System;
using Unity.VisualScripting;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [Header("Properties:")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxDistFromOrigin;

    private float originPosX;
    private float endPosX;

    private bool movingRight = true;

    private void Start() {
        originPosX = transform.position.x;
        endPosX = originPosX + maxDistFromOrigin;
    }

    private void Update()
    {
        HorizontalMovement();
    }

    private void HorizontalMovement()
    {
        Vector3 moveIncrement = new Vector3(movementSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x >= endPosX && movingRight)
        {
            movingRight = false;
        }
        else if (transform.position.x <= originPosX && !movingRight)
        {
            movingRight = true;
        }

        moveIncrement *= movingRight ? 1 : -1;
        transform.Translate(moveIncrement);
    }
}
