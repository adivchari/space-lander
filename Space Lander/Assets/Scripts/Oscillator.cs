using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 MovementVector;
    float amplitude;
    [SerializeField] float period = 2f;
    float tau = Mathf.PI * 2;                      //   Constant value

    void Start()
    {
        startingPosition = transform.position;
    }

    
    void Update()
    {
        if(period <= Mathf.Epsilon) { return; }                 // because comparing to zero with floats is not precise. epsilon is smallest no in mathf
        float cycles = Time.time / period;                      //   TimeElapsed/TimePeriod  always groing
        float amplitude = (Mathf.Sin(tau*cycles)+1)/2;                //[-1,1] -> [0,2]
        Vector3 offset = MovementVector*amplitude;                // New Position = Starting + MaxDisplacement* Sine
        transform.position = startingPosition+offset;
    }
}
