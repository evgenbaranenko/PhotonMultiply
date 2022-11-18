using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance 
    { 
        get 
        {
            //if (_instance == null)
            //{
            //    GameObject gameManager = Instantiate(Resources.Load("/Prefabs")) as GameObject;
            //    _instance = gameManager.GetComponent<GameManager>();
            //}
            return _instance; } 
        set { _instance = value; } }
    [SerializeField] private GameObject playerPrefab;
   // [SerializeField] private GameObject mainCameraObj;
   // public GameObject MainCameraObj { get { return mainCameraObj; } set { mainCameraObj = value; } }
    //[SerializeField] private TMPro.TMP_Text info;
    //[SerializeField] private GameObject ghostPrefab;

    bool waitingForPlayers = true;
    public void CreatePlayer()
    {
        //GameObject player = PhotonNetwork.Instantiate(playerPrefab.name,
        //    playerPrefab.transform.position + new Vector3(Random.Range(-5, 5), 0), Quaternion.identity);

        //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        //foreach (GameObject pl in players)
        //{
        //    pl.GetComponent<PlayerDog>().SetName(pl.GetComponent<PhotonView>().Owner.NickName);
        //}
    }
    void Start()
    {
        Physics2D.IgnoreLayerCollision(3, 3);
        //mainCameraObj.SetActive(true);
        CreatePlayer();
    }
    //IEnumerator Info()
    //{
    //    info.text = "GHOST INCOMING FROM LEFT SIDE!!! RUN AWAY TOGETHER!!!";
    //    yield return new WaitForSeconds(5f);
    //    info.text = "";
    //}

    void Update()
    {
        //if (waitingForPlayers)
        //{
        //    if (PhotonNetwork.CurrentRoom.PlayerCount > 1)
        //    {
        //        GameObject player = PhotonNetwork.Instantiate(ghostPrefab.name, ghostPrefab.transform.position, Quaternion.identity);
        //        StartCoroutine(Info());
        //        waitingForPlayers = false;
        //    }
        //}
    }


}