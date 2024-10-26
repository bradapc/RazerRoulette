using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject rouletteWheel;
    public GameObject logicHandler;
    public HingeJoint2D rouletteWheelRB;
    private float timer = 0.0f;
    public int wheelValue = 1;
    public bool spinningRandom = false;
    public bool spinningReal = false;
    public bool isPlayerTurn = true;
    public bool passPlayerTurn = true;

    //onClick parameters
    public float currentTime = 0;
    public float randomTime = 0;
    public float timeToSpin = 0;
    public int wheelvalue = 0;
    public int generatedRotation = 0;

    public float countdownTime = 3f;
    private float spinRandomTimer = 0f;
    public bool spinnerActivated = false;

    JointMotor2D motor;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rouletteWheelRB = rouletteWheel.GetComponent<HingeJoint2D>();
        motor = rouletteWheelRB.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if(spinnerActivated){
            motor.motorSpeed = 400;
            rouletteWheelRB.motor = motor;
            if(spinRandomTimer > 0){
                spinRandomTimer -= Time.deltaTime;
                spinRandomTimer = Mathf.Clamp(spinRandomTimer, 0, countdownTime);
            }
            else{
                int currentRotation = (int)rouletteWheel.transform.rotation.eulerAngles.z;
                if (currentRotation > generatedRotation - 15 || currentRotation < generatedRotation + 15) {
                    motor.motorSpeed = 0;
                    rouletteWheelRB.motor = motor;
                    //passPlayerTurn is used to apply the change to player vs enemy (true for player)
                    logicHandler.GetComponent<WheelScript>().handleTurnEnd(wheelValue, passPlayerTurn);
                    passPlayerTurn = false;
                    spinningReal = false;
                }
            }
        }
    }

    public void doPlayerTurn() {
        isPlayerTurn = false;
        passPlayerTurn = true;
        wheelValue = Random.Range(1, 12);
        generatedRotation = wheelValue* (360 / 12);
        countdownTime = Random.Range(1, 3);
        spinRandomTimer = countdownTime;
        spinnerActivated = true;
    }

    public void doEnemyTurn() {

    }

    public void onClick() {
        if (isPlayerTurn) {
            doPlayerTurn();
        }
    }
}