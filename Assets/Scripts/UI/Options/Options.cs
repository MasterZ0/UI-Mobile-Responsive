using Sirenix.OdinInspector;
using TritanTest.Shared;
using UnityEngine;

namespace TritanTest.UI.AppOptions
{
    public class Options : MonoBehaviour, IInitable
    {
        [Title("Options")]
        [SerializeField] private VideoOptions videoOptions;
        [SerializeField] private AudioOptions audioOptions;

        public void Init()
        {
            videoOptions.LoadSettings();
            audioOptions.LoadSettings();
        }
    }
}