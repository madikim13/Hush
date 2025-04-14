using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetFollow : MonoBehaviour
{
    public Transform player;
    public float yPosition = 0f;

    void Update()
    {
        if (player == null) return;

        // Follow only X, keep Y fixed
        transform.position = new Vector3(player.position.x, yPosition, 0f);
    }
}