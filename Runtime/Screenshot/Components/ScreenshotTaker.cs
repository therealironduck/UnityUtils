using System.IO;
using UnityEngine;

namespace TheRealIronDuck.Runtime.Screenshot.Components
{
    public class ScreenshotTaker : MonoBehaviour
    {
        #region EXPOSED FIELDS

        [SerializeField] private string imageName = "MyScreenshot";
        [SerializeField] [Min(1)] private int width = 256;
        [SerializeField] [Min(1)] private int height = 256;

        [SerializeField] private Camera captureCamera;

        #endregion

        #region PUBLIC METHODS

        public void Capture()
        {
            if (captureCamera == null)
            {
                Debug.LogError(
                    "Please assign a capture camera before capturing a screenshot. You can use the prefab in the package to get started."
                );

                return;
            }

            var renderTexture = new RenderTexture(width, height, 32);
            captureCamera.targetTexture = renderTexture;

            var screenShot = new Texture2D(width, height, TextureFormat.ARGB32, false);
            captureCamera.Render();

            RenderTexture.active = renderTexture;

            screenShot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            
            captureCamera.targetTexture = null;
            RenderTexture.active = null;
            Destroy(renderTexture);

            var bytes = screenShot.EncodeToPNG();
            var fileName = Path.Combine(Application.dataPath, $"{imageName}.png");
            File.WriteAllBytes(fileName, bytes);
            
            Debug.Log($"Saved screenshot at: {fileName}");
        }

        #endregion
    }
}