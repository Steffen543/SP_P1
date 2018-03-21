using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput  {

    public float Vertical { get; set; }
    public float Horizontal { get; set; }
    public bool Jump { get; set; }
    public bool Run { get; set; }
    public bool Move { get; set; }


    public bool Forward { get; set; }
    public bool Backward { get; set; }
    public bool Left { get; set; }
    public bool Right { get; set; }

    public PlayerInput()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        Jump = Input.GetKey(KeyCode.Space);
        Run = Input.GetKey(KeyCode.LeftShift);
        Forward = Input.GetKey(KeyCode.W);
        Backward = Input.GetKey(KeyCode.S);
        Left = Input.GetKey(KeyCode.A);
        Right = Input.GetKey(KeyCode.D);
        Move = Vertical != 0 || Horizontal != 0;
        //Vertical = CalcRightInput(-0.7f, 1f, Vertical);
    }


    private float CalcRightInput(float min, float max, float value)
    {
        if (value < min)
            value = min;
        if (value > max)
            value = max;
        return value;
    }
}
