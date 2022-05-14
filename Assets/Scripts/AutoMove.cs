using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] Vector3 moveVector;
    [SerializeField] [Range(0,1)] float moveFactor;
    [SerializeField] float period = 10f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon){return;}
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        moveFactor = (rawSinWave + 1f) / 2f;
        Vector3 offset = moveVector * moveFactor;
        transform.position = startPosition + offset;
    }
}
