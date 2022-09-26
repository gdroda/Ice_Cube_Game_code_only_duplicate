using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(SceneChange))]
public class DeleteSaveFileInspector : Editor
{
    public override void OnInspectorGUI()
    {
        string path = Application.persistentDataPath + "/save.ice";
        base.OnInspectorGUI();
        if (GUILayout.Button("Delete Save File", GUILayout.Height(40)))
        {
            File.Delete(path);
        }
    }
}
#endif
