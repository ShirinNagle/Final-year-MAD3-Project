using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScaleParticles : MonoBehaviour {
	void Update()
	{
#pragma warning disable CS0618 // Type or member is obsolete
        GetComponent<ParticleSystem>().startSize = transform.lossyScale.magnitude;
#pragma warning restore CS0618 // Type or member is obsolete
                              //GetComponent<ParticleSystem>().main.startSize = transform.lossyScale.magnitude;
    }
}