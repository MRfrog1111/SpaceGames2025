using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DialogueSystem : MonoBehaviour
{
    public SteamVR_Input_Sources inputSource; // �������� ����������, � ������� ������ �����������������
    public SteamVR_Action_Boolean selectAction; // ������� ������ ��� ������ � ���������� �������

    private void Update()
    {
        if (selectAction[inputSource].stateDown)
        {
            // ��������� ������ � ���������� �������
            // ��������, ����� ������������ ��������� ����� ��� ���������� ������ � ����������� �� ������ ������
            Debug.Log("����� ������!");
        }
    }
}