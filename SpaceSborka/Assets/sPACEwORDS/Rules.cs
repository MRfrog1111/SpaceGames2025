using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Rules : MonoBehaviour
{
    Button rules;
    string text = "� ������ ������ ��� ������������ ����� ��� ��� ����� ��������� � ����������� ���������. �� ���� ����� ����� ����� ��������� �����, ������ ���� � �� �� ����� ������������ ������. ��� ����� ������ ���� ���������������� � ������������ ������, �� ������������� ������������(���, �����, ��� � �.�.), ����� ����������� (�������� �����, �������, ���, ������� � �.�.).\r\n\r\n����� ��������� �����, ������� ������ �����������, ����� �����, ���� ����� ����������, ���  ����� ��������� � ������ ���������, ������� ����� �� ������. ���� �� ������ ������ ������ �����, ������� ������ ������\r\n\r\n���� ����� ��������� 10% ����, �� �������� 1 ������, 25% - 2 ������, 40% - 3 ������. ����� ������ ����� ������ ��������� ������������� ����� � ����������� ������� ��� �������. \r\n";
    // Start is called before the first frame update
    void Start()
    {
        rules = this.GetComponent<Button>(); 
        rules.onClick.AddListener(() => { AboutIlluminator.ShowMassage(text); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
