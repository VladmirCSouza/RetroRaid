using UnityEngine;
using UnityEditor;

//[CustomPropertyDrawer(typeof(ArrayLayout))]
public class CustPropertyDrawer : PropertyDrawer{

    private static Texture blueText = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Editor/blue.png", typeof(Texture));
    private static Texture greenText = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Editor/green.png", typeof(Texture));

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {        
        EditorGUI.PrefixLabel(position, label);
        Rect newPosition = position;
        SerializedProperty data = property.FindPropertyRelative("rows");

        for (int j = 0; j < data.arraySize; j++)
        {
            newPosition.y += 20f;

            SerializedProperty row = data.GetArrayElementAtIndex(j).FindPropertyRelative("row");
            newPosition.height = 20f;
            if (row.arraySize != data.arraySize)
                row.arraySize = data.arraySize;

            newPosition.width = position.width / row.arraySize;

            for (int i = 0; i < row.arraySize; i++)
            {
                EditorGUI.PropertyField(newPosition, row.GetArrayElementAtIndex(i), GUIContent.none);
                newPosition.x += newPosition.width;
            }

            newPosition.x = position.x;
        }
    }
}
