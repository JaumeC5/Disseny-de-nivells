using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class controllerScript{

    public static bool AButton()
    {
        return Input.GetButtonDown("X360_A");
    }

    public static bool BButton()
    {
        return Input.GetButtonDown("X360_B");
    }

    public static bool XButton()
    {
        return Input.GetButtonDown("X360_X");
    }

    public static bool YButton()
    {
        return Input.GetButtonDown("X360_Y");
    }

    public static bool hAxisLeft()
    {
        float hAxis = Input.GetAxis("Horizontal");
        if (hAxis < -0.3)
        {
            return true;
        }
        else return false;
    }

    public static bool hAxisRight()
    {
        float hAxis = Input.GetAxis("Horizontal");
        if (hAxis > 0.3)
        {
            return true;
        }
        else return false;
    }

    public static bool hAxisDown()
    {
        float vAxis = Input.GetAxis("Vertical");
        if (vAxis < -0.3)
        {
            return true;
        }
        else return false;
    }

    public static bool hAxisUp()
    {
        float vAxis = Input.GetAxis("Vertical");
        if (vAxis > 0.3)
        {
            return true;
        }
        else return false;
    }

    public static bool StartButton()
    {
        return Input.GetButtonDown("X360_Start");
    }

    public static bool BackButton()
    {
        return Input.GetButtonDown("X360_Back");
    }

}
