using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackground : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;  // Speed of the background

    [SerializeField]
    private float offset;  // Size of the background texture to loop

    private Vector2 startPosition;  // Initial position of the background

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Multiply movement by Time.deltaTime to make it framerate independent
        float newXposition = Mathf.Repeat((Time.time * moveSpeed), offset);

        // Smoothly translate the background position
        transform.position = startPosition + Vector2.left * newXposition;
    }
}
