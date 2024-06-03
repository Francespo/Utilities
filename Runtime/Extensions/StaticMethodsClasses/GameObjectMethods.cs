using UnityEngine;

namespace Francespo.Extensions
{
    public static class GameObjectMethods
    {
        public static GameObject FindChild(GameObject parent, string name)
        {
            Transform trans = parent.transform;
            Transform childTrans = trans.Find(name);

            return childTrans != null ? childTrans.gameObject : null;
        }

        public static GameObject FindDeepChild(GameObject parent, string name)
        {
            Transform trans = parent.transform;
            Transform childTrans = trans.FindDeepChild(name);

            return childTrans != null ? childTrans.gameObject : null;
        }
    }
}
