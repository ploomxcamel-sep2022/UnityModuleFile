using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 振り子動作のスクリプト
/// </summary>
public class Pendulum : MonoBehaviour
{
    public GameObject pendulumObj;

    public float pendulumRange;

    public float pendulumSpeed;

    public float pendulumValue;


    public float pendulumValueAccumulation;

    public bool switchPendulum;


    // Update is called once per frame
    void Update()
    {
        pendulumValue = pendulumSpeed * Time.deltaTime;
        pendulumValueAccumulation += pendulumValue;

        if (pendulumValueAccumulation >= pendulumRange)
        {
            switchPendulum = !switchPendulum;
            pendulumValueAccumulation = 0.0f;
        }

        if(switchPendulum)
        {
            pendulumObj.transform.localEulerAngles -= new Vector3(0.0f, pendulumValue, 0.0f);
        }
        else
        {
            pendulumObj.transform.localEulerAngles += new Vector3(0.0f, pendulumValue, 0.0f);
        }
    }
}
