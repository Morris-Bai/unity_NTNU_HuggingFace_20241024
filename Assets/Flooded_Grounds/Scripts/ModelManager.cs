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
    public class ModelManager : MonoBehaviour
    {
        private string url = "https://g.ubitus.ai/v1/chat/completions";
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
            var data = new
            {
                //model = "llama-3.1-70b",
                model = "taide-8b",
                messages = new
                {
                    name = "user",
                    content = prompt,
                    role = this.role
                },
            stop = new string[] { "<|eot_id|>", "<|end_of_text|>" },
        frequency_penalty = 0,
        max_tokens = 2000,
        temperature = 0.2,
        top_p = 0.5,
        top_k = 20,
        stream = false
        };

        string json = JsonUtility.ToJson(data);
        byte[] postData = Encoding.UTF8.GetBytes(json);
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(postData);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer" + key);
        yield return request.SendWebRequest();

        print(request.result);
        print(request.error);
        }
    }
}
