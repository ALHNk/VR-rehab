using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using System.Collections;

public class Test : MonoBehaviour
{
	public Text responceText, debugText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
	public void SendpostRequest()
	{
		StartCoroutine(SentPostRequest());
	}

	IEnumerator SentPostRequest()
	{
		debugText.text = "Corutine Started";
		string url = "http://192.168.80.122:8080/test";
		var jsonBody = "{\"message\" :\"CHMO\"}";
		byte[] bodyraw = Encoding.UTF8.GetBytes(jsonBody);
		
		Debug.LogError("url" + url);
		Debug.LogError("json" + jsonBody);
		
		UnityWebRequest request = new UnityWebRequest(url, "POST");
		request.uploadHandler = new UploadHandlerRaw(bodyraw);
		request.downloadHandler = new DownloadHandlerBuffer();
		request.SetRequestHeader("Content-Type", "application/json");
		
		yield return request.SendWebRequest(); 
		
		if(request.result == UnityWebRequest.Result.Success)
		{
			responceText.text = request.downloadHandler.text;
			Debug.LogError(request.downloadHandler.text);
		}
		else {
			responceText.text = "error" + request.error;
		}
		
	}
}
