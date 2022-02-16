using UnityEngine;
using Object = UnityEngine.Object;

namespace _Root.Scripts
{
    public static class TransformExtensions
    {
        public static Transform[] GetAllChildren(this Transform itemParent)
        {
            var children = new Transform[itemParent.childCount];
            for (var i = 0; i < itemParent.childCount; i++)
            {
                children[i] = itemParent.GetChild(i).transform;
            }
            return children;
        }

        public static void DestroyAllChildren(this Transform itemParent)
        {
            var children = new GameObject[itemParent.childCount];
            for (var i = 0; i < itemParent.childCount; i++)
            {
                children[i] = itemParent.GetChild(i).gameObject;
            }

            foreach (var child in children) {
                Object.Destroy(child);
            }
        }

        public static void DestroyAllChildrenImmediate(this Transform itemParent)
        {
            var children = new GameObject[itemParent.childCount];
            for (var i = 0; i < itemParent.childCount; i++)
            {
                children[i] = itemParent.GetChild(i).gameObject;
            }

            foreach (var child in children) {
                Object.DestroyImmediate(child);
            }
        }
    }
}