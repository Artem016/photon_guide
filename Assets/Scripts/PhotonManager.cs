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
        //метод подключения к серверу исходя из настроек прописаных в файле конфигурации Photon
        PhotonNetwork.ConnectUsingSettings();
    }

    /// <summary>
    /// Метод спавна игрока
    /// </summary>
    private void SpawnPlayer()
    {
        //создание игрока префаб которого находится в папке Resources
        var player = PhotonNetwork.Instantiate(_playerPref.name, Vector2.zero, Quaternion.identity);

        //включение возможности управление игроком. (если данный компонент будте изначально включен, то все игроки смогу управлять эти игроком)
        player.GetComponent<CharacterController2D>().enabled = true;
    }

    //встроенный метод Photon который вызывается при подключении к серверу
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.Log("OnConnected");
        //метод для создание или подключения к комнате с названием testroom
        PhotonNetwork.JoinOrCreateRoom("testroom", null, null);
    }

    //встроенный метод Photon который вызывается при присоединении к комнате
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log("OnJoined");
        SpawnPlayer();
    }

}
