using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

namespace TritanTest.ApplicationManager
{
    /// <summary>
    /// Display the current Application Version
    /// </summary>
    public class ProjectVersion : MonoBehaviour 
    {
        [Title("Project Version")]
        [SerializeField] private TextMeshProUGUI version;

        private void Awake() => version.text = Application.version;
    }
}