using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedFunc : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform ballTransform;
    public float maxSpeed = 100f;
    public float minSpeed = 0.1f;
    public float endposition = 20f;
     public float startposition = 0f;
     private float a,b,c;
    void Awake()
    {
        ballTransform = GetComponent<Transform>();
        c=maxSpeed;
        a=(maxSpeed-2*minSpeed+c)/(endposition*endposition/2);
        b=(maxSpeed-endposition*endposition*a-c)/endposition;

    }
    public float GetSpeed()
    {
        float speed;
        
        if(ballTransform.position.x >= startposition && ballTransform.position.x <= endposition)
        {
            speed = a*ballTransform.position.x*ballTransform.position.x + b*ballTransform.position.x + c;
        }
        else
        {
            speed = minSpeed;
        }

        return speed;
    }
}
