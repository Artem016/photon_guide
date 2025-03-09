using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject _playerPref;

    void Start()
    {
        //����� ����������� � ������� ������ �� �������� ���������� � ����� ������������ Photon
        PhotonNetwork.ConnectUsingSettings();
    }

    /// <summary>
    /// ����� ������ ������
    /// </summary>
    private void SpawnPlayer()
    {
        //�������� ������ ������ �������� ��������� � ����� Resources
        var player = PhotonNetwork.Instantiate(_playerPref.name, Vector2.zero, Quaternion.identity);

        //��������� ����������� ���������� �������. (���� ������ ��������� ����� ���������� �������, �� ��� ������ ����� ��������� ��� �������)
        player.GetComponent<CharacterController2D>().enabled = true;
    }

    //���������� ����� Photon ������� ���������� ��� ����������� � �������
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.Log("OnConnected");
        //����� ��� �������� ��� ����������� � ������� � ��������� testroom
        PhotonNetwork.JoinOrCreateRoom("testroom", null, null);
    }

    //���������� ����� Photon ������� ���������� ��� ������������� � �������
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log("OnJoined");
        SpawnPlayer();
    }

}
