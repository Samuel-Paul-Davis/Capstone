using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    private AudioSource audioSource;

    public AudioClip menuMusic;
    public AudioClip desertLevelMusic;
    public AudioClip bottomLevel;
    public AudioClip topLevel;

    public float fadeTime = 10;

    void Start()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnLoadCallBack;
        audioSource = GetComponent<AudioSource>();
        PlayClip(menuMusic);
    }

    private void ChangeMusic(AudioClip clip)
    {
        if (!clip)
        {
            Debug.LogWarning("No Music Clip Found");
            return;
        }

        StartCoroutine(StartFade(audioSource, 2, 0, clip));

    }

    private void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    private void FadeOut()
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
        }
    }   
    private void FadeIn()
    {
        while (audioSource.volume < 1)
        {
            audioSource.volume += Time.deltaTime / fadeTime;
        }
    }


    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume, AudioClip clip)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }

        //TODO:Yeild wait in main branch to be able to easily switch music without doing this horrible thing
        audioSource.clip = clip;
        audioSource.Play();
        yield return new WaitForSeconds(5.0f);

        float currentTime1 = 0;
        float start1 = audioSource.volume;
        while (currentTime1 < duration)
        {
            currentTime1 += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start1, 1, currentTime1 / 10);
            yield return null;
        }
        yield break;
    }

    private void OnLoadCallBack(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Top Level")
        {
            ChangeMusic(topLevel);
        }
        else
        {
            PlayClip(desertLevelMusic);
        }
    }
}
