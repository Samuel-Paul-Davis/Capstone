using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor.Experimental.SceneManagement;

using System;

[ExecuteAlways]
public class InitializeCameras : MonoBehaviour
{
    private GameObject[] gameObjects;
    [Header("CM ClearShot")]
    [SerializeField]
    private GameObject lookAt;

    [Header("CM Collider")]
    public string ignoreTag;
    public float optimalTargetDistance;

    // Awake is called when the script is initialized
    void Awake()
    {
        if (!PrefabStageUtility.GetCurrentPrefabStage()) //should not run in Prefab Mode (experimental API)
        {
            InitializeClearShot();
            //default values
            if (ignoreTag == "") ignoreTag = "Player";
            if (optimalTargetDistance == 0.0) optimalTargetDistance = 2;

            gameObjects = GameObject.FindGameObjectsWithTag("Player");

            //validation; should be forwards compatible with Unity 2020.3+
            try
            {
                lookAt = FindPlayerObject(ref gameObjects);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return;
            }

            CinemachineClearShot clearShot = gameObject.GetComponentInChildren<CinemachineClearShot>();
            CinemachineCollider collider = gameObject.GetComponentInChildren<CinemachineCollider>();

            if (!clearShot.LookAt)
                clearShot.LookAt = lookAt.transform;

            if (collider.m_IgnoreTag == "")
                collider.m_IgnoreTag = ignoreTag;
            if (collider.m_OptimalTargetDistance == 0.0)
                collider.m_OptimalTargetDistance = optimalTargetDistance;
        }
    }

    private GameObject FindPlayerObject(ref GameObject[] gArr, GameObject gObj = null)
    {
        if (gObj)
        {
            GameObject gObjParent;

            if (gObj.transform != gObj.transform.root) gObjParent = gObj.transform.parent.gameObject;
            else gObjParent = null;

            if (gObj.GetComponent<CharacterController>() && gObj.CompareTag("Player")) return gObj;
            else if (gObjParent && gObjParent.CompareTag("Player")) return FindPlayerObject(ref gArr, gObjParent);
            else if (!gObjParent && !gObj.GetComponent<CharacterController>() && gObj.CompareTag("Player")) throw new Exception("No GameObject tagged as 'Player' has CharacterController component!");
            else throw new Exception("No 'Player' GameObject not found in array!");
        }
        else
        {
            if (gArr != null && gArr.Length > 0) return FindPlayerObject(ref gArr, gArr[gArr.Length - 1]);
            else throw new Exception("Array of 'Players' is null; are you sure there is a GameObject tagged 'Player'?");
        }
    }

    private void InitializeClearShot()
    {
        //default values
        if (ignoreTag == "") ignoreTag = "Player";
        if (optimalTargetDistance == 0.0) optimalTargetDistance = 2;

        gameObjects = GameObject.FindGameObjectsWithTag("Player");

        //validation; should be forwards compatible with Unity 2020.3+
        try
        {
            lookAt = FindPlayerObject(ref gameObjects);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return;
        }

        CinemachineClearShot clearShot = gameObject.GetComponentInChildren<CinemachineClearShot>();
        CinemachineCollider collider = gameObject.GetComponentInChildren<CinemachineCollider>();

        if (!clearShot.LookAt)
            clearShot.LookAt = lookAt.transform;

        if (collider.m_IgnoreTag == "")
            collider.m_IgnoreTag = ignoreTag;
        if (collider.m_OptimalTargetDistance == 0.0)
            collider.m_OptimalTargetDistance = optimalTargetDistance;
    }
}