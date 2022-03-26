using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    //Game States
    MENU,
    GENERATION,
    START,  //might delete later
    END_WIN,
    END_LOSE,
    //Player
    PLAYER_TURN,
    //Enemies
    ENEMY_TURN, 
    
};

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState gameState;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //UpdateGameState(GameState.MENU);          // change when menu will be added
        UpdateGameState(GameState.PLAYER_TURN);
    }



    public void UpdateGameState(GameState newGameState)
    {
        gameState = newGameState;

        switch (gameState)
        {
            case GameState.MENU:
                break;
            case GameState.GENERATION:
                break;
            case GameState.START:
                break;
            case GameState.END_WIN:
                break;
            case GameState.END_LOSE:
                break;
            case GameState.PLAYER_TURN:
                handlePlayerTurn();
                break;
            case GameState.ENEMY_TURN:
                break;
        }

        OnGameStateChanged?.Invoke(gameState);



    }

    private void handlePlayerTurn()
    {
        UnitManager.instance.playerReset();
        //UnitManager.instance.playerTurn();
    }
}