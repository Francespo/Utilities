using System.Collections.Generic;
using UnityEngine;

namespace Francespo.Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 CustomSet(this ref Vector3 toModify, float? x = null, float? y = null, float? z = null)
        {
            toModify.Set(x ?? toModify.x, y ?? toModify.y, z ?? toModify.z);
            return toModify;
        }
        public static Vector3 CustomSet(this ref Vector3 toModify, Vector2 v2ToUseAsBase, float? x = null, float? y = null, float? z = null)
        {
            toModify.Set(x ?? v2ToUseAsBase.x, y ?? v2ToUseAsBase.y, z ?? toModify.z);
            return toModify;
        }
        public static Vector3 CustomSet(this ref Vector3 toModify, Vector3 v3ToUseAsBase, float? x = null, float? y = null, float? z = null)
        {
            toModify.Set(x ?? v3ToUseAsBase.x, y ?? v3ToUseAsBase.y, z ?? v3ToUseAsBase.z);
            return toModify;
        }


        /// <summary>
        /// EqualTo to CustomSet, but this doesn't change the Vector3. Useful with values non stored in a variable
        /// </summary>
        /// <param name="position"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 CustomReturnOnly(this Vector3 position, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x ?? position.x, y ?? position.y, z ?? position.z);
        }
        /// <summary>
        /// EqualTo to CustomSet, but this doesn't change the Vector3. Useful with values non stored in a variable
        /// </summary>
        /// <param name="position"></param>
        /// <param name="v2ToUseAsBase"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 CustomReturnOnly(this Vector3 position, Vector2 v2ToUseAsBase, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x ?? v2ToUseAsBase.x, y ?? v2ToUseAsBase.y, z ?? position.z);
        }

        public static List<Vector2> ToVector2(this List<Vector3> positions)
        {
            var toReturn = new List<Vector2>();
            foreach (var position in positions)
                toReturn.Add((Vector2)position);
            return toReturn;
        }
        public static List<Vector2Int> ToVector2Int(this List<Vector3Int> positions)
        {
            var toReturn = new List<Vector2Int>();
            foreach (var position in positions)
                toReturn.Add((Vector2Int)position);
            return toReturn;
        }

        public static Vector3 SwitchYZ(this ref Vector3 toModify)
        {
            toModify = new Vector3(toModify.x, toModify.z, toModify.y);
            return toModify;
        }
        public static Vector3 ReturnSwitchYZ(this Vector3 toModify)
        {
            return new Vector3(toModify.x, toModify.z, toModify.y);
        }
        public static Vector3 SwitchYZ(this ref Vector2 toModify)
        {
            toModify = new Vector3(toModify.x, 0, toModify.y);
            return toModify;
        }
        public static Vector3 ReturnSwitchYZ(this Vector2 toModify)
        {
            return new Vector3(toModify.x, 0, toModify.y);
        }
        public static Vector3 SwitchXY(this ref Vector3 toModify)
        {
            toModify = new Vector3(toModify.y, toModify.x, toModify.z);
            return toModify;
        }
        public static Vector3 ReturnSwitchXY(this Vector3 toModify)
        {
            return new Vector3(toModify.y, toModify.x, toModify.z);
        }
        public static Vector2 SwitchXY(this ref Vector2 toModify)
        {
            toModify = new Vector2(toModify.y, toModify.x);
            return toModify;
        }
        public static Vector2 ReturnSwitchXY(this Vector2 toModify)
        {
            return new Vector2(toModify.y, toModify.x);
        }

    }
}
