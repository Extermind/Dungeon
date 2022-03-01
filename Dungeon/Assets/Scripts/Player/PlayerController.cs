using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private int actionsPointsAmount = 30;
    [SerializeField]
    private int actionsPoints;

    [SerializeField]
    private int movementCostPoints = 5;



    private PlayerActionsScript pa;
    private Vector2 movement;
    private float moveSpeed = 5f;
    [SerializeField]
    private Transform movePoint;

    private void Awake()
    {
        pa = new PlayerActionsScript();

        //read input value
        pa.player.movement.performed += x => movement = x.ReadValue<Vector2>();
        pa.player.movement.canceled += x => movement = x.ReadValue<Vector2>();
    }
    private void OnEnable()
    {
        pa.Enable();
    }
    private void OnDisable()
    {
        pa.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;

        actionsPoints = actionsPointsAmount;
    }

    // Update is called once per frame
    void Update()
    {

        //move player
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);


        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f && actionsPoints >= movementCostPoints)  
        { 
            if (Mathf.Abs(movement.x) == 1f)
            {
                movePoint.position += new Vector3((float)movement.x, 0, 0);
                actionsPoints -= movementCostPoints;
            }
            if (Mathf.Abs(movement.y) == 1f)
            {
                movePoint.position += new Vector3(0, (float)movement.y, 0);
                actionsPoints -= movementCostPoints;
            }
        }

    }
}
