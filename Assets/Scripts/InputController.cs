using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Balls ball;
    public BallManager ballManager;
    public int movementSpeed = 1;
    Vector3 mousePos;
    Vector2 mousePos2D;
    public List<Balls> SameBallsList;
    // event ata, seçilen top bu evente register olacak.
    // BallManager ınputcontroller'ı dinleyecek. 
    void Start()
    {
        
    }

    void Update()
    {
        Clicked();
    }

    void Clicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos2D = new Vector2(mousePos.x, mousePos.y);
            SameBallsList = new List<Balls>();

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {

                for (int i = 0; i < ballManager.allBalls.Length; i++)
                {
                    if (hit.collider.gameObject.GetComponent<Balls>().ballColor == ballManager.allBalls[i].ballColor)
                    {
                        if(hit.collider.transform.position != ballManager.allBalls[i].transform.position)
                            SameBallsList.Add(ballManager.allBalls[i]);
                    }
                }                
            }
            for (int i = 0; i < SameBallsList.Count; i++)
            {
                SameBallsList[i].TargetBall(hit.collider.gameObject, SameBallsList.Count-i, SameBallsList.Count);
                SameBallsList[i].isMoving = true;
            }
        }
    }
}
