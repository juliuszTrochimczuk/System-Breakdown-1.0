/*using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(G_Controller))]
public class Development_only : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();

        if (GUILayout.Button("Reset all PlayerPrefs"))
            PlayerPrefs.DeleteAll();

        if(GUILayout.Button("Reset player money and skill points"))
        {
            G_Controller.instatnce.PlayerMoney.Scrap = 0;
            G_Controller.instatnce.PlayerExperience.SkillPoints = 0;
        }

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Add some money"))
            G_Controller.instatnce.PlayerMoney.Scrap += 1000;
        if (GUILayout.Button("Add some skill points"))
            G_Controller.instatnce.PlayerExperience.SkillPoints += 10;

        GUILayout.EndHorizontal();
    }
}*/