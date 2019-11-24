using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCaveEnter : MonoBehaviour
{
    [SerializeField]
    private GameObject FirstRoomObject, OusideObject, caveObject;

    [SerializeField]
    private GameObject audioManagerObject;

    [SerializeField]
    private AudioClip outsideSound;

    private AudioSource audio;

    private void Start()
    {
        audio = audioManagerObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //cue door closing
            //play door closeing sound
            OusideObject.SetActive(true);//turn on outside room
            FirstRoomObject.SetActive(false);//turn off first room
            caveObject.SetActive(false);//turns off the cave so you just have an arch

            //play sound
            StartCoroutine(FadeOut(.5f));
        }
    }

    private IEnumerator FadeOut(float FadeTime)
    {
        float startVolume = audio.volume;
        while (audio.volume > 0)
        {
            audio.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audio.Stop();
        audio.clip = outsideSound;
        StartCoroutine(FadeIn(.5f));
    }

    private IEnumerator FadeIn(float FadeTime)
    {
        audio.Play();
        audio.volume = 0f;
        while (audio.volume < 1)
        {
            audio.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }
}
