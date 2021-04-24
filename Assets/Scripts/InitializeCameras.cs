using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

[ExecuteAlways]
public class InitializeCameras : MonoBehaviour
{
    private GameObject[] gameObjects;
    private GameObject playerObject;

    // Start is called before the first frame update
    void Awake()
    {
        if (!Application.IsPlaying(gameObject)) //should run only in edit mode
        {
            gameObjects = GameObject.FindGameObjectsWithTag("Player");

            //validation; should be forwards compatible with Unity 2020.3+
            if (gameObjects.Length > 1)
            {
                try
                {
                    playerObject = FindHighestLevelPlayerObject(ref gameObjects);
                } catch (Exception e)
                {
                    Debug.Log(e);
                }
            } else if (gameObjects.Length > 0)
            {
                playerObject = gameObjects[0];
            } else
            {
                playerObject = null;
            }

            if (playerObject) Debug.Log(playerObject.name);
            else Debug.Log("No GameObjects tagged 'Player'");

        }
    }

    private GameObject FindHighestLevelPlayerObject(ref GameObject[] list, GameObject gObj = null)
    {
        if (gObj)
        {
            GameObject gObjParent = gObj.transform.parent.gameObject;

            if (gObjParent.CompareTag("Player")) return FindHighestLevelPlayerObject(ref list, gObjParent);
            else return gObj;
        } else
        {
            foreach (GameObject g in list)
            {
                GameObject gParent = g.transform.parent.gameObject;

                if (gParent.CompareTag("Player")) return FindHighestLevelPlayerObject(ref list, gParent);
                else return g;
            }

            throw new Exception("List of 'Players' is null; are you sure there is a GameObject tagged 'Player'?");
        }
    }
}