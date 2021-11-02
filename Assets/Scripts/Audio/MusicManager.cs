using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MusicManager : SingletonMonoBehaviour<MusicManager>
{ 

    public AudioSource audioSource01;
    public AudioSource audioSource02;

    [Header("Music Clips")]
    public AudioClip menuMusic;
    public AudioClip desertLevelMusic;
    public AudioClip bottomLevel;
    public AudioClip topLevel;
    public AudioClip bridgeMusic;
    public AudioClip restoredMusic;

    [SerializeField] private AudioMixer audioMixer;
    public float fadeTime = 5;

    private string currentAudioGroup;
    private AudioSource currentAudioSource;

    private const string crossFadeGroup01 = "CrossFadeGroup01";
    private const string crossFadeGroup02 = "CrossFadeGroup02";

    void Start()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnLoadCallBack;
        OnLoadCallBack(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    public void CrossFadeMusic(AudioClip audioClip)
    {


        if (currentAudioGroup == crossFadeGroup01)
        {
            currentAudioSource = audioSource02;
            currentAudioGroup = crossFadeGroup02;
            currentAudioSource.clip = audioClip;
            currentAudioSource.Play();
            StartCoroutine(StartFade(audioMixer, currentAudioGroup, 5, 1));
            StartCoroutine(StartFade(audioMixer, crossFadeGroup01, 5, 0));
        }
        else
        {
            currentAudioSource = audioSource01;
            currentAudioGroup = crossFadeGroup01;
            currentAudioSource.clip = audioClip;
            currentAudioSource.Play();
            StartCoroutine(StartFade(audioMixer, currentAudioGroup, 5, 1));
            StartCoroutine(StartFade(audioMixer, crossFadeGroup02, 5, 0));
        }

    }

    public void PlayMusic(AudioClip audioClip)
    {
        currentAudioGroup = crossFadeGroup01;
        currentAudioSource = audioSource01;
        currentAudioSource.clip = audioClip;
        currentAudioSource.Play();
    }

    private void MuteCurrentAudioGroup()
    {
        audioMixer.SetFloat(currentAudioGroup, -80);
    }

    public static IEnumerator StartFade(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume)
    {
        float currentTime = 0;
        float currentVol;
        audioMixer.GetFloat(exposedParam, out currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20);
            yield return null;
        }
        yield break;
    }

    private void OnLoadCallBack(Scene scene, LoadSceneMode mode)
    {
        print(scene.name);
        if (scene.name == "Top Level")
        {
            CrossFadeMusic(topLevel);
        }

        if (scene.name == "Menu")
        {
            PlayMusic(menuMusic);
        }

        if (scene.name == "Bridge")
        {
            CrossFadeMusic(bridgeMusic);
        }

        if (scene.name == "Restored Desert")
        {
            CrossFadeMusic(restoredMusic);
        }

        if (scene.name == "Desert Start Area")
        {
            CrossFadeMusic(desertLevelMusic);
        }

    }
}


enum MixerExposedParams
{
    CrossFadeVolume,
    LevelMusicVolume
}

enum AudioGroups
{
    MenuMusic,
    DeserArea,
    TopLevel
}