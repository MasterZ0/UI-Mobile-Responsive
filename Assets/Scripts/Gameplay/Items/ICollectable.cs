using TritanTest.Data;
using UnityEngine;

namespace TritanTest.Gameplay
{
    public interface ICollectable
    {
        Transform Pivot { get; }
        ItemData Collect(Transform fxParent);
    }
}