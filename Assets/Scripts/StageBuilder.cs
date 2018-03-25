using UnityEngine;

enum StageElements
{
    Empty = 0,
    Wall = 1,
    Fuel = 2,
    Enemy = 3
}

public class StageBuilder : MonoBehaviour {

    public WallBlocksArray [] blocks;

	// Use this for initialization
	void Start () {
		
    }

    public void UpdateStageDesign(StagesScriptableObjects stageDesign)
    {
        for (int z = 0; z < 13; z++)
        {
            for (int x = 0; x < 13; x++)
            {

                switch (stageDesign.data.rows[z].row[x])
                {
                    case (int)StageElements.Empty:
                        blocks[z].blocks[x].SetActive(false);
                        break;
                    case (int)StageElements.Wall:
                        blocks[z].blocks[x].SetActive(true);
                        break;
                    case (int)StageElements.Fuel:
                        blocks[z].blocks[x].SetActive(false);
                        break;
                    case (int)StageElements.Enemy:
                        blocks[z].blocks[x].SetActive(false);
                        break;
                }
            }
        }
    }
}
