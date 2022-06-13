using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Colors ballColor;
    public GameObject target;
    public int ballRank;
    public int ballCount;
    public bool isMoving = false;
    public enum Colors 
    {
        red, 
        blue,
        green
    };

    void Start()
    {

    }

    void Update()
    {
        if (isMoving)
        {
            if (target.transform.position == gameObject.transform.position)
            {
                isMoving = false;
                //Destroy(gameObject);
                gameObject.SetActive(false);
                Debug.Log(ballRank);
                if (ballRank == ballCount)
                {
                    //Destroy(target.gameObject);
                    target.gameObject.SetActive(false);
                }
            }
            else
            {
                MoveBall();
            }
        }

        
        
    }

    public void MoveBall()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
    }

    public void TargetBall(GameObject target, int ballRank, int ballCount)
    {
        this.target = target;
        this.ballRank = ballRank;
        this.ballCount = ballCount;
    }


}
