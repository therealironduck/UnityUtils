using UnityEngine;

namespace TheRealIronDuck.Runtime.Noise.Data
{
    [CreateAssetMenu(fileName = "Noise", menuName = "TheRealIronDuck/Noise", order = 0)]
    public class NoiseSo : ScriptableObject
    {
        public NoiseData noiseData;
    }
}