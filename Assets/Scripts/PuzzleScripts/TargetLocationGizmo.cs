using UnityEngine;

//TODO: Fix
[ExecuteInEditMode, RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]
public class TargetLocationGizmo : MonoBehaviour
{
#if UNITY_EDITOR
    private void Update()
    {
        if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
        { 
            
        }
    }
#endif
}