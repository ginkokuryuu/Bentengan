using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField createInput;
    [SerializeField] TMP_InputField createPass;
    [SerializeField] TMP_InputField joinInput;
    [SerializeField] TMP_InputField joinPass;
    List<RoomInfo> roomInfos = new List<RoomInfo>();

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 2,
        };

        Hashtable roomCustomProps = new Hashtable();
        roomCustomProps.Add("Password", createPass.text);
        roomOptions.CustomRoomProperties = roomCustomProps;
        roomOptions.CustomRoomPropertiesForLobby = new string[] { "Password", };

        PhotonNetwork.CreateRoom(createInput.text, roomOptions);
    }

    public void JoinRoom()
    {
        RoomInfo roomInfo = GetRoomInfo(joinInput.text);

        Debug.Log(PhotonNetwork.CountOfRooms);

        if (roomInfo == null)
            return;

        string password = (string)roomInfo.CustomProperties["Password"];
        
        if(password == joinPass.text)
        {
            PhotonNetwork.JoinRoom(joinInput.text);
        }
        else
        {
            Debug.Log("Password Wrong");
        }
    }

    public RoomInfo GetRoomInfo(string name)
    {
        foreach(RoomInfo roomInfo in roomInfos)
        {
            if (roomInfo.Name == name)
                return roomInfo;
        }
        return null;
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("Room");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        roomInfos = roomList;
    }
}
