using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // The player character
    public Vector2 minPosition;
    public Vector2 maxPosition;

    void LateUpdate()
    {
        float clampedX = Mathf.Clamp(player.position.x, minPosition.x, maxPosition.x);
        float clampedY = Mathf.Clamp(player.position.y, minPosition.y, maxPosition.y);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
