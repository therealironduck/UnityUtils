using System;
using UnityEngine;

namespace TheRealIronDuck.Runtime.Types
{
    /// <summary>
    /// Use this type if you need a layer selector which only allows to select
    /// one specific layer.
    ///
    /// Stolen from: https://discussions.unity.com/t/select-only-one-layer-in-the-inspector-select-only-one-layer-in-the-inspector/230727/3
    /// </summary>
    [Serializable]
    public class SingleLayer
    {
        /// <summary>
        /// The internal layer index.
        /// </summary>
        [SerializeField] int layerIndex;

        /// <summary>
        /// The layer index which is selected.
        /// </summary>
        public int LayerIndex
        {
            get { return layerIndex; }
        }

        /// <summary>
        /// This helper can be used to convert the selected Layer into a layer mask
        /// </summary>
        public int Mask
        {
            get
            {
                if (LayerIndex < 0 || LayerIndex > 31)
                    return 0;
                return 1 << LayerIndex;
            }
        }
    }
}
