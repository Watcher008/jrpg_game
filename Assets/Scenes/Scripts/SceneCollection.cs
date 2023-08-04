using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JS.SceneManagement
{
    [CreateAssetMenu(menuName = "Scene Management/Scene Collection")]
    public class SceneCollection : ScriptableObject
    {
        [field: SerializeField] public List<ScenePicker> Scenes { get; private set; }
    }
}