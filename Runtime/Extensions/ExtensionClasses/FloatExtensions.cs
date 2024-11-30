using UnityEngine;

namespace Francespo.Utilities.Extensions
{
    public static class FloatExtensions
    {
        public static bool IsApproximately(this float value, float other) => Mathf.Approximately(value, other);
        public static bool IsApproximatelyZero(this float value) => value.IsApproximately(0);
    }
}
