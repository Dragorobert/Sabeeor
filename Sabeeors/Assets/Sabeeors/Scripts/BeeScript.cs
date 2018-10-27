using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour 
{
    public  float speed = 0.4f;
    public enum Direction {right,left,up,down};
    public Direction currentDirection;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
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
    /*void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("COLLISION");
    }*/
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision Pared");
    }

}
