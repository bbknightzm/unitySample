using UnityEngine;
using System.Collections;
using LitJson;

public class HttpPostTest : MonoBehaviour {

	// Post
	public int buttonWidth = 200;
	public int buttonHight = 80;
	public string buttonString = "Post";
	
	// Url and parameter
	public string url = null;
	public string deviceToken = null;
	public string websiteToken = null;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI() {
		if (GUI.Button(new Rect((Screen.width - buttonWidth) >> 1, (Screen.height - buttonHight) >> 1, buttonWidth, buttonHight), "Button"))
		{
//			Debug.Log("URL start");
//			Application.OpenURL("http://www.google.com.hk");
//			Debug.Log("URL end");
			StartCoroutine("PostTest1");
		}
	}
	
	IEnumerator PostTest1()
	{
		string str = @"";
		// string like this
		// str = @"{""Id"":0,""IMEI"":""String"",""Phone"":""String"",""Name"":""String"",""Status"":0,""CreateTime"":""\/Date(-62135596800000+0800)\/"",""UpdateTime"":""\/Date(-62135596800000+0800)\/""}";
		// write Json
		JsonWriter writer = new JsonWriter();
		writer.WriteObjectStart();
		writer.WritePropertyName("Id");
		writer.Write(0);
		writer.WritePropertyName("IMEI");
		writer.Write("7654321");
		writer.WritePropertyName("Phone");
		writer.Write("13802817183");
		writer.WritePropertyName("Name");
		writer.Write("bbzm");
		writer.WritePropertyName("Status");
		writer.Write("1");
		writer.WritePropertyName("CreateTime");
		writer.Write("2013-01-01");
		writer.WritePropertyName("UpdateTime");
		writer.Write("2013-10-10");
		writer.WriteObjectEnd();
		str = writer.ToString();
		
		Debug.Log(str);
		WWWForm parameter = new WWWForm();
		parameter.AddField("Body", str);
		
		WWW postRequest = new WWW(@"http://192.168.133.225:82/Client/123456?format=json", parameter);
		yield return postRequest;
		
		JsonReader read = new JsonReader(postRequest.text);
		Debug.Log(postRequest.text);
		Debug.Log(" ----------------- ");
		while (read.Read())
		{
			Debug.Log(read.Token + " : " + read.Value + " : " + read.GetType().ToString());
		}
		Debug.Log(" ----------------- ");
	}
	
	IEnumerator PostTest2()	{
		WWWForm parameter = new WWWForm();
		parameter.AddField("deviceToken", deviceToken);
		parameter.AddField("websiteToken", websiteToken);
		
		WWW postRequest = new WWW(url, parameter);
		
		yield return postRequest;
		
		if (postRequest.error != null)
		{
			Debug.Log("Post request error : " + postRequest.error);
		}
		else if (postRequest.isDone)
		{
			Debug.Log("Post request : " + postRequest.text);
		}
	}
}
