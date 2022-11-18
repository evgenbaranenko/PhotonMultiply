using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class UIhandler : MonoBehaviourPunCallbacks
{
    public InputField createRoomTF;

    public InputField joinRoomTF;

    public void OnClick_JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomTF.text, null);
    }
    public void OnClick_CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomTF.text, new RoomOptions { MaxPlayers = 4 }, null);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);

        print("Room Joined Sucess");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("RoomFaild" + returnCode + "Message" + message);
    }
}