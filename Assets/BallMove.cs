using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform ballTransform;
    private SpeedFunc speedFunc;
    private float speed;
    private int direction = 1;
    private bool isMoving = true;
    private bool outRange = false;
    public float WaitTime = 5f;
    private float startPosition;
    private float endPosition;

    void Awake()
    {
        ballTransform = GetComponent<Transform>();
        speedFunc = GetComponent<SpeedFunc>();
        startPosition = speedFunc.startposition;
        endPosition = speedFunc.endposition;
    }
    void FixedUpdate()
    {
        if (!isMoving)
            return;

        if(ballTransform.position.x <= endPosition && ballTransform.position.x >= startPosition && outRange)
        {
            outRange = false;
        }
        else if((ballTransform.position.x >= endPosition || ballTransform.position.x <= startPosition) && !outRange)
        {
            isMoving = false;
            outRange = true;
            direction = -direction;
            StartCoroutine(WaitAndMove());
        }
        speed = speedFunc.GetSpeed();
        ballTransform.position = new Vector3(ballTransform.position.x + direction * speed * Time.fixedDeltaTime, ballTransform.position.y, ballTransform.position.z);

    }
    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(WaitTime);
        isMoving = true;
    }
}
