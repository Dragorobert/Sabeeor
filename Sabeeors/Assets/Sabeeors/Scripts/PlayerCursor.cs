using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Add grid-based controls to a cursor game object. 
/// </summary>
public class PlayerCursor : MonoBehaviour {

    public int TileSize;

    int index;

    public GameObject current_panel;
    private GameObject current_piece;
    public GameObject next_panel;
    private GameObject next_piece;

    public GameObject[] arrowsPrefab;

    bool empty = true;

    int maxArrow = 3;
    int arrowCount = 0;

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

        index = Random.Range(0, arrowsPrefab.Length);
        current_piece = Instantiate(arrowsPrefab[index], current_panel.transform.position, Quaternion.identity);
        current_piece.transform.position = new Vector3(current_piece.transform.position.x, current_piece.transform.position.y, -5);
        index = Random.Range(0, arrowsPrefab.Length);
        next_piece = Instantiate(arrowsPrefab[index], next_panel.transform.position, Quaternion.identity);
        next_piece.transform.position = new Vector3(next_piece.transform.position.x, next_piece.transform.position.y, -5);
    }

    // Update is called once per frame
    void Update() {

        index = Random.Range(0, arrowsPrefab.Length);

        if (positionLerp < 1)
            MoveCursor();

        else  // The player can only move the cursor if it is not already moving.
        {
            if (Input.GetKeyDown(Up))
                newPosition = new Vector3(newPosition.x, newPosition.y + TileSize, newPosition.z);
            //metodo instancia que se ve
            else if (Input.GetKeyDown(Left))
                newPosition = new Vector3(newPosition.x - TileSize, newPosition.y, newPosition.z);
            else if (Input.GetKeyDown(Down))
                newPosition = new Vector3(newPosition.x, newPosition.y - TileSize, newPosition.z);
            else if (Input.GetKeyDown(Right))
                newPosition = new Vector3(newPosition.x + TileSize, newPosition.y, newPosition.z);
            else if (Input.GetKeyDown(Action))
                CreateArrow();
            

            if (transform.position != newPosition)  // AKA the player pressed a button
            {
                positionLerp = 0;
                newPosition = new Vector3(Mathf.Clamp(newPosition.x, -4.44f, 4.44f), Mathf.Clamp(newPosition.y, -4.44f, 4.44f), newPosition.z);
            }
        }

	}
    public void CreateArrow()
    {
        current_piece.transform.position = transform.position;
        current_piece.GetComponent<Arrow>().RunDestroyTimer = true;

        next_piece.transform.position = current_panel.transform.position;
        current_piece = next_piece;
        current_piece.transform.position = new Vector3(current_piece.transform.position.x, current_piece.transform.position.y, -5);

        next_piece = Instantiate(arrowsPrefab[index], next_panel.transform.position, transform.rotation);
        next_piece.transform.position = new Vector3(next_piece.transform.position.x, next_piece.transform.position.y, -5);
    }

    private void MoveCursor()
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
