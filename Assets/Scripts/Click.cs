using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int currencyCount; //Общее количество денег
    int clickValue = 1;                 //Начальная сила нажатия
    public Text currencyText;
    public Text upgradeCostText;
    public Text upgradeCostText1;
    public Text upgradeCostAuto;
    public Text upgradeCostAuto1;
    public Text clickPower;
    public Text autoClickPower;

    int autoClickUpgradeCost = 100; // Стоимость улучшения автоклика
    int autoClickUpgradeCost1 = 500;  //Стоимость улучшения второго автоклика.
    int autoClickValue = 0; // Количество валюты, получаемой от автоклика
    float autoClickInterval = 1.0F; // Интервал (в секундах) между автоматическими кликами

    bool autoClickEnabled; // Флаг, указывающий, включен ли автоклик
    float autoClickTimer = 1.0F; // Таймер для отсчета интервала автокликов
    public GameObject button;
    public GameObject effect;


    public void ButtonClick()
    {

        currencyCount += clickValue; //Получение деньги на количество силы клика
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


            currencyCount -= autoClickUpgradeCost; // Вычитаем стоимость улучшения из валюты
            autoClickUpgradeCost *= 2; //Увеличиваем стоимость покупки улучшения 
            autoClickEnabled = true; // Включаем автоклик
            autoClickValue++; //Увеличиваем силу автоклика
            
        }
    }

    public void BuyAutoClickUpgrade1()
    {
        if (currencyCount >= autoClickUpgradeCost1)
        {
            currencyCount -= autoClickUpgradeCost1; // Вычитаем стоимость улучшения из валюты
            autoClickUpgradeCost1 *= 2; //Увеличение стоимости покупки улучшения
            autoClickEnabled = true; // Включаем автоклик
            autoClickValue += 10; //Увеличиваем силу автоклика
        }
    }



        int upgradeCost = 10; //Начальная стоимость улучшения
        int upgradeValue = 5; //Увеличивает силу клика на 5
        int upgradeCost1 = 50; //Начальная стоимость второго улучшения
        int upgradeValue1 = 15; //Увеличивает силу клика на 15

        public void OnUpgradeClick()
        {
            if (currencyCount >= upgradeCost) //Сравнение количества денег и стоимости клика
            {
                currencyCount -= upgradeCost; // Вычитание стоимости клика
                upgradeCost *= 2; // Увеличьте стоимость каждого улучшения
                clickValue += upgradeValue; //Увеличение силы клика
            }
        }


    public void OnUpgradeClick1()
    {
        if (currencyCount >= upgradeCost1)
        {
            currencyCount -= upgradeCost1;
            upgradeCost1 *= 2; // Увеличьте стоимость каждого улучшения
            clickValue += upgradeValue1;
         
        }
    }

    void Update()
        {
        currencyText.text = currencyCount.ToString() + "$";             //Присовение текстовым переменным значения числовых с переводом в строковый тип
        upgradeCostAuto.text = autoClickUpgradeCost.ToString() + "$";
        upgradeCostAuto1.text = autoClickUpgradeCost1.ToString() + "$";
        upgradeCostText1.text = upgradeCost1.ToString() + "$";
        upgradeCostText.text = upgradeCost.ToString() + "$";
        clickPower.text = clickValue.ToString() + "/c";
        autoClickPower.text = autoClickValue.ToString() + "/sec";


        if (autoClickEnabled == true)
          {
            autoClickTimer -= Time.deltaTime; // Уменьшаем таймер

            if (autoClickTimer <= 0)
            {
                autoClickTimer = autoClickInterval; // Сбрасываем таймер

                currencyCount += autoClickValue; // Добавляем валюту
            }
          }
        }




}
