using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int currencyCount; //����� ���������� �����
    int clickValue = 1;                 //��������� ���� �������
    public Text currencyText;
    public Text upgradeCostText;
    public Text upgradeCostText1;
    public Text upgradeCostAuto;
    public Text upgradeCostAuto1;
    public Text clickPower;
    public Text autoClickPower;

    int autoClickUpgradeCost = 100; // ��������� ��������� ���������
    int autoClickUpgradeCost1 = 500;  //��������� ��������� ������� ���������.
    int autoClickValue = 0; // ���������� ������, ���������� �� ���������
    float autoClickInterval = 1.0F; // �������� (� ��������) ����� ��������������� �������

    bool autoClickEnabled; // ����, �����������, ������� �� ��������
    float autoClickTimer = 1.0F; // ������ ��� ������� ��������� ����������
    public GameObject button;
    public GameObject effect;


    public void ButtonClick()
    {

        currencyCount += clickValue; //��������� ������ �� ���������� ���� �����
        Instantiate(effect, button.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
        button.GetComponent<RectTransform>().localScale = new Vector3(0.95f, 0.95f, 0f);
    }

    public void OnClickUp()
    {
        button.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 0f);
    }

    private void Start()
    {


        autoClickEnabled = false;
        autoClickTimer = autoClickInterval;
    }

    public void BuyAutoClickUpgrade()
    {
        if (currencyCount >= autoClickUpgradeCost)
        {


            currencyCount -= autoClickUpgradeCost; // �������� ��������� ��������� �� ������
            autoClickUpgradeCost *= 2; //����������� ��������� ������� ��������� 
            autoClickEnabled = true; // �������� ��������
            autoClickValue++; //����������� ���� ���������
            
        }
    }

    public void BuyAutoClickUpgrade1()
    {
        if (currencyCount >= autoClickUpgradeCost1)
        {
            currencyCount -= autoClickUpgradeCost1; // �������� ��������� ��������� �� ������
            autoClickUpgradeCost1 *= 2; //���������� ��������� ������� ���������
            autoClickEnabled = true; // �������� ��������
            autoClickValue += 10; //����������� ���� ���������
        }
    }



        int upgradeCost = 10; //��������� ��������� ���������
        int upgradeValue = 5; //����������� ���� ����� �� 5
        int upgradeCost1 = 50; //��������� ��������� ������� ���������
        int upgradeValue1 = 15; //����������� ���� ����� �� 15

        public void OnUpgradeClick()
        {
            if (currencyCount >= upgradeCost) //��������� ���������� ����� � ��������� �����
            {
                currencyCount -= upgradeCost; // ��������� ��������� �����
                upgradeCost *= 2; // ��������� ��������� ������� ���������
                clickValue += upgradeValue; //���������� ���� �����
            }
        }


    public void OnUpgradeClick1()
    {
        if (currencyCount >= upgradeCost1)
        {
            currencyCount -= upgradeCost1;
            upgradeCost1 *= 2; // ��������� ��������� ������� ���������
            clickValue += upgradeValue1;
         
        }
    }

    void Update()
        {
        currencyText.text = currencyCount.ToString() + "$";             //���������� ��������� ���������� �������� �������� � ��������� � ��������� ���
        upgradeCostAuto.text = autoClickUpgradeCost.ToString() + "$";
        upgradeCostAuto1.text = autoClickUpgradeCost1.ToString() + "$";
        upgradeCostText1.text = upgradeCost1.ToString() + "$";
        upgradeCostText.text = upgradeCost.ToString() + "$";
        clickPower.text = clickValue.ToString() + "/c";
        autoClickPower.text = autoClickValue.ToString() + "/sec";


        if (autoClickEnabled == true)
          {
            autoClickTimer -= Time.deltaTime; // ��������� ������

            if (autoClickTimer <= 0)
            {
                autoClickTimer = autoClickInterval; // ���������� ������

                currencyCount += autoClickValue; // ��������� ������
            }
          }
        }




}
