using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EpicTransport;
using System;
using Mirror;

public class EOSInit : MonoBehaviour
{
    [SerializeField] private TMP_InputField _userInput;
    [SerializeField] private EOSSDKComponent _eos;
    [SerializeField] private EOSLobbyUI _lobbyUI;
    [SerializeField] private EosTransport _transport;

    private bool initialized;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!initialized && Input.GetKeyDown(KeyCode.Space))
        {
            _eos.devAuthToolCredentialName = _userInput.text;
            EOSSDKComponent.Initialize();
            _transport.enabled = true;
            _lobbyUI.enabled = true;

            _lobbyUI.JoinLobbySucceeded += OnJoinLobby;

            //NetworkManager.singleton.OnClientConnect += OnClientConnect

            initialized = true;
        }
    }

    private void OnJoinLobby(List<Epic.OnlineServices.Lobby.Attribute> attributes)
    {
        Debug.Log("Joined lobby!");
    }
}
