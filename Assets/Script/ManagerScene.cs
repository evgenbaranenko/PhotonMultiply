using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class ManagerScene : MonoBehaviourPunCallbacks
{
    [SerializeField] public GameObject PlayerPrefab;
    private void Start()
    {
        Vector3 pos = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        PhotonNetwork.Instantiate(PlayerPrefab.name, pos, Quaternion.identity);
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        // ????? ??????? ????? ???????? ???????
        SceneManager.LoadScene(0);
    }
   
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} entered room ", newPlayer.NickName);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} left room ", otherPlayer.NickName);
    }
}
