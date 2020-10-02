using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class HudView : MonoBehaviour
{
    [SerializeField] private Image lifeIconRef;
    [SerializeField] private Transform lifeCountContainer;
    [SerializeField] private Text gameOverLabel;

    void Start()
    {
        gameOverLabel.gameObject.SetActive(false);

        GameManager.OnDie += UpdateLife;
        GameManager.OnGameOver += FinishGame;

        UpdateLife();
    }

    private void UpdateLife()
    {
        Debug.Log("UpdateLife : " + GameFlow.LifeCount);

        ClearLifeCount();

        for (int i = 0; i < GameFlow.LifeCount; i++)
        {
            Instantiate(lifeIconRef, lifeCountContainer);
        }

    }

    private void ClearLifeCount()
    {
        if (lifeCountContainer == null) return;

        for (int i = 0; i < lifeCountContainer.childCount; i++)
        {
            Destroy(lifeCountContainer.GetChild(i).gameObject);
        }
    }

    private void FinishGame()
    {
        ClearLifeCount();
        gameOverLabel.gameObject.SetActive(true);
    }

    void OnDestroy()
    {
        ClearLifeCount();

        GameManager.OnDie -= UpdateLife;
        GameManager.OnGameOver -= FinishGame;
    }

}