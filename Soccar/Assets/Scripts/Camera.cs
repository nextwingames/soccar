﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float _distance = 30f;
    private float _angle = 35f;

    private bool _isFirstRun = true;

    //public static GameObject[] PlayerList
    //{
    //    get
    //    {
    //        return _playerList;
    //    }
    //    set
    //    {
    //        _playerList = value;
    //    }
    //}

    //public static GameObject Player
    //{
    //    get
    //    {
    //        return _player;
    //    }
    //    set
    //    {
    //        _player = value;
    //    }
    //}

    private const int PlayerCount = 4;

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.IsPlayerInitialized && _isFirstRun)
        {
            transform.eulerAngles = new Vector3(_angle, PlayerController.PlayerIndex * 90f, 0);
            _isFirstRun = false;
            Debug.Log("==카메라 세팅됨");
        }
        if (!_isFirstRun)
        {
            // 카메라의 position을 실시간으로 업데이트함
            ChangeCameraView();
        }
    }

    void ChangeCameraView()
    {
        // 해당하는 플레이어에 따라 카메라의 위치가 달라진다.
        /* 카메라는 플레이어로 부터 _distance만큼 떨어져 있으며(플레이어마다 X or Z) 높이(Y)는 _distance이다.
            또한 _angle 만큼 아래를 쳐다보고 있으며 해당 플레이어가 오른쪽으로 위치하도록 Rotation.Y 값을 조정한다. */
        switch(PlayerController.PlayerIndex)
        {
            case 0:
                transform.transform.position = new Vector3(PlayerController.Player.transform.position.x, _distance, PlayerController.Player.transform.position.z - _distance);
                transform.eulerAngles = new Vector3(_angle, PlayerController.PlayerIndex * 90f, 0);
                break;
            case 1:
                transform.transform.position = new Vector3(PlayerController.Player.transform.position.x - _distance, _distance, PlayerController.Player.transform.position.z);
                transform.eulerAngles = new Vector3(_angle, PlayerController.PlayerIndex * 90f, 0);
                break;
            case 2:
                transform.transform.position = new Vector3(PlayerController.Player.transform.position.x, _distance, PlayerController.Player.transform.position.z + _distance);
                transform.eulerAngles = new Vector3(_angle, PlayerController.PlayerIndex * 90f, 0);
                break;
            case 3:
                transform.transform.position = new Vector3(PlayerController.Player.transform.position.x + _distance, _distance, PlayerController.Player.transform.position.z);
                transform.eulerAngles = new Vector3(_angle, PlayerController.PlayerIndex * 90f, 0);
                break;
        }
    }
}
