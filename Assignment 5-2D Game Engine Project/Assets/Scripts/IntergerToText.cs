using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntergerToText : MonoBehaviour
{
    //Variables
    public Shooting shoot;
    public TextMeshProUGUI ValueText;

    private void Update()
    {
        //Display text for clip and ammo
        ValueText.text = shoot.currentClip.ToString() + " / " + shoot.maxClipSize +
            " | " + shoot.currentAmmo + " / " + shoot.maxAmmoSize;
    }
}
