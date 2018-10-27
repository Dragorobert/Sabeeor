using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour 
{

    Transform mytransform;
  public  float speed = 0.4f;
  public  float timerStart;
    float timerOut = 1f;
    public float timerStart1;
  public  float timerOut1 = 1f;
    float limitposX = 1f;


  public  float stuntime = 1.2f;
   public bool direcRight;

    public bool horizontal;
    public bool vertical;

   public bool direcUp;

    bool timer;
    public bool choque = true;


    // Use this for initialization
    void Start() {
        mytransform = GetComponent<Transform>();
         float posx = transform.position.x;

}

    // Update is called once per frame
    void Update()
    {
        if (horizontal)
        {
            if (direcRight)
            {
                MovRight();
            }
            else if (!direcRight)
            {
                Movleft();
            }
        }
        if (vertical)
        {
            if (direcUp)
            {
                MovUP();
            }
            else if (!direcUp)
            {
                Movdown();
            }



        }
        timerStart += Time.deltaTime;
        timerStart1 += Time.deltaTime;
    }
   public void MovRight()
    {
        if (timerStart1 < timerOut1)
        {

            mytransform.Translate(Vector2.right * speed * Time.deltaTime);
            timer = true;
            timerStart = 0;

        }
        if (timer)
        {
            if (timerStart > timerOut)
            {
                timerStart1 = 0;
            }

        }
    }
      public void Movleft()
        {
            if (timerStart1 < timerOut1)    
            {

            mytransform.Translate(-Vector2.right * speed * Time.deltaTime);

            timer = true;
                timerStart = 0;

            }
            if (timer)
            {
                if (timerStart > timerOut)
                {
                    timerStart1 = 0;
                }
            }
            /*  if (timerStart > timerOut)
              {
                  float posx = mytransform.position.x - limitposX;
                  timerStart = 0;
                  if (mytransform.position.x > posx)
                  {
                      mytransform.Translate(-Vector2.right * speed);
                      Debug.Log(posx);
                  } */

        }
     public   void MovUP()
        {
            if (timerStart1 < timerOut1)
            {

                mytransform.Translate(Vector2.up * speed);
                timer = true;
                timerStart = 0;

            }
            if (timer)
            {
                if (timerStart > timerOut)
                {
                    timerStart1 = 0;
                }
            }/*
        if (timerStart > timerOut)
        {
            float posy = mytransform.position.y + limitposX;
            timerStart = 0;
            if (mytransform.position.y < posy)
            {
                mytransform.Translate(Vector2.up * speed);
            }
        }*/
        }
     public   void Movdown()
        {
            if (timerStart1 < timerOut1)
            {

                mytransform.Translate(-Vector2.up * speed);
                timer = true;
                timerStart = 0;

            }
            if (timer)
            {
                if (timerStart > timerOut)
                {
                    timerStart1 = 0;
                }
            }

        }
    
}
