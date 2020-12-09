using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(interAction))]
public class interactoinEditor : Editor
{   
    // Start is called before the first frame update
    interAction m_traget;
    private bool _hasItem;
    [SerializeField]
    int listsize;
    SerializedObject _m;
    SerializedProperty _items;
    private void OnEnable()
    {
        m_traget = (interAction)target;
        _m = new SerializedObject(m_traget);
        _items =_m.FindProperty("items");
    }
    public override void OnInspectorGUI()
    {
        _m.Update();
        DrawDefaultInspector();


        m_traget.start = EditorGUILayout.IntField("一般對話的開始", m_traget.start);
        m_traget.end = EditorGUILayout.IntField("一般對話的結束", m_traget.end);
        _m.Update();
        _hasItem = EditorGUILayout.Toggle("有道具", m_traget.hasItem);
        m_traget.hasItem = _hasItem;
        if (_hasItem == true)
        {
            m_traget.get_start = EditorGUILayout.IntField("道具對話的開始", m_traget.get_start);
            m_traget.get_end = EditorGUILayout.IntField("道具對話的結束", m_traget.get_end);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("要給的道具項目");

            m_traget.itemnum = EditorGUILayout.IntField("幾種", m_traget.itemnum);

            _items.arraySize = m_traget.itemnum;

            if (m_traget.itemnum != _items.arraySize)
            {
                if ((m_traget.itemnum > _items.arraySize))
                {
                    _items.InsertArrayElementAtIndex(_items.arraySize);
                }
                else if ((m_traget.itemnum < _items.arraySize))
                {
                    _items.DeleteArrayElementAtIndex(_items.arraySize - 1);
                }
            }

            for (int i = 0; i < _items.arraySize; i++)
            {
                SerializedProperty itemRef = _items.GetArrayElementAtIndex(i);
                SerializedProperty _ID = itemRef.FindPropertyRelative("id");
                SerializedProperty _Count = itemRef.FindPropertyRelative("count");

                EditorGUILayout.LabelField("______________________________________________________________");
                EditorGUILayout.PropertyField(_ID);
                EditorGUILayout.PropertyField(_Count);
            }
        }        
        _m.ApplyModifiedProperties();             
    }
}
