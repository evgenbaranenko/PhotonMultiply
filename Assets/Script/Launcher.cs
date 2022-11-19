using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject connectedScreen;

    [SerializeField] private GameObject disconnectedScreen;

    [SerializeField] private Text LogText;

    [SerializeField] private GameObject LogTextObj;

    [SerializeField] public InputField createRoomTF;

    [SerializeField] public InputField joinRoomTF;
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // подключение к мастер серверу (берет все настройки и подключается для матчмейкинга)
        PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999); // рандомные ники играков 
        PhotonNetwork.GameVersion = "1"; // версии игры 
        PhotonNetwork.AutomaticallySyncScene = true; // переключение сцены автоматически на всех клиентах
        Log("Player's name is set to " + PhotonNetwork.NickName);  // вывод сообщения 
    }

    public override void OnConnectedToMaster() // подключение к серверу matchmaking (datacentr)
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Log("Connected to Master ...");
    }
       
    private void Log(string message)
    {
        Debug.Log(message);
        LogText.text += "\n";
        LogText.text += message;
    }
    //для кнопки создания комнаты 
    public void CreateRoom()
    {
        //создание комнаты с названием createRoomTF
        PhotonNetwork.CreateRoom(createRoomTF.text, new Photon.Realtime.RoomOptions { MaxPlayers = 3 });
        Log($"Created the room {createRoomTF.text} ");
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom(); // подключение к комнате  createRoomTF
    }
 
    public override void OnJoinedRoom() // вызовет сам Photon когда мы подключимся к комнате 
    {
        Log($"Joined the room... ");
        PhotonNetwork.LoadLevel(1);
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("RoomFaild" + returnCode + "Message" + message);
    }
    //public void OnClick_ConnectedBtn()
    //{
    //    PhotonNetwork.ConnectUsingSettings();
    //}
    public override void OnDisconnected(DisconnectCause cause)
    {
        disconnectedScreen.SetActive(true);
        connectedScreen.SetActive(false);
        LogTextObj.SetActive(false);
    }
    public override void OnJoinedLobby()
    {
        if (disconnectedScreen.activeSelf)
            disconnectedScreen.SetActive(false);

        connectedScreen.SetActive(true);
        LogTextObj.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}