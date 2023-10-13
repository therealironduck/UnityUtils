using System;
using UnityEngine;

namespace TheRealIronDuck.Runtime.Noise.Data
{
    [Serializable]
    public class NoiseData : ICloneable 
    {
        [SerializeField] [Min(1)] public int size = 100;
        [SerializeField] [Min(.0001f)] public float scale = .01f;
        [SerializeField] [Min(1)] public int octaves = 4;
        [SerializeField] [Range(0f, 1f)] public float persistence = .5f;
        [SerializeField] [Min(1)] public float lacunarity = 2f;
        [SerializeField] public int falloffRange;

        public object Clone()
        {
            return new NoiseData
            {
                size = size,
                scale = scale,
                octaves = octaves,
                persistence = persistence,
                lacunarity = lacunarity,
                falloffRange = falloffRange
            };
        }
    }
}