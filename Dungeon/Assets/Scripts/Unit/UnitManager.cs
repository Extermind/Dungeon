using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;




    private void Awake()
    {
        instance = this;

        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }


    private void GameManagerOnGameStateChanged(GameState state)
    {
        // tutaj ustalamy wszystkie ify kiedy ma co sie dziać
        // np wybieranie nowego punktu odniesienia ma być włączone tylko wtedy kiedy jest player turn
        PlayerController.instance.canMakeAction = state == GameState.PLAYER_TURN? true: false;

    }

    internal void playerReset()
    {
        PlayerController.instance.reset();
    }

    internal void playerTurn()
    {
        //PlayerController.instance.turn();
    }
}
