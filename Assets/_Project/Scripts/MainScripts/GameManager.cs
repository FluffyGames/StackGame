using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameState
    {
        NotStarted,
        Started,
        GameOver,
        Win
    }

    public GameState _gameState;

    public GameObject player;

    public int collectedDiamond = 0;
    public int totalDiamond;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        //Application.targetFrameRate = 60;

        totalDiamond = PlayerPrefs.GetInt("totalDiamond", 0);
    }

   
}