using UnityEngine;
using System.Collections;
/*
public class HTMLTest : MonoBehaviour {

	public int width =512;
	public int height = 512;
	Texture2D m_Texture = null;
	
	
	void Start() {
		m_Texture = new Texture2D (width, height, TextureFormat.ARGB32, false);
		if (m_Texture == null)
			Debug.Log("Texture error.");
		m_Texture.Apply();
		HTMLTexturePlugin.htmlTexture_start(m_Texture.GetInstanceID(), width, height, "2");
		// put the texture on something
		if (transform == null)
			Debug.Log("transorm null.");
		if (transform.renderer == null)
			Debug.Log("render null.");
		transform.renderer.sharedMaterial.mainTexture = m_Texture;
	}
 
	void Update() {
		HTMLTexturePlugin.htmlTexture_update( m_Texture.GetInstanceID() );
	}
 
	void OnApplicationQuit() {
		HTMLTexturePlugin.htmlTexture_stop();
	}
	
	void OnMouseUp()
	{
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
		{
			int x = width - (int) (hit.textureCoord.x * width); 
			int y = height - (int) (hit.textureCoord.y * height); 
			HTMLTexturePlugin.htmlTexture_mouseup(m_Texture.GetInstanceID(), x, y );
		}
	}
}
*/