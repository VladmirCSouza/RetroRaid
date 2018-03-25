using UnityEngine;
using UnityEditor;
using System;

[Flags]
public enum EditorListOption
{
    None = 0,
    ListSize = 1,
    ListLabel = 2,
    ElementLabels = 4,
    Buttons = 8,
    Default = ListSize | ListLabel,
    NoElementLabes = ListSize | ListLabel,
    All = Default | Buttons
}

public class EditorList
{

    public static void Show(SerializedProperty list, EditorListOption options = EditorListOption.Default)
    {
        bool
            showlistLabel = (options & EditorListOption.ListLabel) != 0,
            showlistSize = (options & EditorListOption.ListSize) != 0;

        if (showlistLabel)
        {
            //Adiciona o nome da variavel
            EditorGUILayout.PropertyField(list);

            //Add identacao dos elementos internos da lista
            EditorGUI.indentLevel += 1;
        }

        if (!showlistLabel || list.isExpanded)
        {
            if (showlistSize)
            {
                EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
            }
            ShowElements(list, options);
        }

        if (showlistLabel)
        {
            //Remove identacao dos elementos internos da lista
            EditorGUI.indentLevel -= 1;
        }
    }

    //private static Texture btnBlue = Resources.Load("Assets/Resources/blue.png") as Texture;

    //private static GUIContent
    //    btn01 = new GUIContent("", btnBlue, "BTN Blue"),
    //    btn02 = new GUIContent("01", "My button 02"),
    //    btn03 = new GUIContent("02", "My button 03");

    private static GUILayoutOption miniButtonWidth = GUILayout.Width(20f);
    private static Texture blueText = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Editor/blue.png", typeof(Texture));
    private static Texture greenText = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Editor/green.png", typeof(Texture));

    private static void ShowElements(SerializedProperty list, EditorListOption options)
    {
        bool
            showElementsLabels = (options & EditorListOption.ElementLabels) != 0,
            showButtons = (options & EditorListOption.Buttons) != 0;

        //for (int i = 0; i < 13; i++)
        //{
        //    if(showButtons)
        //        EditorGUILayout.BeginHorizontal();

        //    for (int j = 0; j < 13; j++)
        //    {
        //        //GUIContent btn = new GUIContent(i + "," + j, "BTN");
        //        GUIContent btn = new GUIContent("0",blueText);
        //        if (GUILayout.Button(btn))
        //        {
        //            Debug.Log(btn.text);
        //            //btn.image = blueText;
        //            //GUILayout.Button(btn);
        //            btn.text = "1";
        //            //Debug.Log("Works" + i + "/" + j);
        //            Debug.Log(btn.text);
        //            Event.current.Use();
        //        }
        //    }

        //    if (showButtons)
        //        EditorGUILayout.EndHorizontal();
        //}

        //GUIContent img = new GUIContent(blueText, "teste");
        //GUILayout.Box(img);


        //GUI.DrawTexture(new Rect(0, 0, 10, 10), Resources.Load("blue.png") as Texture);

        EditorGUILayout.BeginHorizontal();
        for (int i = 0; i < list.arraySize; i++)
        {
            EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i), GUIContent.none, GUILayout.MaxWidth(20f));
        }
        EditorGUILayout.EndHorizontal();

        //ORIGINAL
        //for (int i = 0; i < list.arraySize; i++)
        //{
        //    if (showButtons)
        //        EditorGUILayout.BeginHorizontal();

        //    if (showElementsLabels)
        //        EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
        //    else
        //        EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i), GUIContent.none);

        //    if (showButtons)
        //    {
        //        ShowButtons(list, i);
        //        EditorGUILayout.EndHorizontal();
        //    }
        //}
    }

    //private static GUILayoutOption miniButtonWidth = GUILayout.Width(25f);

    private static void ShowButtons(SerializedProperty list, int index)
    {
        //btn01.text = index.ToString();
        //btn02.text = index.ToString();
        //btn03.text = index.ToString();

        //btn01.image = btnBlue;

        //if (GUILayout.Button(btn01, miniButtonWidth))
        //    btn01.text += Convert.ToInt32(btn01.text); 
        //if (GUILayout.Button(btn02, miniButtonWidth))
        //    list.MoveArrayElement(index, index + 1);
        //if (GUILayout.Button(btn03, miniButtonWidth))
        //    list.MoveArrayElement(index, index + 1);
    }
}
