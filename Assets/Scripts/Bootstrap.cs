using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private YandexGame _yandexGame;

    private void Awake()
    {
        _yandexGame._GameReadyAPI();
    }
}
