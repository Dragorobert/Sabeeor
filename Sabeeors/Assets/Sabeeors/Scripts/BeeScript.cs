using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour 
{
    public  float speed = 0.4f;
    public enum Direction {right,left,up,down};
    public Direction currentDirection;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentDirection == Direction.right)
        {
          MovRight();
        }
        else if (currentDirection == Direction.left)
        {
          MovLeft();
        }
        else if (currentDirection == Direction.up)
        {
          MovUp();
        }
        else if (currentDirection == Direction.down)
        {
         MovDown();
        }
     }
     public void MovRight()
     {
      this.transform.Translate(Vector2.right * speed * Time.deltaTime);
     }
     public void MovLeft()
     {
       this.transform.Translate(Vector2.left * speed * Time.deltaTime);
     }
     public void MovUp()
     {
       this.transform.Translate(Vector2.up * speed * Time.deltaTime);
     }
     public void MovDown()
     {
       this.transform.Translate(Vector2.down * speed * Time.deltaTime);
     }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Wall")
        { 
        reverseDirection();
        }

    }

    void reverseDirection()
    {
        switch (currentDirection) {
            case Direction.up:
                currentDirection = Direction.down;
                break;
            case Direction.left:
                currentDirection = Direction.right;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                break;
            case Direction.down:
                currentDirection = Direction.up;
                break;
            case Direction.right:
                currentDirection = Direction.left;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                break;
        }
    }

}
