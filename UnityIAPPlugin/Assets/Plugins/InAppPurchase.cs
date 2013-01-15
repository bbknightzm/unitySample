using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace IAP
{
	public class InAppPurchase
	{
		[DllImport ("__Internal")]
		public static extern bool	CanPay();
		[DllImport ("__Internal")]
	    public static extern void	BuyProduct(byte[] productIdentifier, int len);
		[DllImport ("__Internal")]
	    public static extern bool	IsPurchased();
		[DllImport ("__Internal")]
	    public static extern void	Clear();
		
		public static void Buy(string idf)
		{
			byte[] identify = Encoding.UTF8.GetBytes(idf);
			BuyProduct(identify, identify.Length);
		}
	}
}

