using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour
{
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip win;
    [SerializeField] ParticleSystem successPar;
    [SerializeField] ParticleSystem crashPar;
    bool isTransition = false;
    bool collide = true;
    AudioSource audios;

    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    void Update()
    {
        CheatKey();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransition == false)
        {
            switch (other.gameObject.tag)
            {
                case "Respawn":
                    Debug.Log("Reach the Finish Pad");
                    break;
                case "Finish":
                    WinPlayer();
                    break;
                default:
                    CrashPlayer();
                    break;
            }
        }
    }

    void CrashPlayer()
    {
        if (isTransition == false && collide == true)
        {
            GetComponent<Move>().enabled = false;
            Invoke("ReloadLevel",2f);
            audios.Stop();
            audios.PlayOneShot(crash);
            crashPar.Play();
            isTransition = true;
        }
    }

    void WinPlayer()
    {
        if (isTransition == false)
        {
            GetComponent<Move>().enabled = false;
            Invoke("NextLevel",2f);
            audios.Stop();
            audios.PlayOneShot(win);
            successPar.Play();
            isTransition = true;
        }
    }

    void CheatKey()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            NextLevel();
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            if (collide == true)
            {
                collide = false;
                Debug.Log("Cheat Activated: No Crash");
            }
            else 
            {
                collide = true;
                Debug.Log("Cheat Deactivated");
            }
            //collide = !collide;
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
