using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstPerson;

//A dynamic footstep system. due to how the terrain texture is retrieved this will not function in versions earlier than 2018.3
//this should be placed on the same object as FPSController.cs
//leftFoot and rightFoot can be the same audio source if you don't want to have seperate sources for the feet

public class FootstepSounds : TFPExtension
{

    CharacterController characterController;
    public AudioSource hoveringSoundEffect;
    bool CRisRunning = false;
    private bool RunningTransition = false;
    private float idlePitch;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        hoveringSoundEffect.Play();
        idlePitch = hoveringSoundEffect.pitch;
    }

    public override void ExPostMove(ref TFPData data, TFPInfo info)
    {
        base.ExPostMove(ref data, info);
        if (data.moving && !CRisRunning && !data.running)
        {
            CRisRunning = true;
            StartCoroutine(PitchAudio(hoveringSoundEffect.pitch));
        }
        else if(!data.moving)
        {
            hoveringSoundEffect.pitch = idlePitch;
            CRisRunning = false;
        }
    }

    private IEnumerator PitchAudio(float currentPitch)
    {
        float time = 0;
        float duration = 0.3f;
        while(time < duration)
        {
            hoveringSoundEffect.pitch = Mathf.Lerp(1, 1.5f, time / duration);
            time += Time.deltaTime;

            yield return null;
        }
    }


}
