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

    public void UpdateStageDesign(StagesScriptableObjects stageDesign)
    {
        for (int z = 0; z < 13; z++)
        {
            for (int x = 0; x < 13; x++)
            {
                int value = 0;
                switch (stageDesign.data.rows[z].row[x])
                {
                    case (int)StageElements.Empty:
                        blocks[z].blocks[x].SetActive(false);
                        value = 0;
                        break;
                    case (int)StageElements.Wall:
                        blocks[z].blocks[x].SetActive(true);
                        value = 1;
                        break;
                    case (int)StageElements.Fuel:
                        float rnd = Random.Range(0f, 100f) / 100f;
                        //Debug.Log(rnd);
                        if (rnd < 0.75f)
                        {
                            Vector3 newPosition = new Vector3(blocks[z].blocks[x].transform.position.x, 0f, blocks[z].blocks[x].transform.position.z);
                            ObjectsPoolerController.Instance.SpawnFromPool("FuelTank", newPosition, blocks[z].blocks[x].transform.rotation);
                            value = 2;
                        }
                        else
                        {
                            value = 0;
                        }
                        blocks[z].blocks[x].SetActive(false);
                        break;
                    case (int)StageElements.Enemy:
                        blocks[z].blocks[x].SetActive(false);
                        value = 3;
                        break;
                }
            }
        }
    }
}
