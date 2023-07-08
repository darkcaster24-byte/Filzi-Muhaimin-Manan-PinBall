using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;
    // public float springPower;
    public float targetPressed;
    public float targetRelease;


    private HingeJoint hinge;
    
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
	    MovePaddle();
    }

    private void ReadInput()
    {
        // mengambil spring dari component Hinge joint
        JointSpring jointSpring = hinge.spring;
        
        // mengubah value spring saat input ditekan dan dilepas
        if (Input.GetKey(input))
        {
            // jointSpring.spring = springPower;
            jointSpring.targetPosition = targetPressed;
        }
        else
        {
            // jointSpring.spring = 0;
            jointSpring.targetPosition = targetRelease;
        }
        
        // mengubah spring pada Hinge Joint dengan value yang sudah di ubah
        hinge.spring = jointSpring;
    }

    private void MovePaddle()
    {
        // Move Paddle Here
    }
}
