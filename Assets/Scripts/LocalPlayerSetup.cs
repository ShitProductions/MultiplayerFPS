using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class LocalPlayerSetup : NetworkBehaviour
{
    //declering required varibles
    //scene camera and its audio listener
    public Camera sceneCamera;
    public AudioListener sceneCamerAudioListener;

    //the player, his attached camera, the controller script of the player and the camera Audio Listner
    public GameObject player;
    public Camera playerCamera;
    public AudioListener playerAudioListener;
    public FirstPersonController playerController;

    //the network Manager
    public NetworkManager networkManager;
    public NetworkConnection client;


    void Start()
    {
        //getting the varibes 
        sceneCamera = GameObject.Find("SceneCam").GetComponent<Camera>();
        sceneCamerAudioListener = GameObject.Find("SceneCam").GetComponent<AudioListener>();

        player = this.gameObject;
        playerCamera = player.GetComponentInChildren<Camera>();
        playerAudioListener = playerCamera.GetComponent<AudioListener>();
        playerController = player.GetComponent<FirstPersonController>();

        networkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        client = new NetworkConnection();

        //diabling and enabling the varibles
        if (isLocalPlayer)
        {
            //disabling the scene Camera and its audio Listner to avoid collisns betwwen the player and the scene Camera
            ChangeSceneCameraState(false);

            //enabling the player and its controller script
            ChangePlayerState(true);
        }
    }

    void Update()
    {   
    }

    public void ChangeSceneCameraState(bool state)
    {
        sceneCamera.enabled = state;
        sceneCamerAudioListener.enabled = state;
    }

    public void ChangePlayerState(bool state)
    {
        player.SetActive(state);
        playerCamera.enabled = state;
        playerAudioListener.enabled = state;
        playerController.enabled = state;
    }    
}

