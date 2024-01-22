using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

#region ����
/** ����� ���� */
public enum BGMEnum
{
    
}

/** ȿ���� ���� */
public enum SFXEnum
{
    
}
#endregion // ����

public class AudioManager : CSingleton<AudioManager>
{
    #region ����
    [Header("=====> ����� ���� <=====")]
    [Tooltip(" ����� ��� ")][SerializeField] private AudioClip[] BGMClips; // �����
    [Space]
    [Tooltip(" 0 ~ 1 ")][SerializeField] private float BGMVolume = 0.0f; // ����� ����

    [Header("=====> ȿ���� ���� <=====")]
    [Tooltip(" ȿ���� ��� ")][SerializeField] private AudioClip[] SFXClips; // ȿ����
    [Space]
    [Tooltip(" 0 ~ 1 ")][SerializeField] private float SFXVolume = 0.0f; // ȿ���� ����
    [Tooltip(" ȿ���� ä�� ���� ")][SerializeField] private int SFXChannel = 0;

    private AudioSource[] BGMPlayers;
    private AudioSource[] SFXPlayers;
    private int ChannelIndex;
    #endregion // ����

    #region ������Ƽ
    public float oBGMVolume => BGMVolume;
    public float oSFXVolume => SFXVolume;
    #endregion // ������Ƽ

    #region �Լ�
    /** �ʱ�ȭ */
    public override void Awake()
    {
        base.Awake();

        BGMInit();
        SFXInit();
    }

    /** ������� �����Ѵ� */
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

    /** ȿ������ �����Ѵ� */
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

    /** ȿ������ ����Ѵ� */
    public void PlaySFX(SFXEnum SFXType)
    {
        for (int i = 0; i < SFXPlayers.Length; i++)
        {
            int LoopIndex = (i + ChannelIndex) % SFXPlayers.Length;

            // ȿ������ ������� ���
            if (SFXPlayers[LoopIndex].isPlaying)
            {
                // ���� ������� ȿ������ ������ �ʰ� ����
                continue;
            }

            ChannelIndex = LoopIndex;
            SFXPlayers[LoopIndex].clip = SFXClips[(int)SFXType];
            SFXPlayers[LoopIndex].Play();

            // �ݺ��� ����
            break;
        }
    }

    /** ������� ����Ѵ� */
    public void PlayBGM(BGMEnum BGMType)
    {
        for (int i = 0; i < BGMPlayers.Length; i++)
        {
            // ������� ������� ���
            if (BGMPlayers[i].isPlaying)
            {
                // ���� ������� ����� ����
                BGMPlayers[i].Stop();
                continue;
            }

            BGMPlayers[i].clip = BGMClips[(int)BGMType];
            BGMPlayers[i].Play();

            // �ݺ��� ����
            break;
        }
    }

    /** ������� ����� */
    public void StopBGM()
    {
        for (int i = 0; i < BGMPlayers.Length; i++)
        {
            // ������� ������� ���
            if (BGMPlayers[i].isPlaying)
            {
                BGMPlayers[i].Stop();
            }
        }
    }

    /** ȿ���� ������ �����Ѵ� */
    public void SFXSettingVolume(float SFXVolume)
    {
        for (int i = 0; i < SFXPlayers.Length; i++)
        {
            SFXPlayers[i].volume = SFXVolume;
        }
    }

    /** ����� ������ �����Ѵ� */
    public void BGMSettingVolume(float BGMVolume)
    {
        for (int i = 0; i < BGMPlayers.Length; i++)
        {
            BGMPlayers[i].volume = BGMVolume;
        }
    }
    #endregion // �Լ�
}
