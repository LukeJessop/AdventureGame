using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem), typeof(Collider))]
public class TriggerParticleEffect : MonoBehaviour
{
    private ParticleSystem particles;
    public int firstEmissionAmount = 10;
    public int secondEmissionAmount = 20;
    public int thirdEmissionAmount = 30;
    public float delayBetweenEmissions = 0.5f;
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>())
        {
            StartCoroutine(EmitParticlesCoroutine());
        }
    }

    private IEnumerator EmitParticlesCoroutine()
    {
        particles.Emit(firstEmissionAmount);
        yield return new WaitForSeconds(delayBetweenEmissions);
        
        particles.Emit(secondEmissionAmount);
        yield return new WaitForSeconds(delayBetweenEmissions);
        
        particles.Emit(thirdEmissionAmount);
    }
}
