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
            Vector2 offset
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

            return noiseMap;
        }

        public static float GenerateNoiseValue(
            NoiseData data,
            int seed,
            Vector2 position
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

            return (noiseHeight + 1) / 2;
        }
    }
}