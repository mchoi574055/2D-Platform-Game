using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ArenaMinimap
{
    [CustomEditor(typeof(MinimapObject))]
    public class MinimapObjectEditor : Editor
    {
        public SerializedProperty
            type_state,
            sprite,
            targetTransform,
            marker,
            minimapManager,
            enableOnAwake,
            follow;

        void OnEnable()
        {
            type_state = serializedObject.FindProperty("objectType");
            sprite = serializedObject.FindProperty("markerSprite");
            targetTransform = serializedObject.FindProperty("targetTransform");
            marker = serializedObject.FindProperty("marker");
            minimapManager = serializedObject.FindProperty("minimapManager");
            enableOnAwake = serializedObject.FindProperty("enableOnAwake");
            follow = serializedObject.FindProperty("shouldFollow");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(type_state);
            TYPE _tp = (TYPE)type_state.enumValueIndex;
            if (_tp == TYPE.UNIQUE)
            {
                EditorGUILayout.PropertyField(sprite, new GUIContent("markerSprite"));
            }
            EditorGUILayout.PropertyField(targetTransform);
            EditorGUILayout.PropertyField(marker);
            EditorGUILayout.PropertyField(minimapManager);
            EditorGUILayout.PropertyField(follow);
            EditorGUILayout.PropertyField(enableOnAwake);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
