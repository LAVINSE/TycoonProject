using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

#region 종류
/** 배경음 종류 */
public enum BGMEnum
{
    
}

/** 효과음 종류 */
public enum SFXEnum
{
    
}
#endregion // 종류

public class AudioManager : CSingleton<AudioManager>
{
    #region 변수
    [Header("=====> 배경음 설정 <=====")]
    [Tooltip(" 배경음 등록 ")][SerializeField] private AudioClip[] BGMClips; // 배경음
    [Space]
    [Tooltip(" 0 ~ 1 ")][SerializeField] private float BGMVolume = 0.0f; // 배경음 음량

    [Header("=====> 효과음 설정 <=====")]
    [Tooltip(" 효과음 등록 ")][SerializeField] private AudioClip[] SFXClips; // 효과음
    [Space]
    [Tooltip(" 0 ~ 1 ")][SerializeField] private float SFXVolume = 0.0f; // 효과음 음량
    [Tooltip(" 효과음 채널 개수 ")][SerializeField] private int SFXChannel = 0;

    private AudioSource[] BGMPlayers;
    private AudioSource[] SFXPlayers;
    private int ChannelIndex;
    #endregion // 변수

    #region 프로퍼티
    public float oBGMVolume => BGMVolume;
    public float oSFXVolume => SFXVolume;
    #endregion // 프로퍼티

    #region 함수
    /** 초기화 */
    public override void Awake()
    {
        base.Awake();

        BGMInit();
        SFXInit();
    }

    /** 배경음을 세팅한다 */
    private void BGMInit()
    {
        GameObject BGMObject = new GameObject("BGMPlayer");
        BGMObject.transform.parent = this.transform;
        BGMPlayers = new AudioSource[BGMClips.Length];

        for (int i = 0; i < BGMPlayers.Length; i++)
        {
            BGMPlayers[i] = BGMObject.AddComponent<AudioSource>();
            BGMPlayers[i].playOnAwake = false;
            BGMPlayers[i].loop = true;
            BGMPlayers[i].volume = BGMVolume;
            BGMPlayers[i].clip = BGMClips[i];
        }
    }

    /** 효과음을 세팅한다 */
    private void SFXInit()
    {
        GameObject SFXObject = new GameObject("SFXPlayer");
        SFXObject.transform.parent = this.transform;
        SFXPlayers = new AudioSource[SFXChannel];

        for (int i = 0; i < SFXPlayers.Length; i++)
        {
            SFXPlayers[i] = SFXObject.AddComponent<AudioSource>();
            SFXPlayers[i].playOnAwake = false;
            SFXPlayers[i].volume = SFXVolume;
        }
    }

    /** 효과음을 재생한다 */
    public void PlaySFX(SFXEnum SFXType)
    {
        for (int i = 0; i < SFXPlayers.Length; i++)
        {
            int LoopIndex = (i + ChannelIndex) % SFXPlayers.Length;

            // 효과음이 재생중일 경우
            if (SFXPlayers[LoopIndex].isPlaying)
            {
                // 현재 재생중인 효과음이 끊기지 않게 설정
                continue;
            }

            ChannelIndex = LoopIndex;
            SFXPlayers[LoopIndex].clip = SFXClips[(int)SFXType];
            SFXPlayers[LoopIndex].Play();

            // 반복문 종료
            break;
        }
    }

    /** 배경음을 재생한다 */
    public void PlayBGM(BGMEnum BGMType)
    {
        for (int i = 0; i < BGMPlayers.Length; i++)
        {
            // 배경음이 재생중일 경우
            if (BGMPlayers[i].isPlaying)
            {
                // 현재 재생중인 배경음 종료
                BGMPlayers[i].Stop();
                continue;
            }

            BGMPlayers[i].clip = BGMClips[(int)BGMType];
            BGMPlayers[i].Play();

            // 반복문 종료
            break;
        }
    }

    /** 배경음을 멈춘다 */
    public void StopBGM()
    {
        for (int i = 0; i < BGMPlayers.Length; i++)
        {
            // 배경음이 재생중일 경우
            if (BGMPlayers[i].isPlaying)
            {
                BGMPlayers[i].Stop();
            }
        }
    }

    /** 효과음 볼륨을 세팅한다 */
    public void SFXSettingVolume(float SFXVolume)
    {
        for (int i = 0; i < SFXPlayers.Length; i++)
        {
            SFXPlayers[i].volume = SFXVolume;
        }
    }

    /** 배경음 볼륨을 세팅한다 */
    public void BGMSettingVolume(float BGMVolume)
    {
        for (int i = 0; i < BGMPlayers.Length; i++)
        {
            BGMPlayers[i].volume = BGMVolume;
        }
    }
    #endregion // 함수
}
