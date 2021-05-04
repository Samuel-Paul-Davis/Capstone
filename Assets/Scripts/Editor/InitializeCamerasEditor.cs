using System.Collections;
using System.Collections.Generic;
using UnityEditor;

/// <summary>
/// Redraws the InitializeCameras.cs component Inspector for usability reasons (i.e., 
/// does not display Cinemachine Clear Shot settings for dolly camera prefab)
/// </summary>
/// <remarks>
/// This type was adapted from a tutorial at <see href="https://blog.terresquall.com/2020/07/organising-your-unity-inspector-fields-with-a-dropdown-filter/">
/// Terresquall Blog</see> by Jonathan Teo.
/// </remarks>
[CustomEditor(typeof(InitializeCameras))]
public class InitializeCamerasEditor : Editor
{
    public InitializeCameras initializeCameras;

    /// <summary>
    /// Overrides virtual method defined in <see cref="UnityEditor.Editor">Editor</see>
    /// </summary>
    public override void OnInspectorGUI()
    {
        /// <summary>
        /// Gets a copy of the <see cref="InitializeCameras"/>InitializeCameras</see> instance
        /// </summary>
        initializeCameras = (InitializeCameras)target;

        /// <summary>
        /// Calls <see cref="ShowClearShotInspector"/>ShowClearShotInspector()</see> or <see cref="ShowDollyInspector"/>ShowDollyInspector</see> depending on the value of <see cref="InitializeCameras.PrefabEnum"/>PrefabEnum</see>
        /// </summary>
        switch (initializeCameras.prefabEnum)
        {
            case InitializeCameras.PrefabEnum.ClearShot:
                ShowClearShotInspector();
                break;
            case InitializeCameras.PrefabEnum.Dolly:
                ShowDollyInspector();
                break;
        }

        /// <summary>
        /// Applies changes to the Inspector
        /// </summary>
        serializedObject.ApplyModifiedProperties();
    }

    /// <summary>
    /// Displays Inspector information from struct <see cref="ClearShotInspector"/>ClearShotInspector</see>
    /// </summary>
    private void ShowClearShotInspector()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("clearShotInspector"));
    }

    /// <summary>
    /// Displays Inspector information from struct <see cref="DollyInspector"/>DollyInspector</see>
    /// </summary>
    private void ShowDollyInspector()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("dollyInspector"));
    }
}
