using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasingManager : MonoBehaviour
{
   public void OnPressDown(int i)
   {
      var diamonds =   PlayerPrefs.GetInt ("Diamonds", 0);
      
      switch (i)
      {
         case 1:
            PlayerPrefs.SetInt("Diamonds", diamonds + 1);
            GameDataManager.Instance.playerData.AddDiamond(1);
             IAPManager.Instance.BuyProductID(IAPKey.PACK1);
            break;
         case 2:
            PlayerPrefs.SetInt("Diamonds", diamonds + 3);
            IAPManager.Instance.BuyProductID(IAPKey.PACK2);
            break;
         case 3:
            PlayerPrefs.SetInt("Diamonds", diamonds + 5);
            IAPManager.Instance.BuyProductID(IAPKey.PACK3);
            break;
         case 4:
            PlayerPrefs.SetInt("Diamonds", diamonds + 10);
            IAPManager.Instance.BuyProductID(IAPKey.PACK4);
            break;
      }
   }

   public void Sub(int i)
   {
      GameDataManager.Instance.playerData.SubDiamond(i);
   }
}
