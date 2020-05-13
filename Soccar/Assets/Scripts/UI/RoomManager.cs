﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room
{
    public string Name { get; private set; }
    public int Headcount { get; private set; }

    public Room(string name, int headcount)
    {
        Name = name;
        Headcount = headcount;
    }
}

public class RoomManager
{
    public List<Room> Rooms { get; private set; }
    private GameObject _roomList;

    public const int MaxRoomCount = 5;

    public RoomManager(GameObject roomList)
    {
        _roomList = roomList;
    }

    // 대기방 정보 업데이트
    public void SetRoomInfo(Packet.ReceivingRoomList receivingRoomList)
    {
        Rooms = new List<Room>();

        int roomCount = receivingRoomList.RoomNames.Length;
        for(int i = 0; i < roomCount; i++)
        {
            Rooms.Add(new Room(receivingRoomList.RoomNames[i], receivingRoomList.Headcounts[i]));
        }

        ShowRoomList(true);
    }

    // UI에 업데이트
    public void ShowRoomList(bool isUpdate)
    {
        for(int i = 0; i < MaxRoomCount; i++)
        {
            GameObject room = _roomList.transform.Find("Room" + i).gameObject;

            // 위치 및 크기만 재조정
            if(!isUpdate)
            {
                room.transform.localPosition = new Vector3(0, -Screen.height / (MaxRoomCount + 1) * (i + 1), 0);
                room.transform.localScale = new Vector3(Screen.height / 376f, Screen.height / 376f, 1);

                continue;
            }

            Text index = room.transform.Find("Room Index").gameObject.GetComponent<Text>();
            Text name = room.transform.Find("Room Name").gameObject.GetComponent<Text>();
            Text headcount = room.transform.Find("Room Headcount").gameObject.GetComponent<Text>();

            if(i >= Rooms.Count)
            {
                index.text = "";
                name.text = "";
                headcount.text = "";

                continue;
            }

            index.text = (i + 1).ToString();
            name.text = Rooms[i].Name;
            headcount.text = Rooms[i].Headcount.ToString();
        }
    }
}