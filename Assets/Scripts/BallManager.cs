using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    Balls ball;
    InputController inputController;
    public Balls[] allBalls;

    void Start()
    {
        allBalls = FindObjectsOfType<Balls>();
    }

    void Update()
    {
        if(allBalls.Length == 0)
        {
            NextLevel();
        }
    }

    void NextLevel()
    {

    }

}
