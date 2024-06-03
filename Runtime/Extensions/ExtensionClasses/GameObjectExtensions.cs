using UnityEngine;
using UnityEngine.UI;

namespace Francespo.Extensions
{
    public static class GameObjectExtensions
    {
        public static T AddConstructableMonoBehaviour<T, A0>(this GameObject obj, A0 arg0) where T : ConstructableMonoBehaviour<A0>
        {
            var comp = obj.AddComponent<T>();
            comp.Init(arg0);
            return comp;
        }
        public static T AddConstructableMonoBehaviour<T, A0, A1>(this GameObject obj, A0 arg0, A1 arg1) where T : ConstructableMonoBehaviour<A0, A1>
        {
            var comp = obj.AddComponent<T>();
            comp.Init(arg0, arg1);
            return comp;
        }
        public static T AddConstructableMonoBehaviour<T, A0, A1, A2>(this GameObject obj, A0 arg0, A1 arg1, A2 arg2) where T : ConstructableMonoBehaviour<A0, A1, A2>
        {
            var comp = obj.AddComponent<T>();
            comp.Init(arg0, arg1, arg2);
            return comp;
        }
        public static T AddConstructableMonoBehaviour<T, A0, A1, A2, A3>(this GameObject obj, A0 arg0, A1 arg1, A2 arg2, A3 arg3) where T : ConstructableMonoBehaviour<A0, A1, A2, A3>
        {
            var comp = obj.AddComponent<T>();
            comp.Init(arg0, arg1, arg2, arg3);
            return comp;
        }
        public static T AddConstructableMonoBehaviour<T, A0, A1, A2, A3, A4>(this GameObject obj, A0 arg0, A1 arg1, A2 arg2, A3 arg3, A4 arg4) where T : ConstructableMonoBehaviour<A0, A1, A2, A3, A4>
        {
            var comp = obj.AddComponent<T>();
            comp.Init(arg0, arg1, arg2, arg3, arg4);
            return comp;
        }
        public static T AddConstructableMonoBehaviour<T, A0, A1, A2, A3, A4, A5>(this GameObject obj, A0 arg0, A1 arg1, A2 arg2, A3 arg3, A4 arg4, A5 arg5) where T : ConstructableMonoBehaviour<A0, A1, A2, A3, A4, A5>
        {
            var comp = obj.AddComponent<T>();
            comp.Init(arg0, arg1, arg2, arg3, arg4, arg5);
            return comp;
        }
        public static T AddConstructableMonoBehaviour<T, A0, A1, A2, A3, A4, A5, A6>(this GameObject obj, A0 arg0, A1 arg1, A2 arg2, A3 arg3, A4 arg4, A5 arg5, A6 arg6) where T : ConstructableMonoBehaviour<A0, A1, A2, A3, A4, A5, A6>
        {
            var comp = obj.AddComponent<T>();
            comp.Init(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            return comp;
        }
        public static T AddConstructableMonoBehaviour<T, A0, A1, A2, A3, A4, A5, A6, A7>(this GameObject obj, A0 arg0, A1 arg1, A2 arg2, A3 arg3, A4 arg4, A5 arg5, A6 arg6, A7 arg7) where T : ConstructableMonoBehaviour<A0, A1, A2, A3, A4, A5, A6, A7>
        {
            var comp = obj.AddComponent<T>();
            comp.Init(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            return comp;
        }
        public static T AddConstructableMonoBehaviour<T, A0, A1, A2, A3, A4, A5, A6, A7, A8>(this GameObject obj, A0 arg0, A1 arg1, A2 arg2, A3 arg3, A4 arg4, A5 arg5, A6 arg6, A7 arg7, A8 arg8) where T : ConstructableMonoBehaviour<A0, A1, A2, A3, A4, A5, A6, A7, A8>
        {
            var comp = obj.AddComponent<T>();
            comp.Init(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            return comp;
        }

        public static GameObject FindChild(this GameObject parent, string name)
        {
            return GameObjectMethods.FindChild(parent, name);
        }
        public static GameObject FindDeepChild(this GameObject parent, string name)
        {
            return GameObjectMethods.FindDeepChild(parent, name);
        }
        public static GameObject[] GetChildren(this GameObject parent)
        {
            Transform[] transforms = parent.GetComponentsInChildren<Transform>();
            RectTransform[] rectTransforms = parent.GetComponentsInChildren<RectTransform>();

            GameObject[] toReturn = new GameObject[transforms.Length + rectTransforms.Length];
            for (int t = 0; t < transforms.Length; t++)
                toReturn[t] = transforms[t].gameObject;
            for (int r = transforms.Length; r < transforms.Length + rectTransforms.Length; r++)
                toReturn[r] = transforms[r].gameObject;

            return toReturn;
        }
        public static void Highlight(this GameObject obj, bool shouldBeHighLighted, bool highlightChildren = true, float brightnessOffset = 0.75f)
        {

            if (obj.TryGetComponent(out SpriteRenderer sr))
            {
                sr.color = shouldBeHighLighted ? sr.color.BrightnessOffset(brightnessOffset) : sr.color.BrightnessOffset(-brightnessOffset);
                if (highlightChildren)
                    foreach (var children in sr.GetChildren())
                        children.Highlight(shouldBeHighLighted, highlightChildren, brightnessOffset);
            }
            else if (obj.TryGetComponent(out Image im))
            {
                im.color = shouldBeHighLighted ? im.color.BrightnessOffset(brightnessOffset) : im.color.BrightnessOffset(-brightnessOffset);
                if (highlightChildren)
                    foreach (var children in im.GetChildren())
                        children.Highlight(shouldBeHighLighted, highlightChildren, brightnessOffset);
            }
            else if (obj.TryGetComponent(out RawImage rim))
            {
                rim.color = shouldBeHighLighted ? rim.color.BrightnessOffset(brightnessOffset) : rim.color.BrightnessOffset(-brightnessOffset);
                if (highlightChildren)
                    foreach (var children in rim.GetChildren())
                        children.Highlight(shouldBeHighLighted, highlightChildren, brightnessOffset);
            }
        }
    }
}
