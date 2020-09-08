// Shows a label in the editor with the seconds since the editor started

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExampleEditorWindow : EditorWindow
{
    #region Singleton
    public static ExampleEditorWindow Instance
    {
        get { return GetWindow< ExampleEditorWindow >(); }
    }
    #endregion
    
    [MenuItem("Examples/Editor GUILayout Label Usage")]
    static void Init()
    {
        ExampleEditorWindow window = (ExampleEditorWindow)EditorWindow.GetWindow(typeof(ExampleEditorWindow), true, "My Empty Window");
        window.Show();
    }

    void OnGUI()
    {
        //EditorGUILayout.LabelField("test" + GameManager.Instance.debugVars[0]);

        foreach (var VARIABLE in DebugManager.Instance.debugVars)
        {
            EditorGUILayout.LabelField(VARIABLE);
        }

        this.Repaint();

    }
}