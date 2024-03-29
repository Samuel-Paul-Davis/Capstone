using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

#if UNITY_EDITOR

using UnityEditor.Experimental.SceneManagement;

#endif

using System;
using System.Text.RegularExpressions;

/// <summary>
/// Finds player object and automatically generates references where needed (e.g. sets player object as �look at� target)
/// </summary>
[ExecuteAlways]
public class InitializeCameras : MonoBehaviour
{
    public enum PrefabEnum
    {
        ClearShot,
        Dolly
    }

    private GameObject[] _gameObjects;
    private GameObject _player;

    public PrefabEnum prefabEnum;
    public ClearShotInspector clearShotInspector;
    public DollyInspector dollyInspector;

    private const string _PlayerTagName = "Player";
    //    private const string _DollyPattern = "^DollyCamera.*";
    //    private const string _ClearShotPattern = "(^Tracking|^Fixed)Cameras.*";

    // Awake is called when the script is initialized
    private void Awake()
    {
        /// <summary>
        /// Checks IF the inspector is editing a prefab, and does not execute to avoid modifying the prefab
        /// </summary>
#if UNITY_EDITOR
        if (!PrefabStageUtility.GetCurrentPrefabStage()) //should not run in Prefab Mode (experimental API)
        {
            InitializeClearShot();
            InitializeDolly();

            //Regex dollyRegex = new Regex(_DollyPattern);
            //Regex clearShotRegex = new Regex(_ClearShotPattern);

            /// <summary>
            /// Operations are different depending on whether the script is running on a DollyCamera.prefab or FixedCameras.prefab/TrackingCameras.prefab
            /// </summary>
            /*try
            {
                if (dollyRegex.IsMatch(name))
                {
                    InitializeDolly();
                    return;
                }

                if (clearShotRegex.IsMatch(name))
                {
                    InitializeClearShot();
                    return;
                }

                throw new Exception(
                    "Type of camera prefab not recognized. " +
                    "When renaming camera prefabs in scene hierarchy, please keep the original name first followed by the new name. Example:\n" +
                    "\t'TrackingCameras' -> 'TrackingCameras<custom name>'"
                    );
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }*/
        }
#else
            InitializeClearShot();
            InitializeDolly();
#endif
    }

    /// <summary>
    /// This method is a recursive search algorithm that finds the player GameObject by walking from the deepest nested GameObject in gArr back to the root Object
    /// </summary>
    /// <param name="gArr">'gArr' is the list of GameObjects to be searched</param>
    /// <param name="gObj">gObj is designed to be used internally. It would be possible to use overloading to obfuscate this further.</param>
    /// <returns>This method returns the player as a GameObject.</returns>
    private GameObject FindPlayerObject(ref GameObject[] gArr, GameObject gObj = null)
    {
        if (gObj)
        {
            GameObject gObjParent;

            if (gObj.transform != gObj.transform.root)
                gObjParent = gObj.transform.parent.gameObject;
            else
                gObjParent = null;

            if (gObj.GetComponent<CharacterController>() && gObj.CompareTag(_PlayerTagName))
                return gObj;
            else if (gObjParent && gObjParent.CompareTag(_PlayerTagName))
                return FindPlayerObject(ref gArr, gObjParent);
            else if (!gObjParent && !gObj.GetComponent<CharacterController>() && gObj.CompareTag(_PlayerTagName))
                throw new Exception("No GameObject tagged as 'Player' has CharacterController component!");
            else
                throw new Exception("No 'Player' GameObject not found in array!");
        }
        else
        {
            if (gArr != null && gArr.Length > 0)
                return FindPlayerObject(ref gArr, gArr[gArr.Length - 1]);
            else
                throw new Exception("Array of 'Players' is null; are you sure there is a GameObject tagged 'Player'?");
        }
    }

    private bool SetPlayerObject()
    {
        _gameObjects = GameObject.FindGameObjectsWithTag(_PlayerTagName);

        //validation; should be forwards compatible with Unity 2020.3+
        try
        {
            _player = FindPlayerObject(ref _gameObjects);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return false;
        }

        return true;
    }

    /// <summary>
    /// This method performs all operations related to prefilling CM ClearShot prefabs
    /// </summary>
    private void InitializeClearShot()
    {
        //prefabEnum = PrefabEnum.ClearShot;

        //default values
        if (clearShotInspector.ignoreTag == "")
            clearShotInspector.ignoreTag = _PlayerTagName;
        if (clearShotInspector.optimalTargetDistance == 0.0)
            clearShotInspector.optimalTargetDistance = 2;

        if (!SetPlayerObject())
            return;

        clearShotInspector.lookAt = _player;

        CinemachineClearShot clearShot = gameObject.GetComponentInChildren<CinemachineClearShot>();
        CinemachineCollider collider = gameObject.GetComponentInChildren<CinemachineCollider>();

        if (!clearShot.LookAt)
            clearShot.LookAt = clearShotInspector.lookAt.transform;

        if (collider.m_IgnoreTag == "")
            collider.m_IgnoreTag = clearShotInspector.ignoreTag;
        if (collider.m_OptimalTargetDistance == 0.0)
            collider.m_OptimalTargetDistance = clearShotInspector.optimalTargetDistance;
    }

    /// <summary>
    /// This method performs all operatations related to CM Dolly Camera prefabs
    /// </summary>
    private void InitializeDolly()
    {
        //prefabEnum = PrefabEnum.Dolly;

        if (!SetPlayerObject())
            return;

        dollyInspector.lookAt = _player;
        dollyInspector.follow = _player;

        CinemachineVirtualCamera cmVirtualCamera = gameObject.GetComponentInChildren<CinemachineVirtualCamera>();

        cmVirtualCamera.m_Follow = dollyInspector.follow.transform;
        cmVirtualCamera.m_LookAt = dollyInspector.lookAt.transform;
    }
}

/// <summary>
/// This structure stores the fields displayed in the Inspector for CM Clear Shot prefabs
/// </summary>
[Serializable]
public struct ClearShotInspector
{
    [Header("CM ClearShot")]
    public GameObject lookAt;

    [Header("CM Collider")]
    public string ignoreTag;

    public float optimalTargetDistance;
};

/// <summary>
/// This structure stores the fields displayed in the Inspector for CM Dolly prefabs
/// </summary>
[Serializable]
public struct DollyInspector
{
    public GameObject lookAt;
    public GameObject follow;
}