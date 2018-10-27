using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Add grid-based controls to a cursor game object. 
/// </summary>
public class PlayerCursor : MonoBehaviour {

    public int TileSize;

    public GameObject[] arrowsPrefab;
    GameObject currentArrow;
    int index;
    public KeyCode Up;
    public KeyCode Left;
    public KeyCode Down;
    public KeyCode Right;
    public KeyCode Action;

    public float MovementTime;  // Duration in seconds of cursor movement.

    private Vector3 newPosition;
    private float positionLerp = 1;

	// Use this for initialization
	void Start () {
        newPosition = transform.position;
	}

    // Update is called once per frame
    void Update() {
        index = Random.Range(0, arrowsPrefab.Length);


        if (positionLerp < 1)
            moveCursor();

        else  // The player can only move the cursor if it is not already moving.
        {
            if (Input.GetKeyDown(Up))
                newPosition = new Vector3(newPosition.x, newPosition.y + TileSize, newPosition.z);
            else if (Input.GetKeyDown(Left))
                newPosition = new Vector3(newPosition.x - TileSize, newPosition.y, newPosition.z);
            else if (Input.GetKeyDown(Down))
                newPosition = new Vector3(newPosition.x, newPosition.y - TileSize, newPosition.z);
            else if (Input.GetKeyDown(Right))
                newPosition = new Vector3(newPosition.x + TileSize, newPosition.y, newPosition.z);
            else if (Input.GetKeyDown(Action))
                 Instantiate(arrowsPrefab[index], transform.position, transform.rotation);
            if (transform.position != newPosition)  // AKA the player pressed a button
                positionLerp = 0;
        }

	}

    private void moveCursor()
    {
        transform.position = sinerp(transform.position, newPosition, positionLerp);
        positionLerp += (1 / MovementTime) * Time.deltaTime;
    }

    // From the Unify Comunnity Wiki: http://wiki.unity3d.com/index.php/Mathfx 
    private static Vector3 sinerp(Vector3 start, Vector3 end, float value)
    {
        return new Vector3(Mathf.Lerp(start.x, end.x, Mathf.Sin(value * Mathf.PI * 0.5f)), Mathf.Lerp(start.y, end.y, Mathf.Sin(value * Mathf.PI * 0.5f)), Mathf.Lerp(start.z, end.z, Mathf.Sin(value * Mathf.PI * 0.5f)));
    }
}
