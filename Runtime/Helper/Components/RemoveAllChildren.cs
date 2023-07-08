using UnityEngine;

namespace TheRealIronDuck.Runtime.Helper.Components
{
    public class RemoveAllChildren : MonoBehaviour
    {
        public void RemoveAll()
        {
            if (Application.isPlaying)
            {
                while (transform.childCount > 0)
                {
                    Destroy(transform.GetChild(0).gameObject);
                }
                
                return;
            }
            
            while (transform.childCount > 0)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
    }
}