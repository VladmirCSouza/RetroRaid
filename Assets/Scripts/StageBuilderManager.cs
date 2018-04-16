using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class StageBuilderManager : MonoBehaviour {

    private float spawnFuelPercent = 0.5f;

    private void OnEnable()
    {
        GameManager.OnPlayerReachLimit += ChangeStagePosition;
    }

    private void OnDisable()
    {
        GameManager.OnPlayerReachLimit -= ChangeStagePosition;
    }

    public StageBuilder[] baseStageBuilder;
    public StagesScriptableObjects[] easyStageDesign;
    public StagesScriptableObjects[] mediumStageDesign;
    public StagesScriptableObjects[] hardStageDesign;
    //public List<StagesScriptableObjects> currentStagesDesign;
    //private StagesScriptableObjects[] currentStagesDesign = new StagesScriptableObjects[6];

    public ArrayLayout[] currentStageConfig = new ArrayLayout[6];

    // Use this for initialization
    void Start () {

        baseStageBuilder[0].start.SetActive(true);

        for (int i = 1; i < baseStageBuilder.Length; i++)
        {
            var stageDeisgn = easyStageDesign[UnityEngine.Random.Range(0, easyStageDesign.Length)];
            //currentStagesDesign.Add(stageDeisgn);
            //currentStagesDesign[i] = stageDeisgn;
            //currentStageConfig[i] = stageDeisgn.data;
            //bsb.UpdateStageDesign(stageDeisgn);

            for (int z = 0; z < 13; z++)
            {
                currentStageConfig[i].rows[z].row = new int[13];
                for (int x = 0; x < 13; x++)
                {
                    int value = stageDeisgn.data.rows[z].row[x];

                    if (value == (int)StageElements.Fuel)
                    {
                        float rnd = UnityEngine.Random.Range(0f, 100f) / 100f;
                        if (rnd > spawnFuelPercent)
                            value = (int)StageElements.Empty;
                    }

                    baseStageBuilder[i].UpdateStageDesign(x, z, value);
                    currentStageConfig[i].rows[z].row[x] = value;
                }
            }
        }
    }

    /// <summary>
    /// This entire function works based on "God only knows"
    /// Try to make a better code or leave as it is.
    /// </summary>
    /// <param name="zMaxPosition"></param>
    private void ChangeStagePosition(float zMaxPosition)
    {
        baseStageBuilder[0].start.SetActive(false);

        //currentStagesDesign.RemoveRange(0, 4);

        #region POG do Capeta
        ArrayLayout lastButOne = currentStageConfig[4];
        ArrayLayout last = currentStageConfig[5];
        //Array.Clear(currentStageConfig, 0, currentStageConfig.Length);

        currentStageConfig[0] = lastButOne;
        currentStageConfig[1] = last;
        #endregion
        //currentStageConfig.RemoveRange(0, 4);

        for (int i = 0; i < baseStageBuilder.Length; i++)
        {
            //if(currentStagesDesign.ElementAtOrDefault(i) != null)
            if(i < 2)
            {
                for (int z = 0; z < 13; z++)
                {
                    for (int x = 0; x < 13; x++)
                    {
                        baseStageBuilder[i].UpdateStageDesign(x, z, currentStageConfig[i].rows[z].row[x]);
                    }
                }
            }
            else
            {
                //var stageDeisng = easyStageDesign[Random.Range(0, easyStageDesign.Length)];
                //currentStagesDesign.Add(stageDeisng);
                //baseStageBuilder[i].UpdateStageDesign(stageDeisng);

                var stageDeisgn = easyStageDesign[UnityEngine.Random.Range(0, easyStageDesign.Length)];
                //currentStagesDesign.Add(stageDeisgn);
                //currentStageConfig[i] = stageDeisgn.data;
                //currentStageConfig.Add(stageDeisgn.data);

                for (int z = 0; z < 13; z++)
                {
                    for (int x = 0; x < 13; x++)
                    {
                        int value = stageDeisgn.data.rows[z].row[x];

                        if (value == (int)StageElements.Fuel)
                        {
                            float rnd = UnityEngine.Random.Range(0f, 100f) / 100f;
                            if (rnd > spawnFuelPercent)
                                value = (int)StageElements.Empty;
                        }

                        baseStageBuilder[i].UpdateStageDesign(x, z, value);
                        //currentStageConfig[i].rows[z].row = new int[13];
                        currentStageConfig[i].rows[z].row[x] = value;
                    }
                }
            }
        }
    }
}