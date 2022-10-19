using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostActivate : MonoBehaviour
{
    private Player _player;
    private void Start()
    {
        _player = GetComponent<Player>();
    }

    public void SpeedBoost(float activeTime, float speedCoefX, float speedCoefY)
    {
        var coroutine = ActiveSpeedBoost(activeTime, speedCoefX, speedCoefY);
        StartCoroutine(coroutine);
    }
    public void ShotgunBoost(float activeTime)
    {
        var coroutine = ActiveShotgunBoost(activeTime);
        StartCoroutine(coroutine);
    }
    
    public IEnumerator ActiveSpeedBoost(float activeTime, float speedCoefX, float speedCoefY)
    {
        _player.ChangeSpeed(speedCoefX, speedCoefY);
        yield return new WaitForSeconds(activeTime);
        _player.ChangeSpeed(1f / speedCoefX, 1f / speedCoefY);
    }
    
    public IEnumerator ActiveShotgunBoost(float activeTime)
    {
        _player.ChangeShotgunActive(+1);
        yield return new WaitForSeconds(activeTime);
        _player.ChangeShotgunActive(-1);
    }
}
