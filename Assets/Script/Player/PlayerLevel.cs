using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerLevel : MonoBehaviour
{
    public int playerLevel;
    public int playerExp;
    public int ind;

    #region �Լ�
    /** ����ġ ȹ�� */
    public void GainExp(int expAmount)
    {
        playerExp += expAmount;
        CheckForLevel();
    }

    /** ����ġ ȹ�淮�� ���� ���� üũ */
    private void CheckForLevel()
    {
        while (true)
        {
            // �������� ����ġ �䱸�� ��������
            int requiredExp = DataManager.Inst.GetExpForLevel(playerLevel + 1);
            ind = DataManager.Inst.GetExpForLevel(playerLevel + 1);

            if (requiredExp == 0) { break; }
            if (playerExp < requiredExp) { break; }

            // �÷��̾� ����ġ�� ���������� �ʿ��� ����ġ�� ����� ���
            if (playerExp >= requiredExp)
            {
                Levelup();
            }

            playerExp -= requiredExp;
        }
    }

    /** ���� ���� */
    private void Levelup()
    {
        playerLevel++;
        // TODO : ���� ������ �����ϴ� ����? PlayerStats.()
        Debug.Log("������");
    }
    #endregion // �Լ�
}
