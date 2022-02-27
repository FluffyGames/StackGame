using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject gamePanel,mainPanel, gameOverPanel, winPanel;

    [Header("Level Area")]
    public TextMeshProUGUI currentLevelText;
    //public TextMeshProUGUI nextLevelText;


    [Header("Diamond Area")]
    public TextMeshProUGUI collectedDiamondText;
    //public TextMeshProUGUI totalDiamondTextOnWinPanel;

    private void Awake()
    {
        if (!instance) { instance = this; }
    }

    public void RestartTheScene()
    {
        //MMVibrationManager.Haptic(HapticTypes.Selection);

        DOTween.KillAll();
        if (LevelManager.instance.loadSceneTypeIsScene) // sahne sahne yukleme aktif
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
        }
        else // sahne sahne yukleme deaktif
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    public void OpenWinPanel()
    {
        winPanel.SetActive(true);
        winPanel.GetComponent<CanvasGroup>().alpha = 0;
        winPanel.GetComponent<CanvasGroup>().DOFade(1f, 1f);
    }

    public void OpenGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        gameOverPanel.GetComponent<CanvasGroup>().alpha = 0;
        gameOverPanel.GetComponent<CanvasGroup>().DOFade(1f, 1f);
    }

    public void PlayArea()
    {
        mainPanel.SetActive(false);
        GameManager.instance._gameState = GameManager.GameState.Started;
    }


    // CHECKPOINT SYSTEM WHICH WORKING WITH CHECKPOINT, LEVELMANAGER, LEVELSETTINGS AND UIMANAGER SCRIPTS
    #region CHECKPOINT SYSTEM (INSTANTIATE AND UPDATE STAR)

    /*
    public GameObject checkpointStarPrefab;
    public Sprite checkpointStarPassedSprite;

    public void CreateCheckpointStar(float ratio)
    {
        GameObject star = Instantiate(checkpointStarPrefab);
        star.transform.SetParent(levelProgressBar.transform, false);

        var change = levelProgressBar.rectTransform.rect.xMax - levelProgressBar.rectTransform.rect.xMin;
        var lastXPos = levelProgressBar.rectTransform.rect.xMin + (change * ratio);

        star.GetComponent<RectTransform>().localPosition = new Vector2(lastXPos, 35f);
    }

    public void UpdateCheckpointStar(int whichCheckpoint)
    {
        levelProgressBar.transform.GetChild(whichCheckpoint).GetComponent<Image>().sprite = checkpointStarPassedSprite;
    }
    */

    #endregion

    public void UpdateCollectedDiamondText(int amount) //DIAMOND OR COIN
    {
        collectedDiamondText.text = amount.ToString();
    }

    int srDebuggerCount; bool srResetBool;
    public void OpenSrDebugger()
    {
        srDebuggerCount++;
        if(srDebuggerCount>=3)
        {
            CancelInvoke("SrDebuggerReset");
            //SRDebug.Instance.ShowDebugPanel(); hata veriyor
            SrDebuggerReset();
        }

        if (!srResetBool)
        {
            srResetBool = true;
            Invoke("SrDebuggerReset", 3);
        }
    }

    void SrDebuggerReset()
    {
        srResetBool = false;
        srDebuggerCount = 0;
    }
}