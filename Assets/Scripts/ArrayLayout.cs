using UnityEngine;

[System.Serializable]
public class ArrayLayout {

    [System.Serializable]
    public struct RowData
    {
        public int[] row;
    }

    public RowData[] rows = new RowData[13]; //Grid 13 X 13
}
