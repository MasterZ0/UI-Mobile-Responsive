using TritanTest.Data;
using UnityEngine;

namespace TritanTest.Gameplay
{

    /// <summary>
    /// Note to developers: Please describe what this class does.
    /// </summary>
    public interface ICollectable 
    {
        ItemData Collect(Transform fxParent);
    }
}