using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectPingPong : MonoBehaviour
{
    public RectTransform pingPongRect;

    public float lengthValue;

    public float pingPongSpeed;


	// Update is called once per frame
	void Update()
    {
        pingPongRect.anchoredPosition = new Vector2(Mathf.PingPong((Time.time * pingPongSpeed), lengthValue), pingPongRect.anchoredPosition.y);
    }
}
