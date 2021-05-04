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
        prefabType = (PrefabType)EditorGUILayout.EnumPopup("Type", prefabType);
        EditorGUILayout.Space();

        switch (prefabType)
        {
            case PrefabType.ClearShot:
                ShowClearShotInspector();
                break;
            case PrefabType.Dolly:
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
