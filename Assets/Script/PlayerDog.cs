using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDog : MonoBehaviour, IPunObservable // ????????? ????????? ??? ???? ??? ?? photon ??? ?? ??? ?????????
{
    [SerializeField] private PhotonView photonView;

    [SerializeField] private Animator animator;

    [SerializeField] private Rigidbody2D playerRigidbody;

    [SerializeField] private float moveSpeed = 4;

    // [SerializeField] public GameObject playerCamera;

    [SerializeField] TMPro.TMP_Text nameText;

    private bool directionNameText = true;

    [SerializeField] private GameObject nameTextObj;

    private SpriteRenderer spriteRenderer;

    private bool isRed;

    Vector3 smoothMove;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        //playerCamera.SetActive(photonView.IsMine);
        nameText.text = photonView?.Owner.NickName;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerRed();

        ReverseMovePlayerInAxe_x();

        if (!photonView.IsMine) return;
        ProcessInputs();
        MovePlayerInAxe_x();
    }




    public void PlayerRed()
    {
        // ???????????????? ???? 
        if (photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isRed = true;
            }
            else
            {
                isRed = false;
            }
        }

        // ??????????? ????????? ?? ?????? 
        if (isRed)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }


    public void SetName(string name)
    {
        nameText.text = name;
    }
    private void ProcessInputs()
    {
        // if (!photonView.IsMine) return;
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    public void MovePlayerInAxe_x()
    {
        // if (!photonView.IsMine) return;

        Vector2 velocity = playerRigidbody.velocity;

        velocity.x = Input.GetAxis("Horizontal") * (float)moveSpeed; /*Debug.Log(velocity.x);*/

        playerRigidbody.velocity = velocity;

        animator.SetFloat("Speed2", Mathf.Abs(Input.GetAxis("Horizontal"))); /*Debug.Log(Mathf.Abs(Input.GetAxis("Horizontal")));*/
    }
    public void ReverseMovePlayerInAxe_x()
    {
        
        if (photonView.IsMine)
        {
            if (transform.localScale.x < 0)
            {
                if (Input.GetAxis("Horizontal") < 0)
                {
                    transform.localScale = Vector3.one;
                }

                directionNameText = false;
            }
            else
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }

                directionNameText = true;
            }
        }
        DirectionNameText(directionNameText);
    }
    public void DirectionNameText(bool direction)
    {
        if (direction == false)
        {
            nameTextObj.transform.localScale = new Vector3(-0.01f, 0.01f, 1);
        }
        else
        {
            nameTextObj.transform.localScale = new Vector3(0.01f, 0.01f, 1);
        }
    }
    // ??? ????? ??? ??????? ???????? ?? ???? ??? ????????? ???????
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // stream.SendNext(transform.position);
            stream.SendNext(isRed);
            stream.SendNext(directionNameText);
        }
        else
        {
            // smoothMove = (Vector3)stream.ReceiveNext();
            isRed = (bool)stream.ReceiveNext();
            directionNameText = (bool)stream.ReceiveNext();
        }
    }
}



