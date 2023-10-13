using UnityEngine;

namespace TheRealIronDuck.Runtime.Noise.Data
{
    [CreateAssetMenu(fileName = "Noise", menuName = "TheRealIronDuck/Noise", order = 0)]
    public class NoiseSo : ScriptableObject
    {
        public NoiseData noiseData;

        [Header("Debug Preview")] public int previewSeed = 0;
        public Vector2 previewOffset = Vector2.zero;
        public bool previewHideFalloff;
    }
}