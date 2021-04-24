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
                    playerObject = FindPlayerObject(ref gameObjects);
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

    private GameObject FindPlayerObject(ref GameObject[] gArr, GameObject gObj = null)
    {
        if (gObj)
        {
            GameObject gObjParent;

            if (gObj.transform != gObj.transform.root) gObjParent = gObj.transform.parent.gameObject;
            else gObjParent = null; //throw new Exception("'Player' GameObject not found!");

            if (gObj.GetComponent<CharacterController>() || !gObjParent) return gObj; //BUG: leaving here when child has CharacterController
            else if (gObjParent && gObjParent.CompareTag("Player")) return FindPlayerObject(ref gArr, gObjParent);
            else throw new Exception("'Player' GameObject not found!"); //return gObj;
        } else
        {
            //foreach (GameObject g in list)
            for (int i = gArr.Length - 1; i >= 0; i--)
            {
                GameObject gParent;

                if (gArr[i].transform != gArr[i].transform.root) gParent = gArr[i].transform.parent.gameObject;
                else gParent = null; //throw new Exception("'Player' GameObject not found!");

                if (gArr[i].GetComponent<CharacterController>() || !gParent) return gArr[i]; //BUG: leaving here when child has CharacterController
                else if (gParent && gParent.CompareTag("Player")) return FindPlayerObject(ref gArr, gParent);
                else throw new Exception("'Player' GameObject not found!"); //return g;
            }

            throw new Exception("List of 'Players' is null; are you sure there is a GameObject tagged 'Player'?");
        }
    }
}