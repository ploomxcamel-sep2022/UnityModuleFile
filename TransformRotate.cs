using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトをRotateで回転させる<br/>
/// 算術オーバーフローに注意<br/>
/// </summary>
public class TransformRotate : MonoBehaviour
{
    public GameObject rotateObj;

    public float rotationSpeed;

    public Vector3 rotateVector;


    // Update is called once per frame
    void Update()
    {
        rotateObj.transform.Rotate((rotateVector * rotationSpeed) * Time.deltaTime);
    }
}
