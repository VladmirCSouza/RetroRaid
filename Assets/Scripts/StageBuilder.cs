using UnityEngine;

public enum StageElements
{
    Empty = 0,
    Wall = 1,
    Fuel = 2,
    Enemy = 3
}

public class StageBuilder : MonoBehaviour {

    public WallBlocksArray [] blocks;

    public GameObject checkpoint;
    public GameObject start;

    public void UpdateStageDesign(int x, int z, int stageElement)
    {
        switch (stageElement)
        {
            case (int)StageElements.Empty: //0
                blocks[z].blocks[x].SetActive(false);
                break;
            case (int)StageElements.Wall: //1
                blocks[z].blocks[x].SetActive(true);
                break;
            case (int)StageElements.Fuel: //2
                Vector3 newFuelTankPosition = new Vector3(blocks[z].blocks[x].transform.position.x, 0f, blocks[z].blocks[x].transform.position.z);
                ObjectsPoolerController.Instance.SpawnFromPool("FuelTank", newFuelTankPosition, blocks[z].blocks[x].transform.rotation);
                blocks[z].blocks[x].SetActive(false);
                break;
            case (int)StageElements.Enemy: //3
                //Vector3 newEnemyPosition = new Vector3(blocks[z].blocks[x].transform.position.x, 0f, blocks[z].blocks[x].transform.position.z);
                //ObjectsPoolerController.Instance.SpawnFromPool("Boat", newEnemyPosition, blocks[z].blocks[x].transform.rotation);
                //blocks[z].blocks[x].SetActive(false);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 28/03/2018 - Vladmir C. Souza
    /// Old implemantation, this way the enemies and fuel doens't follow the scene
    /// </summary>
    //public void UpdateStageDesign(StagesScriptableObjects stageDesign)
    //{
    //    for (int z = 0; z < 13; z++)
    //    {
    //        for (int x = 0; x < 13; x++)
    //        {
    //            switch (stageDesign.data.rows[z].row[x])
    //            {
    //                case (int)StageElements.Empty:
    //                    blocks[z].blocks[x].SetActive(false);
    //                    break;
    //                case (int)StageElements.Wall:
    //                    blocks[z].blocks[x].SetActive(true);
    //                    break;
    //                case (int)StageElements.Fuel:
    //                    float rnd = Random.Range(0f, 100f) / 100f;
    //                    //Debug.Log(rnd);
    //                    if (rnd < 0.75f)
    //                    {
    //                        Vector3 newPosition = new Vector3(blocks[z].blocks[x].transform.position.x, 0f, blocks[z].blocks[x].transform.position.z);
    //                        ObjectsPoolerController.Instance.SpawnFromPool("FuelTank", newPosition, blocks[z].blocks[x].transform.rotation);
    //                    }
    //                    blocks[z].blocks[x].SetActive(false);
    //                    break;
    //                case (int)StageElements.Enemy:
    //                    blocks[z].blocks[x].SetActive(false);
    //                    break;
    //            }
    //        }
    //    }
    //}
}
