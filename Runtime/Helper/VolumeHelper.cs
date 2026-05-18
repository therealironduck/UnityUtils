using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace TheRealIronDuck.Runtime.Helper
{
    public static class VolumeHelper
    {
        /// <summary>
        /// Small helper method which allows to cross-fade between two volumes.
        /// </summary>
        /// <param name="a">The volume which should be disabled</param>
        /// <param name="b">The volume which should be enabled</param>
        /// <param name="duration">Total time for transition</param>
        public static IEnumerator CrossfadeVolumes(Volume a, Volume b, float duration)
        {
            if (a == null) throw new System.ArgumentNullException(nameof(a));
            if (b == null) throw new System.ArgumentNullException(nameof(b));
            if (duration < 0f) throw new System.ArgumentOutOfRangeException(nameof(duration), "Duration must be >= 0.");

            var elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                var t = Mathf.Clamp01(elapsed / duration);

                a.weight = 1f - t;
                b.weight = t;

                yield return null;
            }

            a.weight = 0f;
            b.weight = 1f;
        }
    }
}
