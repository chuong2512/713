using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiamondDisplay : MonoBehaviour
{
   public TextMeshProUGUI diamondTmp;

   void OnValidated()
   {
      diamondTmp = GetComponent<TextMeshProUGUI>();
   }

   private void Update()
   {
      
      diamondTmp.text = PlayerPrefs.GetInt ("Diamonds", 0).ToString ();
   }
}
