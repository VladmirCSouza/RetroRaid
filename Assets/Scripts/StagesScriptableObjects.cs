using UnityEngine;

[CreateAssetMenu(fileName = "StageDesign - Difficulty - Number", menuName = "Retro Raid/New Stage Design", order = 1)]
public class StagesScriptableObjects : ScriptableObject
{

    //public int[] teste;

    public ArrayLayout data;

    //private int[,] stageBase = new int[13,13];


    public void ShowValue(int row, int column, int value)
    {
        //stageBase[row, column] = value;
        //Debug.Log("row: " + row + " / Col: " + column + " / Value: " + stageBase[row, column]);
        Debug.Log(data.rows[column].row[row]);
    }

    /// <summary>
    /// Configura valores no array que gera o cenário
    /// </summary>
    /// <param name="row"></param>
    /// <param name="column"></param>
    /// <param name="value"> 0 = River / 1 = Block / 2 = Fuel Spawn Point / 3 = Enemy Spawn Point</param>
    public void SetValue(int row, int column, int value)
    {
        if (value == 3)
            value = 0;
        else
            value++;

        data.rows[column].row[row] = value;
    }

    //public int[,] GetStage()
    //{
    //    return stageBase;
    //}
}
