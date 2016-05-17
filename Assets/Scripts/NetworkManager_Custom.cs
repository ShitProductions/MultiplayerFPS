using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkManager_Custom : NetworkManager {

	public void StartupHost()
    {
        SetPort();
        NetworkManager.singleton.StartHost();        
    }

    public void JoinGame()
    {
        SetIPAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
    }

    void SetIPAddress()
    {
        string ip = GameObject.Find("IP").GetComponent<Text>().text;

        NetworkManager.singleton.networkAddress = ip;
    }

    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            SetupMenuSceneButtons();
        }
        else
        {
            SetupOtherScenesButtons();
        }
    }

    void SetupMenuSceneButtons()
    {
        GameObject.Find("BT_CreateGame").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("BT_CreateGame").GetComponent<Button>().onClick.AddListener(StartupHost);

        GameObject.Find("BT_JoinGame").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("BT_JoinGame").GetComponent<Button>().onClick.AddListener(JoinGame);

    }

    void SetupOtherScenesButtons()
    {
        GameObject.Find("BT_Disconnect").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("BT_Disconnect").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopHost);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
