using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(InitializeCameras))]
public class InitializeCamerasEditor : Editor
{
    public InitializeCameras initializeCameras;

    public override void OnInspectorGUI()
    {
        //prefabType = (PrefabType)EditorGUILayout.EnumPopup("Type", prefabType);
        //EditorGUILayout.Space();

        initializeCameras = (InitializeCameras)target;

        switch (initializeCameras.prefabEnum)
        {
            case InitializeCameras.PrefabEnum.ClearShot:
                ShowClearShotInspector();
                break;
            case InitializeCameras.PrefabEnum.Dolly:
                ShowDollyInspector();
                break;
        }

        //base.OnInspectorGUI();

        serializedObject.ApplyModifiedProperties();
    }

    private void ShowClearShotInspector()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("clearShotInspector"));
    }

    private void ShowDollyInspector()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("dollyInspector"));
    }
}
