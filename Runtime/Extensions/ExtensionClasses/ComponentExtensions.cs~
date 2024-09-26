using UnityEngine;

namespace Francespo.Extensions
{
    public static class ComponentExtensions
    {
        public static GameObject FindChild<T>(this T obj, string name) where T : Component
        {
            Transform trans = obj.transform;
            Transform childTrans = trans.Find(name);
            return childTrans != null ? childTrans.gameObject : null;
        }
        public static GameObject FindDeepChild<T>(this T obj, string name) where T : Component
        {
            Transform trans = obj.transform;
            Transform childTrans = trans.FindDeepChild(name);
            return childTrans != null ? childTrans.gameObject : null;
        }

        public static GameObject[] GetChildren<T>(this T obj) where T : Component
        {
            return obj.gameObject.GetChildren();
        }

        public static void Highlight<T>(this T obj, bool shouldBeHighLighted, bool highlightChildren = true, float brightnessOffset = 0.75f) where T : Component
        {
            obj.Highlight(shouldBeHighLighted, highlightChildren, brightnessOffset);
        }
    }
}