using UnityEngine;

namespace James
{
    /// <summary>
    /// 
    /// </summary>
    public class NPCController : MonoBehaviour
    {
        //�ǦC�����:�N�p�H�ܼ���ܦbUnity�ݩʭ��O
        [SerializeField,Header("NPC���")]
        private DataNPC dataNPC;

        //Unity���ʵe����t��
        private Animator ani;

        //����ƥ�:����C���ɷ|����@��
        private void Awake()
        {
             //��oNPC���W���ʵe���
              ani = GetComponent<Animator>();
        }
    }
}