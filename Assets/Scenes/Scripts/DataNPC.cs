using UnityEngine;

namespace James
{
    /// <summary>
    /// NPC���
    /// </summary>
    [CreateAssetMenu(menuName = "James/NPC")]
    public class DataNPC : ScriptableObject
    {
        [Header("NPC�n���R���y�l")]
        public string[] sentences;
    }
}