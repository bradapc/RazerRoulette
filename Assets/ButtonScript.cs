using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject rouletteWheel;
    public HingeJoint2D rouletteWheelRB;
    private float timer = 0.0f;
    public int wheelValue = 1;
    public bool spinningRandom = false;
    public bool spinningReal = false;

    //onClick parameters
    public float currentTime = 0;
    public float randomTime = 0;
    public float timeToSpin = 0;
    public int wheelvalue = 0;
    public int generatedRotation = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rouletteWheelRB = rouletteWheel.GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        JointMotor2D motor = rouletteWheelRB.motor;
        motor.motorSpeed = 0;
        rouletteWheelRB.motor = motor;
        timer += Time.deltaTime;
        if(spinningRandom) {
            if(timer < currentTime + timeToSpin) {
                motor.motorSpeed = 400;
                rouletteWheelRB.motor = motor;
            } else {
                motor.motorSpeed = 0;
                rouletteWheelRB.motor = motor;
                currentTime = 0;
                randomTime = 0;
                timeToSpin = 0;
                timer = 0;
                spinningReal = true;
            }
        }
        if(spinningReal) {
            motor.motorSpeed = 400;
            rouletteWheelRB.motor = motor;
            int currentRotation = (int)rouletteWheel.transform.rotation.eulerAngles.z;
            if (currentRotation > generatedRotation - 9 || currentRotation < generatedRotation + 9) {
                motor.motorSpeed = 0;
                rouletteWheelRB.motor = motor;
                spinningReal = false;
            }
        }
    }

    public void onClick() {
        wheelValue = Random.Range(1, 20);
        generatedRotation = wheelValue * 18;
        currentTime = timer;
        randomTime = Random.Range(1, 3);
        timeToSpin = currentTime + randomTime;
        spinningRandom = true;
    }
}
