using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MovingRock : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector;

    [Range(0, 1)] [SerializeField] private float movementValue;

    private Vector3 startingPoint;

    [SerializeField] private float period = 4f;

    void Start()
    {
        startingPoint = transform.position;
        movementValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (period > 0f)
        {
            MoveRock();
        }
    }

    private void MoveRock()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementValue = rawSinWave / 2f + 0.5f;
        //movementValue = Mathf.PingPong(Time.time/2f,1f); or you can use this way

        Vector3 distanceValue = movementVector * movementValue;
        transform.position = startingPoint + distanceValue;
    }

    //My movement method
    //private void MovingBigRock()
    //{
    //    if (isDestiny)
    //    {
    //        movementValue += 0.006f;
    //        Vector3 distanceValue = movementVector * movementValue;
    //        transform.position = startingPoint + distanceValue;
    //        if (movementValue >= 1f)
    //        {
    //            isDestiny = false;
    //        }
    //    }
    //    else
    //    {
    //        movementValue -= 0.006f;
    //        Vector3 distanceValue = movementVector * movementValue;
    //        transform.position = startingPoint + distanceValue;
    //        if (movementValue <= 0f)
    //        {
    //            isDestiny = true;
    //        }
    //    }

    //}
}
