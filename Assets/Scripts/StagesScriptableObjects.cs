using UnityEngine;

[CreateAssetMenu(fileName = "StageDesign - Difficulty - Number", menuName = "Retro Raid/New Stage Design", order = 1)]
public class StagesScriptableObjects : ScriptableObject
{

    public ArrayLayout data;

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
