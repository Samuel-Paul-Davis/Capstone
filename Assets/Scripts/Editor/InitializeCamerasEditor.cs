using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(InitializeCameras))]
public class InitializeCamerasEditor : Editor
{
    public enum PrefabType { ClearShot, Dolly }

    public PrefabType prefabType;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.ApplyModifiedProperties();
    }
}
