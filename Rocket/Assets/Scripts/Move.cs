using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float thrust = 10f;
    [SerializeField] float rotate = 10f;
    [SerializeField] AudioClip engine;
    [SerializeField] ParticleSystem boostPar;
    [SerializeField] ParticleSystem leftPar;
    [SerializeField] ParticleSystem rightPar;
    Rigidbody rb;
    AudioSource audios;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessBoost();
        ProcessRotate();
    }

    void ProcessBoost()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            boosting();
        }
        else
        {
            stopBoosting();
        }
    }

    void ProcessRotate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rotateLeft();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rotateRight();
        }
        else
        {
            stopRotate();
        }
    }

    void boosting()
    {
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * thrust);
        if (!audios.isPlaying)
        {
            audios.PlayOneShot(engine);
        }
        if (!boostPar.isPlaying)
        {
            boostPar.Play();
        }
    }

    void stopBoosting()
    {
        boostPar.Stop();
        audios.Stop();
    }

    void rotation(float rotateThis)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotateThis *Time.deltaTime * rotate);
        rb.freezeRotation = false;
    }

    void stopRotate()
    {
        rightPar.Stop();
        leftPar.Stop();
    }

    void rotateRight()
    {
        rotation(-rotate);
        if (!leftPar.isPlaying)
        {
            leftPar.Play();
        }
    }

    void rotateLeft()
    {
        rotation(rotate);
        if (!rightPar.isPlaying)
        {
            rightPar.Play();
        }
    }
}
