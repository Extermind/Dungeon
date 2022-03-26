using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private int actionsPointsAmount = 30;
    [SerializeField]
    private int actionsPoints = 0;

    public double ActionPoints
    {
        get { return actionsPoints; }
    }

    void turn()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
