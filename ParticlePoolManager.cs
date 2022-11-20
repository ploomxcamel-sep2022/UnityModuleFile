using System.Collections;
using System.Collections.Generic;
using Coffee.UIExtensions;
using UnityEngine;

public class ParticlePoolManager : MonoBehaviour
{
    public UIParticleAttractor attractor;

    public int currentIndex;

    public ParticleSystem[] particles;


    public void PoolingPS_Play()
	{
        particles[currentIndex].Play();
        currentIndex++;
        if(currentIndex >= particles.Length)
		{
            currentIndex = 0;
        }
	}
    
}
