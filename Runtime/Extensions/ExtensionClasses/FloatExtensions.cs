using UnityEngine;

namespace Francespo.Utilities.Extensions
{
    public static class FloatExtensions
    {
        public static bool IsZero(this float value) => Mathf.Approximately(value, 0f);
        public static bool IsEqualTo(this float value, float other) => Mathf.Approximately(value, other);
    }
}
