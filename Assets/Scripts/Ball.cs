using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle playerPaddle;
    [SerializeField] float xPush = 0f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.5f;

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - playerPaddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

    }

    void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(playerPaddle.transform.position.x, playerPaddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);

            int x = 1;
            int y = 1;
            if (myRigidbody2D.velocity.x < 0)
                x = -1;
            if (myRigidbody2D.velocity.y < 0)
                y = -1;

            Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor) * x, Random.Range(0f, randomFactor) * y);

            Debug.Log(myRigidbody2D.velocity + " " + velocityTweak);
            myRigidbody2D.velocity += velocityTweak;
        }
    }
}
