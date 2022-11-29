﻿using UnityEngine;

namespace TritanTest.Shared.ExtensionMethods
{

    public static class FloatExtensions {

        /// <returns> Return a value between -180 to 180 </returns>
        public static float NormalizeAngle(this float angle) {
            angle %= 360;
            return angle > 180 ? angle - 360 : angle;
        }

        /// <returns> Return a value between 0 to 360 </returns>
        public static float NormalizeAngle360(this float angle) {
            angle %= 360;
            return angle < 0 ? angle + 360 : angle;
        }

        public static float Remap(this float value, float minIn, float maxIn, float minOut, float maxOut) {
            return (value - minIn) / (maxIn - minIn) * (maxOut - minOut) + minOut;
        }

        public static bool IsEqualTo(this float originValue, float value) {
            return Mathf.Abs(originValue - value) < Mathf.Epsilon;
        }
        
        public static Vector2 ToVector(this float value) => new Vector2(value, value);
    }
}