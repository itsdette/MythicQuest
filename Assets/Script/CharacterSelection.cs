using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementConfig {
    public string elementName;  // Name of the GameObject to move
    public Vector3 direction;    // Direction to move (e.g., new Vector3(-1, 0, 0) for left)
}

public class CharacterSelection : MonoBehaviour {
    public GameObject[] levels;  // Array to store all elements in the scene
    public MovementConfig[] movementConfigs;  // Movement configurations for different elements
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke = 0.1f; // Small choke to avoid overlapping (adjust as needed)
    public float scrollSpeed;

    void Start() {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        
        // Load child objects for all elements in the level
        foreach (GameObject obj in levels) {
            loadChildObjects(obj);
        }
    }

    void loadChildObjects(GameObject obj) {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth) + 1; // Add one extra to ensure no gaps
        GameObject clone = Instantiate(obj) as GameObject;
        for (int i = 0; i <= childsNeeded; i++) {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);  // Destroy the initial object after cloning
        Destroy(obj.GetComponent<SpriteRenderer>());  // Remove the original sprite renderer
    }

    void repositionChildObjects(GameObject obj) {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1) {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;

            // If the last child is out of screen bounds, move it to the front to create a seamless loop
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth) {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            // If the first child is out of screen bounds, move it to the back
            else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth) {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }

    void Update() {
        // Move elements based on movement configurations
        foreach (MovementConfig config in movementConfigs) {
            GameObject obj = GameObject.Find(config.elementName);
            if (obj != null) {
                obj.transform.position += config.direction * scrollSpeed * Time.deltaTime;
            }
        }
    }

    void LateUpdate() {
        // Reposition child objects for all elements (moving or not)
        foreach (GameObject obj in levels) {
            repositionChildObjects(obj);
        }
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour {
    public GameObject[] levels;  // Array to store all elements in the scene
    public GameObject[] movingElements;  // Array to store only the elements that should move
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke = 0.1f; // Small choke to avoid overlapping (adjust as needed)
    public float scrollSpeed;

    void Start() {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        
        // Load child objects for all elements in the level
        foreach (GameObject obj in levels) {
            loadChildObjects(obj);
        }
    }

    void loadChildObjects(GameObject obj) {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth) + 1; // Add one extra to ensure no gaps
        GameObject clone = Instantiate(obj) as GameObject;
        for (int i = 0; i <= childsNeeded; i++) {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);  // Destroy the initial object after cloning
        Destroy(obj.GetComponent<SpriteRenderer>());  // Remove the original sprite renderer
    }

    void repositionChildObjects(GameObject obj) {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1) {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;

            // If the last child is out of screen bounds, move it to the front to create a seamless loop
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth) {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            // If the first child is out of screen bounds, move it to the back
            else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth) {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }

    void Update() {
        // Only move the elements that are supposed to scroll (sky, particles1, particles2, mist1, mist)
        foreach (GameObject obj in movingElements) {
            if (obj.name.Contains("Sky")) {
                // Move sky to the right
                obj.transform.position += new Vector3(scrollSpeed * Time.deltaTime, 0, 0);
            } else {
                // Move mist, mist1, particles1, and particles2 to the left
                obj.transform.position += new Vector3(-scrollSpeed * Time.deltaTime, 0, 0);
            }
        }
    }

    void LateUpdate() {
        // Reposition child objects for all elements (moving or not)
        foreach (GameObject obj in levels) {
            repositionChildObjects(obj);
        }
    }
}
*/