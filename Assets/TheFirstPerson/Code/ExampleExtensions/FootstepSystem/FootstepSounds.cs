using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstPerson;

//A dynamic footstep system. due to how the terrain texture is retrieved this will not function in versions earlier than 2018.3
//this should be placed on the same object as FPSController.cs
//leftFoot and rightFoot can be the same audio source if you don't want to have seperate sources for the feet

public class FootstepSounds : TFPExtension
{

    public float distanceBetweenFootsteps;
    public AudioClip hoveringSound;
    public FootstepGroup[] footsteps;
    public AudioSource hoveringSoundEffect;
    public FootstepGroup defaultFootsteps;
    float leftDistance, rightDistance;

    RaycastHit groundTypeCheck;


    public override void ExPostUpdate(ref TFPData data, TFPInfo info)
    {
        if (data.moving)
        {
            if(!hoveringSoundEffect.isPlaying)
                hoveringSoundEffect.Play();
        }
        else
        {
            hoveringSoundEffect.Stop();
        }

    }

    AudioClip GetClip(TFPInfo info)
    {
        if (Physics.SphereCast(transform.position + (Vector3.up * info.controller.radius), info.controller.radius, Vector3.down, out groundTypeCheck, info.crouchHeadHitLayerMask.value))
        {
            TerrainCollider hitTerrain = groundTypeCheck.transform.GetComponent<TerrainCollider>();
            MeshRenderer hitMesh = groundTypeCheck.transform.GetComponent<MeshRenderer>();
            Texture2D hitTexture;
            if (hitTerrain != null)
            {
                hitTexture = TerrainSurface.GetMainTexture(groundTypeCheck.transform.GetComponent<Terrain>(), transform.position);
            }
            else if (hitMesh != null)
            {
                hitTexture = hitMesh.material.mainTexture as Texture2D;
            }
            else
            {
                return defaultFootsteps.footSounds[Random.Range(0, defaultFootsteps.footSounds.Length)];
            }
            foreach (FootstepGroup fsGroup in footsteps)
            {
                foreach (Texture2D tex in fsGroup.textures)
                {
                    if (hitTexture == tex)
                    {
                        return fsGroup.footSounds[Random.Range(0, fsGroup.footSounds.Length)];
                    }
                }
            }
        }
        return defaultFootsteps.footSounds[Random.Range(0, defaultFootsteps.footSounds.Length)];
    }

}
