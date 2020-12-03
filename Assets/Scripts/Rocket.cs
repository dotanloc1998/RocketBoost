using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame 
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip boost, death, passLevel;

    [SerializeField] private ParticleSystem engineParticle, successParticle, explodeParticle;

    [SerializeField] private float rcsBoost;
    [SerializeField] private float mainBoost;
    [SerializeField] private bool godMod;
    private float levelLoadDelay = 1f;
    private float rotationSpeed;
    enum State { Dying, Alive, Transcending }
    [SerializeField] State _state;
    private int _currentScene;
    private int _sceneCount;
    void Awake()
    {
        _state = State.Alive;
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        rcsBoost = 200f;
        mainBoost = 50f;
        rotationSpeed = rcsBoost * Time.deltaTime;
        _currentScene = SceneManager.GetActiveScene().buildIndex;
        _sceneCount = SceneManager.sceneCountInBuildSettings;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_state == State.Alive || godMod)
        {
            Boost();
            Rotate();
            Escape();
        }

        if (Debug.isDebugBuild)
        {
            ActivateGodMode();
        }
    }

    private void Escape()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void ActivateGodMode()
    {
        if (Input.GetKey(KeyCode.C))
        {
            if (godMod)
            {
                godMod = false;
            }
            else
            {
                godMod = true;
            }
        }
        else if (Input.GetKey(KeyCode.L))
        {
            FinishLevel();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (_state != State.Alive || godMod)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                //print("OK");
                break;
            case "Fuel":
                //nothing yet
                break;
            case "Finish":
                FinishLevel();
                break;
            default:
                Explode();
                break;
        }
    }

    private void Explode()
    {
        _state = State.Dying;
        engineParticle.Stop();
        explodeParticle.Play();
        _audioSource.Stop();
        _audioSource.PlayOneShot(death);
        Invoke("LoadCurrentScene", levelLoadDelay);
    }

    private void FinishLevel()
    {
        _state = State.Transcending;
        engineParticle.Stop();
        successParticle.Play();
        _audioSource.Stop();
        _audioSource.PlayOneShot(passLevel);
        Invoke("LoadNextScene", levelLoadDelay);
    }

    private void LoadCurrentScene()
    {
        SceneManager.LoadScene(_currentScene);
    }

    private void LoadNextScene()
    {
        if (_currentScene == _sceneCount - 1)
        {
            _currentScene = 0;
            SceneManager.LoadScene(_currentScene);
        }
        else
        {
            SceneManager.LoadScene(++_currentScene);
        }
    }

    private void Rotate()
    {
        _rigidbody.freezeRotation = true;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
        //Make Rigidbody constranints all value below.
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
    }

    private void Boost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            AddPower();
        }
        else
        {
            _audioSource.Stop();
            engineParticle.Stop();
        }
    }

    private void AddPower()
    {
        _rigidbody.AddRelativeForce(Vector3.up * mainBoost);

        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(boost);
        }
        engineParticle.Play();
    }
}
