using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

[AddComponentMenu("Network/NetworkManagerHUD")]
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public class HUDControl : NetworkBehaviour
{
    public NetworkManagerHUD networkManagerHud;

    public Text text;

    void Start()
    {
        networkManagerHud = GameObject.Find("NetworkManager").GetComponent<NetworkManagerHUD>();
        text = GameObject.Find("Text").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeHUDState(true);
        }
    }

    public void ChangeHUDState(bool state)
    {
        networkManagerHud.showGUI = state;
    }
}