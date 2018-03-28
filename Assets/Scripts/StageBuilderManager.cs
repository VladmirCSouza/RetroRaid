using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageBuilderManager : MonoBehaviour {

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
    public List<StagesScriptableObjects> currentStagesDesign;

    // Use this for initialization
    void Start () {
        foreach (var bsb in baseStageBuilder)
        {
            var stageDeisng = easyStageDesign[Random.Range(0, easyStageDesign.Length)];
            currentStagesDesign.Add(stageDeisng);
            bsb.UpdateStageDesign(stageDeisng);
        }
	}

    private void ChangeStagePosition(float zMaxPosition)
    {
        currentStagesDesign.RemoveRange(0, 4);

        for (int i = 0; i < baseStageBuilder.Length; i++)
        {
            if(currentStagesDesign.ElementAtOrDefault(i) != null)
            {
                baseStageBuilder[i].UpdateStageDesign(currentStagesDesign[i]);
            }
            else
            {
                var stageDeisng = easyStageDesign[Random.Range(0, easyStageDesign.Length)];
                currentStagesDesign.Add(stageDeisng);
                baseStageBuilder[i].UpdateStageDesign(stageDeisng);
            }
        }
    }
}