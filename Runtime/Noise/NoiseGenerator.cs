using TheRealIronDuck.Runtime.Noise.Data;
using UnityEngine;
using Unity.Mathematics;

namespace TheRealIronDuck.Runtime.Noise
{
    public static class NoiseGenerator
    {
        public static float[,] GenerateNoiseMap(
            NoiseData data,
            int seed,
            Vector2 offset,
            bool enableFalloff = true
        )
        {
            var noiseMap = new float[data.size, data.size];
            var random = new System.Random(seed);

            var octaveOffsets = new Vector2[data.octaves];
            for (var i = 0; i < data.octaves; i++)
            {
                var offsetX = (offset.x + random.Next(-100000, 100000)) * 0.1f;
                var offsetY = (offset.y + random.Next(-100000, 100000)) * 0.1f;
                octaveOffsets[i] = new Vector2(offsetX, offsetY);
            }

            for (var y = 0; y < data.size; y++)
            {
                for (var x = 0; x < data.size; x++)
                {
                    var amplitude = 1f;
                    var frequency = 1f;
                    var noiseHeight = 0f;

                    for (var i = 0; i < data.octaves; i++)
                    {
                        var sampleX = (x + offset.x + octaveOffsets[i].x) * data.scale * frequency;
                        var sampleY = (y + offset.y + octaveOffsets[i].y) * data.scale * frequency;

                        var simplexValue = noise.snoise(new float2(sampleX, sampleY));
                        noiseHeight += simplexValue * amplitude;

                        amplitude *= data.persistence;
                        frequency *= data.lacunarity;
                    }

                    noiseMap[x, y] = (noiseHeight + 1) / 2;
                }
            }

            if (!enableFalloff)
            {
                return noiseMap;
            }

            var centerX = data.size / 2f - offset.x;
            var centerY = data.size / 2f - offset.y;
            for (var y = 0; y < data.size; y++)
            {
                for (var x = 0; x < data.size; x++)
                {
                    var distance = Mathf.Sqrt(Mathf.Pow(x - centerX, 2) + Mathf.Pow(y - centerY, 2));
                    var normalizedDistance = Mathf.Clamp01(distance / data.falloffRange);
                    var falloff = 1 - Mathf.Pow(normalizedDistance, 2);

                    if (distance < data.falloffRange)
                    {
                        noiseMap[x, y] = Mathf.Clamp01(noiseMap[x, y] + falloff);
                    }
                }
            }

            return noiseMap;
        }

        public static float GenerateNoiseValue(
            NoiseData data,
            int seed,
            Vector2 position,
            bool enableFalloff = true
        )
        {
            var random = new System.Random(seed);

            var octaveOffsets = new Vector2[data.octaves];
            for (var i = 0; i < data.octaves; i++)
            {
                var offsetX = (position.x + random.Next(-100000, 100000)) * 0.1f;
                var offsetY = (position.y + random.Next(-100000, 100000)) * 0.1f;
                octaveOffsets[i] = new Vector2(offsetX, offsetY);
            }

            var amplitude = 1f;
            var frequency = 1f;
            var noiseHeight = 0f;

            for (var i = 0; i < data.octaves; i++)
            {
                var sampleX = (position.x + octaveOffsets[i].x) * data.scale * frequency;
                var sampleY = (position.y + octaveOffsets[i].y) * data.scale * frequency;

                var simplexValue = noise.snoise(new float2(sampleX, sampleY));
                noiseHeight += simplexValue * amplitude;

                amplitude *= data.persistence;
                frequency *= data.lacunarity;
            }

            var noiseValue = (noiseHeight + 1) / 2;
            
            if (!enableFalloff)
            {
                return noiseValue;
            }

            var centerX = data.size / 2f - position.x;
            var centerY = data.size / 2f - position.y;
            var distance = Mathf.Sqrt(Mathf.Pow(centerX, 2) + Mathf.Pow(centerY, 2));
            var normalizedDistance = Mathf.Clamp01(distance / data.falloffRange);
            var falloff = 1 - Mathf.Pow(normalizedDistance, 2);

            if (distance < data.falloffRange)
            {
                noiseValue = Mathf.Clamp01(noiseValue + falloff);
            }
             
            return noiseValue;
        }
    }
}