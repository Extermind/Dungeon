using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField]
    private int actionPointsCount = 30;
    [SerializeField]
    private int actionMoveCost = 5;
    [SerializeField]
    private int curActionPoints = 0;

    public bool canMakeAction;


    private Transform movePoint;
    private Vector3 choosedDirection;
    
    



    private void Awake()
    {
        instance = this;
    }

    public void reset()
    {
        curActionPoints = actionPointsCount;
    }







    //public int getCurreetActionPoints()
    //{
    //    return curActionPoints;
    //}

    //public int getAcionMoveCost()
    //{
    //    return actionMoveCost;
    //}


    public void makeTurn()
    {
        if (canMakeAction)
        {
            if(curActionPoints >= actionMoveCost)
            {
                //coś robi
                //poruszanie sie




                //i ustawia ten sam stan
                GameManager.instance.UpdateGameState(GameState.PLAYER_TURN);
            }
            else
            {
                //jesli nie może wykonac juz ruchu to kolej przeciwnika
                GameManager.instance.UpdateGameState(GameState.ENEMY_TURN);
            }
        }
    }
}
