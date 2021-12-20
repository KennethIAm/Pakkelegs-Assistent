using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Club_Pakkelegs_Assistent
{
    public class PresentSnatcher
    {
        //string _testUrl = "https://n-club.dk/klubben/pakkeleg/";

        //IWebDriver _edgeDriver;
        //IWebElement _diceButton;
        //IWebElement _buyRollsButton;
        //List<IWebElement> _presentOwners = new List<IWebElement>();
        //IWebElement _coins;
        //IWebElement _rollsDiv;
        //IWebElement _presentButton;
        //DefaultWait<IWebDriver> _wait;

        //public string StealPresent(string user, int desiredAmount)
        //{
        //    try
        //    {
        //        _edgeDriver = new EdgeDriver(@".\Drivers");
        //        _wait = new WebDriverWait(_edgeDriver, TimeSpan.FromSeconds(10));

        //        _edgeDriver.Url = _testUrl;

        //        _coins = _wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/table/tbody/tr[153]/td[2]/text()")));
        //        _rollsDiv = _wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/table/tbody/tr[242]/td[2]/text()[2]")));



        //        int elementNumber = 249;
        //        while (_wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/table/tbody/tr[" + elementNumber + "]/td[2]/text()"))) != null)
        //        {
        //            _presentOwners.Add(_wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/table/tbody/tr[" + elementNumber + "]/td[2]/text()"))));

        //            elementNumber = elementNumber + 3;
        //        }

        //        int currentAmountOfCoins;
        //        int.TryParse(_coins.Text, out currentAmountOfCoins);

        //        if (_rollsDiv.Text == "0" && currentAmountOfCoins >= 5)
        //        {
        //            BuyRolls();
        //        }
        //        else if (_rollsDiv.Text != "0")
        //        {
        //            RollDice();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
            

        //    return "";
        //}

        //private void RollDice()
        //{
        //    _diceButton = _wait.Until(ExpectedConditions.ElementExists(By.Name("roll_dice")));
        //    _diceButton.Click();
        //}

        //private void BuyRolls()
        //{
        //    _buyRollsButton = _wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/table/tbody/tr[305]/td[2]/span/span[6]")));
        //    _buyRollsButton.Click();
        //}
    }
}
