using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public GameObject levelsParent;
    [Header("Levelleri yukleme tipi scene uzerine mi ?")]
    public bool loadSceneTypeIsScene;
    [HideInInspector] public int currentLevel;
    [HideInInspector] public static int checkpoint = -1; //CHECKPOINT SYSTEM

    // LEVEL PROGRESS BAR
    //[HideInInspector] public Vector3 currentLevelFinishArea;
    //[HideInInspector] public float currentLevelLength;

    [BoxGroup("Level Test Settings")] public bool testMode;
    [BoxGroup("Level Test Settings")] public int testLevel;

    private void Awake()
    {
        if (!instance)
            instance = this;

        currentLevel = PlayerPrefs.GetInt("currentLevel", 0);

#if UNITY_EDITOR
        if (testMode)
            currentLevel = testLevel - 1;
#endif

        if(!loadSceneTypeIsScene)
        {
            for (int i = 0; i < levelsParent.transform.childCount; i++)
                levelsParent.transform.GetChild(i).gameObject.SetActive(false);

            levelsParent.transform.GetChild(currentLevel).gameObject.SetActive(true);
        }
        
    }

    private void Start()
    {
        int currentLevelText = PlayerPrefs.GetInt("currentLevelText", 0);
        UIManager.instance.currentLevelText.text = "Level " + (currentLevelText + 1).ToString();
        //UIManager.Instance.nextLevelText.text = (currentLevelText + 2).ToString();

        var levelSettings = levelsParent.transform.GetChild(currentLevel).GetComponent<LevelSettings>();
        LevelCompleted();
        
    }



    [Button, BoxGroup("Level Test Settings")]
    public void GameOver()
    {
        if (GameManager.instance._gameState == GameManager.GameState.Started)
        {
            GameManager.instance._gameState = GameManager.GameState.GameOver;

            //---MMVibrationManager.Haptic(HapticTypes.Failure);

            //SDK
            //--GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, currentLevel.ToString());

            UIManager.instance.OpenGameOverPanel();
        }
    }

    [Button, BoxGroup("Level Test Settings")]
    public void LevelCompleted()
    {
        if (GameManager.instance._gameState == GameManager.GameState.Started)
        {
            GameManager.instance._gameState = GameManager.GameState.Win;

            //---MMVibrationManager.Haptic(HapticTypes.Success);

            //SDK
            //---GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, currentLevel.ToString());
            if(loadSceneTypeIsScene)
            {
                if (currentLevel != SceneManager.sceneCountInBuildSettings - 1)
                    currentLevel += 1;
                else
                    currentLevel = 1;
            }
            else
            {
                if (currentLevel != levelsParent.transform.childCount - 1)
                    currentLevel += 1;
                else
                    currentLevel = 0;
            }
           

            if (!testMode)
            {

                PlayerPrefs.SetInt("currentLevel", currentLevel);
                PlayerPrefs.SetInt("currentLevelText", PlayerPrefs.GetInt("currentLevelText") + 1);

            }

            UIManager.instance.OpenWinPanel();
        }
    }

}