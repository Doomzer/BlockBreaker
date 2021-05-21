using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minPosXInUnits = 1f;
    [SerializeField] float maxPosXInUnits = 15f;

    GameStatus myGameStatus;
    Ball myBall;
    // Start is called before the first frame update
    void Start()
    {
        myGameStatus = FindObjectOfType<GameStatus>();
        myBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minPosXInUnits, maxPosXInUnits);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (myGameStatus.IsAutoPlay())
            return myBall.transform.position.x;
        else
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
}
