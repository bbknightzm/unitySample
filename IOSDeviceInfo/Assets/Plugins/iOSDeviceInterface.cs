using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using System;
using System.Net;
using System.Net.NetworkInformation;
//using System.Management;
//using System.Management.Instrumentation;

public class iOSDeviceInterface : MonoBehaviour {
	
	public int buttonWidth = 200;
	public int buttonHight = 80;

	[DllImport ("__Internal")]
	[return: MarshalAs(UnmanagedType.LPStr)]
	public static extern string GetiOSMacAddress();//byte[] GetiOSMacAddress();
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void OnGUI() {
		if (GUI.Button(new Rect((Screen.width - buttonWidth) >> 1, (Screen.height - buttonHight) >> 1, buttonWidth, buttonHight), "Button"))
		{
			//byte[] abc = new byte[8];
			//mac = Encoding.UTF8.GetString(abc);//GetiOSMacAddress());
			// Debug.Log("IOS MAC Address : " + System.Convert.ToString(GetiOSMacAddress()));
			Debug.Log("Unity MAC : " + getMacAddress() + ".");
			Debug.Log("Uinty Local IP : " + getLocalIP() + ".");
			Debug.Log("Uinty IP : " + getLocalIP() + ".");
			Debug.Log("Mac : " + GetiOSMacAddress());
		}
	}
	
	public string getIP()
	{
		string strHostName = Dns.GetHostName();
		IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
		string strAddr = ipEntry.AddressList[0].ToString();
		return(strAddr);
	}
	
	public string getLocalIP()
	{
		return Network.player.ipAddress;
	}
	
	public string getMacAddress()
    {
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
		string allmac = null;
        foreach (NetworkInterface adapter in nics)
        {
            PhysicalAddress address = adapter.GetPhysicalAddress();
			if (adapter.Description.Equals("en0"))
			{
				string mac = null;
	            byte[] bytes = address.GetAddressBytes();
	            for (int i = 0; i < bytes.Length; i++)
	            {
	                mac = string.Concat(mac +(string.Format("{0}", bytes[i].ToString("X2"))));
	            }
				return mac;
			}
        }
		return allmac;
    }

	public static void DisplayTypeAndAddress()
    {
        //IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        Debug.Log(nics.Length + " nics");
        //Debug.Log("Interface information for "+computerProperties.HostName+"."+computerProperties.DomainName);
		foreach (NetworkInterface adapter in nics)
       {
            //IPInterfaceProperties properties = adapter.GetIPProperties();
            Debug.Log(adapter.Description);
            Debug.Log(String.Empty.PadLeft(adapter.Description.Length, '='));
            Debug.Log("  Interface type .......................... : " + adapter.NetworkInterfaceType);
            Debug.Log("  Physical Address ........................ : " + adapter.GetPhysicalAddress().ToString());
            Debug.Log("  Is receive only.......................... : " + adapter.IsReceiveOnly);
            Debug.Log("  Multicast................................ : " + adapter.SupportsMulticast);
        }
    }
}
