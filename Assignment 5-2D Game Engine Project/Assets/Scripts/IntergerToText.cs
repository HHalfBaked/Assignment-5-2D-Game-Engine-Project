using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntergerToText : MonoBehaviour
{
    public Shooting shoot;

    public TextMeshProUGUI ValueText;

    private void Update()
    {
        ValueText.text = shoot.currentClip.ToString() + " / " + shoot.maxClipSize +
            " | " + shoot.currentAmmo + " / " + shoot.maxAmmoSize;
    }
}
