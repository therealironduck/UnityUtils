using TheRealIronDuck.Runtime.Noise;
using TheRealIronDuck.Runtime.Noise.Data;
using UnityEditor;
using UnityEngine;

namespace TheRealIronDuck.Editor.Noise
{
    [CustomEditor(typeof(NoiseSo))]
    public class NoiseSoEditor : UnityEditor.Editor
    {
        public override bool HasPreviewGUI() => true;

        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            var so = (target as NoiseSo);
            var noise = so?.noiseData;
            if (so == default || noise == default)
            {
                return;
            }

            var noiseMap = NoiseGenerator.GenerateNoiseMap(
                noise,
                so.previewSeed,
                so.previewOffset,
                ! so.previewHideFalloff
            );

            var colors = new Color[noise.size * noise.size];
            for (var y = 0; y < noise.size; y++)
            {
                for (var x = 0; x < noise.size; x++)
                {
                    colors[y * noise.size + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
                }
            }
            
            var texture = new Texture2D(noise.size, noise.size);

            texture.SetPixels(colors);
            texture.filterMode = FilterMode.Point;
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.Apply();

            var textureRect = new Rect(r.x, r.y, r.width, r.height - 60);
            GUI.DrawTexture(textureRect, texture, ScaleMode.ScaleToFit, true, 1f);
        }
    }
}