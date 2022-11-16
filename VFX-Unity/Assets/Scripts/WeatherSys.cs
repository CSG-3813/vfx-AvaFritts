using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WeatherSys : MonoBehaviour
{
    public GameObject rainGO;
    ParticleSystem rainPS;

    public float rainTime = 10;

    public AudioMixerSnapshot raining;
    public AudioMixerSnapshot sunny;

    //public float sunnyTime = 10;
    float timerTime;
    bool startTime;
    AudioSource audioSrc;

    bool isRaining;
    public bool IsRaining { get { return isRaining; } }

    public Volume rainProcess;

    float lerpValue;
    float lerpTime = 10;
    float transitionTime;

    // Start is called before the first frame update
    void Start()
    {
        rainPS = rainGO.GetComponent<ParticleSystem>();
        audioSrc = rainGO.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime)
        {
            if(timerTime > 0)
            {
                timerTime -= Time.deltaTime;
                TintSky();
            }
            else
            {
                EndRain();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Rain");
        if(other.tag == "Player")
        {
            if (!startTime)
            {
                timerTime = rainTime;
                startTime = true;
                isRaining = true;
                rainPS.Play();
                audioSrc.Play();
                raining.TransitionTo(2.0f);
            }
        }
    }//end on trigger enter

    void EndRain()
    {
        startTime = false;
        isRaining = false;
        rainPS.Stop();
        audioSrc.Stop();
        sunny.TransitionTo(2.0f);
    }

    void TintSky()
    {
        if(transitionTime < lerpTime)
        {
            lerpValue = Mathf.Lerp(0, .59f, transitionTime/lerpTime);
            transitionTime += Time.deltaTime;
            rainProcess.weight = lerpValue;
        }
    }
}
