using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MainMenu))]
public class MainMenuEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MainMenu menu = (MainMenu)target;

        if (GUILayout.Button("FadeOut"))
        {
            menu.FadeMainMenu(true);
        }
        if (GUILayout.Button("FadeIn"))
        {
            menu.FadeMainMenu(false);
        }
    }
}
