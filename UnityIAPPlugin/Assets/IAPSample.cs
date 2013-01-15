using UnityEngine;
using System.Collections;
using IAP;

public class IAPSample : MonoBehaviour {
	
	public int buttonWidth = 100;
	public int buttonHight = 40;
	public string identifier = null;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (InAppPurchase.IsPurchased())
		{
			InAppPurchase.Clear();
		}
	}
	
	void OnGUI() {
		if (GUI.Button(new Rect((Screen.width - buttonWidth) >> 1, (Screen.height - buttonHight) >> 1, buttonWidth, buttonHight), "Button"))
		{
			if (identifier != null)
			{
				if (InAppPurchase.CanPay())
				{
					InAppPurchase.Buy(identifier);
				}
			}
		}
	}
}
