using UnityEngine;
using System;

namespace Francespo.Utilities.Extensions
{
    public static class FloatExtensions
    {
        public static bool IsApproximately(this float value, float other) => Mathf.Approximately(value, other);
        public static bool IsApproximatelyZero(this float value) => value.IsApproximately(0);

        public static int Sign(this float value) => Math.Sign(value);
        public static float USignF(this float value) => Mathf.Sign(value);
        public static int USign(this float value) => (int)Mathf.Sign(value);
    }
}
