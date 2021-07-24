using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ArenaMinimap
{
    [CustomEditor(typeof(MinimapManager))]
    public class MinimapManagerEditor : Editor
    {
        public SerializedProperty
           cameraTexture_prop,
            minimapLayer_prop,
            minimapCamera_prop,
            disable_prop,
            mainCamera_prop,
            allySprite_prop,
            allyDeath_prop,
            playerSprite_prop,
            playerDeath_prop,
            enemySprite_prop,
            enemyDeath_prop;

        void OnEnable()
        {
            cameraTexture_prop = serializedObject.FindProperty("cameraTexture");
            minimapLayer_prop = serializedObject.FindProperty("minimapLayer");
            minimapCamera_prop = serializedObject.FindProperty("minimapCamera");
            disable_prop = serializedObject.FindProperty("disableMinimapLayerOnMainCamera");
            mainCamera_prop = serializedObject.FindProperty("mainCamera");
            allySprite_prop = serializedObject.FindProperty("allySprite");
            allyDeath_prop = serializedObject.FindProperty("allyDeathSprite");
            playerSprite_prop = serializedObject.FindProperty("playerSprite");
            playerDeath_prop = serializedObject.FindProperty("playerDeathSprite");
            enemySprite_prop = serializedObject.FindProperty("enemySprite");
            enemyDeath_prop = serializedObject.FindProperty("enemyDeathSprite");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(cameraTexture_prop);
            EditorGUILayout.PropertyField(minimapLayer_prop);
            EditorGUILayout.PropertyField(minimapCamera_prop);
            EditorGUILayout.PropertyField(disable_prop);
            bool __disable = disable_prop.boolValue;
            if (__disable)
            {
                EditorGUILayout.PropertyField(mainCamera_prop, new GUIContent("mainCamera"));
            }
            EditorGUILayout.PropertyField(allySprite_prop);
            EditorGUILayout.PropertyField(allyDeath_prop);
            EditorGUILayout.PropertyField(playerSprite_prop);
            EditorGUILayout.PropertyField(playerDeath_prop);
            EditorGUILayout.PropertyField(enemySprite_prop);
            EditorGUILayout.PropertyField(enemyDeath_prop);
            serializedObject.ApplyModifiedProperties();
        }
    }

}
