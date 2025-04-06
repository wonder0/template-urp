using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(AudioManager))]
public class AudioManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Apply Default Volume Settings"))
        {
            var audioManager = (AudioManager)target;
            audioManager.SendMessage("ApplyVolumeSettings");
        }
    }
}