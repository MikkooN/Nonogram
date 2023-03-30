using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nonogram
{
    public class ParticleEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem burnEffect;

        public void PlayParticle()
        {
            burnEffect.Play();
        }
    }
}
