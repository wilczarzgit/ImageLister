using UnityEngine;

namespace _Root.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SettingsObj", menuName = "Lister Settings", order = 1)]
    public class Settings : ScriptableObject {
        public string FolderPath;
        public string FilePattern;
        public GameObject ListElementPrefab;
    }
}
