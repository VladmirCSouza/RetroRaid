using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StagesScriptableObjects))]
public class InspectorStageBuildEditor : Editor {

    private static GUILayoutOption minButtonWidth = GUILayout.Width(30f);
    private Texture blueTexture;
    private Texture greenTexture;
    private Texture pinkTexture;
    private Texture redTexture;

    private void OnEnable()
    {
        blueTexture = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Editor/Textures/blue.png", typeof(Texture));
        greenTexture = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Editor/Textures/green.png", typeof(Texture));
        pinkTexture = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Editor/Textures/pink.png", typeof(Texture));
        redTexture = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Editor/Textures/red.png", typeof(Texture));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawInspector();
        serializedObject.ApplyModifiedProperties();
        //base.OnInspectorGUI();
    }

    private void DrawInspector()
    {
        SerializedProperty data = serializedObject.FindProperty("data").FindPropertyRelative("rows");

        for (int j = 0; j < data.arraySize; j++)
        {
            SerializedProperty row = data.GetArrayElementAtIndex(j).FindPropertyRelative("row");

            if (row.arraySize != data.arraySize)
                row.arraySize = data.arraySize;

            StagesScriptableObjects obj = (StagesScriptableObjects)target;

            EditorGUILayout.BeginHorizontal();
            for (int i = 0; i < row.arraySize; i++)
            {
                GUIContent btn;
                switch (row.GetArrayElementAtIndex(i).intValue)
                {
                    case 1:
                        btn = new GUIContent(greenTexture);
                        break;
                    case 2:
                        btn = new GUIContent(pinkTexture);
                        break;
                    case 3:
                        btn = new GUIContent(redTexture);
                        break;
                    default:
                        btn = new GUIContent(blueTexture);
                        break;
                }

                if (GUILayout.Button(btn,minButtonWidth))
                {
                    obj.SetValue(i, j, row.GetArrayElementAtIndex(i).intValue);
                    obj.ShowValue(i, j, row.GetArrayElementAtIndex(i).intValue);
                }

            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
