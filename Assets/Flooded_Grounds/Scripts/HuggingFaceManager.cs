using System.Collections;
using System.Text;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering.Universal;

namespace James
{
    /// <summary>
    /// �ҫ��޲z��
    /// <summary>
    public class HuggingFaceManager : MonoBehaviour
    {
        private string url = "https://api-inference.huggingface.co/models/sentence-transformers/all-MiniLM-L6-v2";
        private string key = "d4pHv5n2G3q2vkVMPen3vFMfUJic4huKiQbvMmGLWUVIr/ptUuGnsCx/zVdYmVtdrGPO9//2h8Fbp6HkSQ0/oA==";

        private TMP_InputField inputField;
        private string prompt;
        private string role = "�A�O�@���p�ª�";

        //����ƥ� : �C�������|����@��
        private void Awake()
        {
            inputField = GameObject.Find("��J���").GetComponent<TMP_InputField>();
            //���a�����s���J���ɷ|���� PlayerInput��k
            inputField.onEndEdit.AddListener(PlayerInput);
        }

        private void PlayerInput(string input)
        {
            print($"<color=#3f3> {input} </color>");
            prompt = input;

            StartCoroutine(GetResult());
        }
        //�M������W�W�٬� ��J��� ������æs���inputField�ܼƤ�



        private IEnumerator GetResult()
        {
            var inputs = new
            {
                source_sentence = prompt,
                sentences = ""
            };

            string json = JsonUtility.ToJson(inputs);
            byte[] postData = Encoding.UTF8.GetBytes(json);
            UnityWebRequest request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(postData);
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer" + key);
            yield return request.SendWebRequest();

            print(request.result);
        }
    }
}

