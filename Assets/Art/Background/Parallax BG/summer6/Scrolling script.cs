using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 0.05f;   // Speed of scrolling
    private Vector2 offset;             // Offset for scrolling
    private Material material;

    void Start()
    {
        // Get the material attached to the background or clouds
        material = GetComponent<Renderer>().material;
        offset = new Vector2(scrollSpeed, 0);  // Horizontal scrolling (use (0, scrollSpeed) for vertical)
    }

    void Update()
    {
        // Move the texture offset based on time and scroll speed
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
