using TheRealIronDuck.Runtime.Noise.Data;
using UnityEngine;

namespace TheRealIronDuck.Runtime.Noise
{
    public static class NoiseGenerator
    {
        public static float[,] GenerateNoiseMap(
            NoiseData noise,
            int seed,
            Vector2 offset
        )
        {
            var random = new System.Random(seed);
            var octaveOffsets = new Vector2[noise.octaves];
            for (var i = 0; i < noise.octaves; i++)
            {
                octaveOffsets[i] = new Vector2(
                    random.Next(-100000, 100000) + offset.x,
                    random.Next(-100000, 100000) + offset.y
                );
            }

            var halfWidth = noise.size / 2f;
            var halfHeight = noise.size / 2f;

            var noiseMap = new float[noise.size, noise.size];
            var scale = noise.scale;
            if (scale <= 0)
            {
                scale = 0.0001f;
            }

            var maxNoiseHeight = float.MinValue;
            var minNoiseHeight = float.MaxValue;

            for (var y = 0; y < noise.size; y++)
            {
                for (var x = 0; x < noise.size; x++)
                {
                    var amplitude = 1f;
                    var frequency = 1f;
                    var noiseHeight = 0f;

                    for (var i = 0; i < noise.octaves; i++)
                    {
                        var sampleX = (x-halfWidth) / scale * frequency + octaveOffsets[i].x;
                        var sampleY = (y-halfHeight) / scale * frequency + octaveOffsets[i].y;

                        var perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                        noiseHeight += perlinValue * amplitude;

                        amplitude *= noise.persistence;
                        frequency *= noise.lacunarity;
                    }

                    if (noiseHeight > maxNoiseHeight)
                    {
                        maxNoiseHeight = noiseHeight;
                    }
                    else if (noiseHeight < minNoiseHeight)
                    {
                        minNoiseHeight = noiseHeight;
                    }

                    noiseMap[x, y] = noiseHeight;
                }
            }

            for (var y = 0; y < noise.size; y++)
            {
                for (var x = 0; x < noise.size; x++)
                {
                    noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
                }
            }

            return noiseMap;
        }
    }
}