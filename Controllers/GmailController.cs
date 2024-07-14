using faCodeAndImap.Models;
using Faker;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace faCodeAndImap.Controllers
{
    public class GmailController
    {
        Utils utils = new Utils();
        public void randomTime(int mixSleep, int maxSleep)
        {
            int rdn = Faker.RandomNumber.Next(mixSleep, maxSleep);
            Thread.Sleep(rdn * 1000);
        }

        public bool checkLoginAccount(WebDriver driver)
        {
            if (driver.Url.Contains("https://accounts.google.com/v3/signin/"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string LoginAccount(WebDriver driver, string username, string password, string mailKp, int mixSleep, int maxSleep)
        {
            string statusLogin = string.Empty;
            try
            {
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                driverWait.Until(ExpectedConditions.ElementExists(By.Id("identifierId"))).Click();
                Thread.Sleep(5000);
                _ = driver.Manage().Timeouts().ImplicitWait;
                bool nhapUserName = false;
                int soLanLap = 0;
                while (!nhapUserName)
                {
                    if (soLanLap == 3)
                    {
                        break;
                    }
                    else if (soLanLap != 0)
                    {
                        driverWait.Until(ExpectedConditions.ElementExists(By.Id("identifierId"))).Clear();
                    }
                    Thread.Sleep(4000);
                    for (int i = 0; i < username.Length; i++)
                    {
                        char c = username[i];
                        new Actions(driver).SendKeys(c.ToString()).Build().Perform();
                        Thread.Sleep(200);
                    }
                    Thread.Sleep(4000);
                    IWebElement elementNext = driver.FindElement(By.Id("identifierNext"));
                    driver.ExecuteScript("arguments[0].click();", elementNext);
                    randomTime(mixSleep, maxSleep);
                    _ = driver.Manage().Timeouts().ImplicitWait;
                    IWebElement element1 = null;
                    try
                    {
                        element1 = driver.FindElement(By.XPath("//div[@class='Ekjuhf Jj6Lae']"));
                        if (element1 != null)
                        {
                            nhapUserName = false;
                        }
                    }
                    catch { }
                    if (element1 == null)
                    {
                        nhapUserName = true;
                    }
                    soLanLap++;
                }
                if (!nhapUserName)
                {
                    statusLogin = "Sai UserName";
                }
                driverWait.Until(ExpectedConditions.ElementExists(By.Name("Passwd"))).Click();
                Thread.Sleep(5000);
                bool nhapPassWord = false;
                soLanLap = 0;
                while (!nhapPassWord)
                {
                    if (soLanLap == 3)
                    {
                        break;
                    }
                    else if (soLanLap != 0)
                    {
                        driverWait.Until(ExpectedConditions.ElementExists(By.Name("Passwd"))).Clear();
                    }
                    Thread.Sleep(4000);
                    for (int i = 0; i < password.Length; i++)
                    {
                        char c = password[i];
                        new Actions(driver).SendKeys(c.ToString()).Build().Perform();
                        Thread.Sleep(200);
                    }
                    Thread.Sleep(2000);
                    IWebElement element = driver.FindElement(By.Id("passwordNext"));
                    driver.ExecuteScript("arguments[0].click();", element);
                    Thread.Sleep(5000);
                    randomTime(mixSleep, maxSleep);
                    _ = driver.Manage().Timeouts().ImplicitWait;
                    IWebElement element1 = null;
                    try
                    {
                        element1 = driver.FindElement(By.XPath("//div[@jsname='B34EJ']"));
                        if (element1 != null)
                        {
                            nhapPassWord = false;
                        }
                    }
                    catch { }
                    if (element1 == null)
                    {
                        nhapPassWord = true;
                    }
                    soLanLap++;
                }
                if (!nhapPassWord)
                {
                    statusLogin = "Sai Password";
                }
                try
                {
                    WebDriverWait driverWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    driverWait1.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='l5PPKe']")));
                    List<IWebElement> webElements = driver.FindElements(By.XPath("//div[@class='l5PPKe']")).Cast<IWebElement>().ToList();
                    foreach(IWebElement webElement in webElements)
                    {
                        if(webElement.Text.Contains("Xác nhận email khôi phục của bạn"))
                        {
                            driver.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                            Thread.Sleep(2000);
                            driver.ExecuteScript("arguments[0].click();", webElement);
                            break;
                        }
                    }
                    Thread.Sleep(1000);
                    bool nhapEmailKP = false;
                    soLanLap = 0;
                    while (!nhapEmailKP)
                    {
                        if (soLanLap == 3)
                        {
                            break;
                        }
                        else if (soLanLap != 0)
                        {
                            driverWait.Until(ExpectedConditions.ElementExists(By.Id("knowledge-preregistered-email-response"))).Clear();
                            Thread.Sleep(1000);
                        }
                        driverWait.Until(ExpectedConditions.ElementExists(By.Id("knowledge-preregistered-email-response"))).Click();
                        Thread.Sleep(4000);
                        for (int i = 0; i < mailKp.Length; i++)
                        {
                            char c = mailKp[i];
                            new Actions(driver).SendKeys(c.ToString()).Build().Perform();
                            Thread.Sleep(200);
                        }
                        Thread.Sleep(2000);
                        driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='VfPpkd-vQzf8d']")));
                        List<IWebElement> webElementsBtn = driver.FindElements(By.XPath("//span[@class='VfPpkd-vQzf8d']")).Cast<IWebElement>().ToList();
                        foreach (IWebElement webElement in webElementsBtn)
                        {
                            if (webElement.Text.Contains("Tiếp theo"))
                            {
                                driver.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                                Thread.Sleep(2000);
                                driver.ExecuteScript("arguments[0].click();", webElement);
                                break;
                            }
                        }
                        randomTime(mixSleep, maxSleep);
                        _ = driver.Manage().Timeouts().ImplicitWait;
                        IWebElement element1 = null;
                        try
                        {
                            element1 = driver.FindElement(By.Id("knowledge-preregistered-email-response"));
                            if (element1 != null)
                            {
                                nhapPassWord = false;
                            }
                        }
                        catch { }
                        if (element1 == null)
                        {
                            nhapEmailKP = true;
                        }
                        soLanLap++;
                    }
                }
                catch { }
                int k = 0;
                bool isLogin = false;
                while (!isLogin)
                {
                    if (k == 60)
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                    IWebElement webElement = null;
                    try
                    {
                        string signedIn = driver.FindElement(By.XPath("//div[@class='DRfwgc shUNU']")).Text;
                        if (signedIn.Contains("You’re signed in"))
                        {
                            isLogin = true;
                            driver.Navigate().GoToUrl("https://mail.google.com/mail/");
                            _ = driver.Manage().Timeouts().ImplicitWait;
                        }
                    }
                    catch { }
                    if (!driver.Url.Contains("https://accounts.google.com/v3/signin/"))
                    {
                        isLogin = true;
                    }
                    if (driver.Url.Contains("https://accounts.google.com/v3/signin/challenge/ipp"))
                    {
                        isLogin = false;
                        break;
                    }
                    k++;
                }
                if (!isLogin)
                {
                    statusLogin = "Login Error";
                }
                else
                {
                    statusLogin = "success";
                }
                return statusLogin;
            }
            catch (Exception err)
            {
                utils.WriteLogError(err.Message.ToString());
                return statusLogin;
            }
        }

        public bool enableIMapAndPOP(WebDriver driver)
        {
            bool isSuccess = false;
            try
            {
                driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/?tab=rm&ogbl#settings/fwdandpop");
                _ = driver.Manage().Timeouts().ImplicitWait;
                Thread.Sleep(2000);
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                try
                {
                    IWebElement element = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='nH bkK']")));
                    Thread.Sleep(5000);
                    driver.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                    if (element != null)
                    {
                        driverWait.Until(ExpectedConditions.ElementExists(By.Name("bx_pe")));
                        Thread.Sleep(2000);
                        List<IWebElement> listRadioBtn = element.FindElements(By.Name("bx_pe")).Cast<IWebElement>().ToList();
                        foreach (IWebElement radioBtn in listRadioBtn)
                        {
                            if (radioBtn.GetAttribute("value").Equals("3"))
                            {
                                driver.ExecuteScript("arguments[0].scrollIntoView(true);", radioBtn);
                                Thread.Sleep(2000);
                                driver.ExecuteScript("arguments[0].click();", radioBtn);
                                break;
                            }
                        }

                    }
                }
                catch { }
                Thread.Sleep(4000);
                try
                {
                    IWebElement element = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='nH bkK']")));
                    if (element != null)
                    {
                        List<IWebElement> listRadioBtn = element.FindElements(By.Name("bx_ie")).Cast<IWebElement>().ToList();
                        foreach (IWebElement radioBtn in listRadioBtn)
                        {
                            if (radioBtn.GetAttribute("value").Equals("1"))
                            {
                                driver.ExecuteScript("arguments[0].scrollIntoView(true);", radioBtn);
                                Thread.Sleep(2000);
                                driver.ExecuteScript("arguments[0].click();", radioBtn);
                                break;
                            }
                        }

                    }
                }
                catch { }
                Thread.Sleep(2000);
                try
                {
                    IWebElement element = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@guidedhelpid='save_changes_button']")));
                    driver.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                    Thread.Sleep(2000);
                    driver.ExecuteScript("arguments[0].click();", element);
                    Thread.Sleep(2000);
                }
                catch { }
                isSuccess = true;
            }
            catch
            {
                Console.WriteLine("Err");
                isSuccess = false;
            }
            return isSuccess;
        }

        public string enable2faAndPasswordPhone(WebDriver driver, string token)
        {
            string isSuccess = string.Empty;
            try
            {
                driver.Navigate().GoToUrl("https://myaccount.google.com/security");
                _ = driver.Manage().Timeouts().ImplicitWait;
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                try
                {
                    IWebElement element = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//a[@aria-label='2-Step Verification']")));
                    if (element != null)
                    {
                        driver.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                        Thread.Sleep(2000);
                        driver.ExecuteScript("arguments[0].click();", element);
                        Thread.Sleep(10000);
                        try
                        {
                            if (driver.Url.Contains("https://accounts.google.com/v3/signin/challenge/"))
                            {
                                try
                                {
                                    Thread.Sleep(2000);
                                    WebDriverWait driverWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                                    driverWait1.Until(ExpectedConditions.ElementExists(By.Name("Passwd"))).Click();
                                    Thread.Sleep(2000);
                                    element = driverWait1.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='VfPpkd-vQzf8d']")));
                                    List<IWebElement> listNextBtn = driver.FindElements(By.XPath("//span[@class='VfPpkd-vQzf8d']")).Cast<IWebElement>().ToList();
                                    foreach (IWebElement webElement in listNextBtn)
                                    {
                                        if (webElement.Text.Equals("Next"))
                                        {
                                            try
                                            {
                                                driver.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                                                Thread.Sleep(2000);
                                                driver.ExecuteScript("arguments[0].click();", webElement);
                                                break;
                                            }
                                            catch { }
                                        }
                                    }
                                    Thread.Sleep(2000);
                                }
                                catch { }
                            }
                        }
                        catch { }
                        string code = string.Empty;
                        while (string.IsNullOrEmpty(code))
                        {
                            try
                            {
                                element = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='UywwFc-vQzf8d']")));
                                Thread.Sleep(2000);
                                driver.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                                Thread.Sleep(2000);
                                driver.ExecuteScript("arguments[0].click();", element);
                                Thread.Sleep(10000);
                                try
                                {
                                    if (driver.Url.Contains("https://accounts.google.com/v3/signin/challenge/"))
                                    {
                                        try
                                        {
                                            Thread.Sleep(2000);
                                            WebDriverWait driverWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                                            driverWait1.Until(ExpectedConditions.ElementExists(By.Name("Passwd"))).Click();
                                            Thread.Sleep(2000);
                                            element = driverWait1.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='VfPpkd-vQzf8d']")));
                                            List<IWebElement> listNextBtn = driver.FindElements(By.XPath("//span[@class='VfPpkd-vQzf8d']")).Cast<IWebElement>().ToList();
                                            foreach (IWebElement webElement in listNextBtn)
                                            {
                                                if (webElement.Text.Equals("Next"))
                                                {
                                                    try
                                                    {
                                                        driver.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                                                        Thread.Sleep(2000);
                                                        driver.ExecuteScript("arguments[0].click();", webElement);
                                                        break;
                                                    }
                                                    catch { }
                                                }
                                            }
                                            Thread.Sleep(2000);
                                        }
                                        catch { }
                                    }
                                }
                                catch { }
                                Thread.Sleep(2000);
                            }
                            catch { }
                            viOtpController viOtp = new viOtpController();
                            EmploySim employ = viOtp.getEmployService(token).Result;
                            if (employ != null)
                            {
                                try
                                {
                                    WebDriverWait driverWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                                    driverWait1.Until(ExpectedConditions.ElementExists(By.XPath("//input[contains(@aria-label,'Phone input')]"))).Click();
                                }
                                catch{}
                                try
                                {
                                    WebDriverWait driverWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                                    driverWait1.Until(ExpectedConditions.ElementExists(By.XPath("//input[contains(@aria-label,'Enter a phone number')]"))).Click();
                                }
                                catch { }
                                Thread.Sleep(1000);
                                string phone = "+84" + employ.data.phone_number;
                                Thread.Sleep(2000);
                                for (int i = 0; i < phone.Length; i++)
                                {
                                    char c = phone[i];
                                    new Actions(driver).SendKeys(c.ToString()).Build().Perform();
                                    Thread.Sleep(200);
                                }
                                Thread.Sleep(2000);
                                try
                                {
                                    WebDriverWait driverWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                                    element = driverWait1.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='RveJvd snByac']")));
                                    List<IWebElement> listNextBtn = driver.FindElements(By.XPath("//div[@class='U26fgb O0WRkf oG5Srb HQ8yf C0oVfc Zrq4w WIL89 M9Bg4d']/span/span")).Cast<IWebElement>().ToList();
                                    foreach (IWebElement webElement in listNextBtn)
                                    {
                                        string text = webElement.Text;
                                        if (webElement.Text.Equals("NEXT"))
                                        {
                                            try
                                            {
                                                driver.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                                                Thread.Sleep(2000);
                                                driver.ExecuteScript("arguments[0].click();", webElement);
                                                break;
                                            }
                                            catch { }
                                        }
                                    }
                                    Thread.Sleep(2000);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    WebDriverWait driverWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                                    element = driverWait1.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='UywwFc-vQzf8d']")));
                                    List<IWebElement> listNextBtn = driver.FindElements(By.XPath("//span[@class='UywwFc-vQzf8d']")).Cast<IWebElement>().ToList();
                                    foreach (IWebElement webElement in listNextBtn)
                                    {
                                        string text = webElement.Text;
                                        if (webElement.Text.Equals("Next"))
                                        {
                                            try
                                            {
                                                driver.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                                                Thread.Sleep(2000);
                                                driver.ExecuteScript("arguments[0].click();", webElement);
                                                break;
                                            }
                                            catch { }
                                        }
                                    }
                                    Thread.Sleep(2000);
                                }
                                catch { }
                                Thread.Sleep(1000);
                                try
                                {
                                    driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[contains(@aria-label,'Enter the ')]"))).Click();
                                }
                                catch { }
                                
                                GetCodeOtp getCode = viOtp.getCodeOtp(token, employ.data.request_id).Result;
                                int soLanLap = 0;
                                while (string.IsNullOrEmpty(getCode.data.Code) && getCode.data.Status != 2)
                                {
                                    if (soLanLap == 50)
                                    {
                                        break;
                                    }
                                    Thread.Sleep(5000);
                                    getCode = viOtp.getCodeOtp(token, employ.data.request_id).Result;
                                }
                                if(getCode.data.Status == 2)
                                {
                                    try
                                    {
                                        driver.Navigate().Refresh();
                                        _ = driver.Manage().Timeouts().ImplicitWait;
                                    }
                                    catch
                                    {

                                    }
                                }
                                else if (!string.IsNullOrEmpty(getCode.data.Code))
                                {
                                    code = getCode.data.Code;
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(code))
                        {
                            Thread.Sleep(2000);
                            foreach (char c in code)
                            {
                                new Actions(driver).SendKeys(c.ToString()).Build().Perform();
                                Thread.Sleep(100);
                            }
                            Thread.Sleep(2000);
                            try
                            {
                                WebDriverWait driverWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                                element = driverWait1.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='RveJvd snByac']")));
                                List<IWebElement> listNextBtn = driver.FindElements(By.XPath("//div[@class='U26fgb O0WRkf oG5Srb HQ8yf C0oVfc Zrq4w WIL89 M9Bg4d']/span/span")).Cast<IWebElement>().ToList();
                                foreach (IWebElement webElement in listNextBtn)
                                {
                                    string text = webElement.Text;
                                    if (webElement.Text.Equals("NEXT"))
                                    {
                                        try
                                        {
                                            driver.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                                            Thread.Sleep(2000);
                                            driver.ExecuteScript("arguments[0].click();", webElement);
                                            break;
                                        }
                                        catch { }
                                    }
                                }
                            }
                            catch
                            {

                            }
                            try
                            {
                                WebDriverWait driverWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                                element = driverWait1.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='UywwFc-vQzf8d']")));
                                List<IWebElement> listNextBtn = driver.FindElements(By.XPath("//span[@class='UywwFc-vQzf8d']")).Cast<IWebElement>().ToList();
                                foreach (IWebElement webElement in listNextBtn)
                                {
                                    string text = webElement.Text;
                                    if (webElement.Text.Equals("Verify"))
                                    {
                                        try
                                        {
                                            driver.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                                            Thread.Sleep(2000);
                                            driver.ExecuteScript("arguments[0].click();", webElement);
                                            break;
                                        }
                                        catch { }
                                    }
                                }
                                Thread.Sleep(2000);
                            }
                            catch { }
                            Thread.Sleep(2000);
                            try
                            {
                                driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='RveJvd snByac']")));
                                List<IWebElement> listNext = driver.FindElements(By.XPath("//div[@class='U26fgb O0WRkf oG5Srb HQ8yf C0oVfc Zrq4w WIL89 M9Bg4d']/span/span")).Cast<IWebElement>().ToList();
                                foreach (IWebElement webElement in listNext)
                                {
                                    string text = webElement.Text;
                                    if (webElement.Text.Contains("TURN ON"))
                                    {
                                        try
                                        {
                                            driver.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                                            Thread.Sleep(2000);
                                            driver.ExecuteScript("arguments[0].click();", webElement);
                                            break;
                                        }
                                        catch { }
                                    }
                                }
                            }
                            catch { }
                            try
                            {
                                element = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='UywwFc-vQzf8d']")));
                                List<IWebElement> listNextBtn = driver.FindElements(By.XPath("//span[@class='UywwFc-vQzf8d']")).Cast<IWebElement>().ToList();
                                foreach (IWebElement webElement in listNextBtn)
                                {
                                    string text = webElement.Text;
                                    if (webElement.Text.Equals("Done"))
                                    {
                                        try
                                        {
                                            driver.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                                            Thread.Sleep(2000);
                                            driver.ExecuteScript("arguments[0].click();", webElement);
                                            break;
                                        }
                                        catch { }
                                    }
                                }
                            }
                            catch { }
                            Thread.Sleep(2000);
                            string url = driver.Url;

                            // Tìm vị trí bắt đầu của dấu ?
                            int startIndex = url.IndexOf("?");

                            if (startIndex != -1)
                            {
                                isSuccess = url.Substring(startIndex);
                            }
                            else
                            {
                                isSuccess = "Err";
                            }
                        }
                        else
                        {
                            Console.WriteLine("Err");
                            isSuccess = "Err";
                        }
                    }
                }
                catch {
                    Console.WriteLine("Err");
                    isSuccess = "Err";
                }
            }
            catch
            {
                Console.WriteLine("Err");
                isSuccess = "Err";
            }
            return isSuccess;
        }

        public string getPasswordApplication(WebDriver driver, string url)
        {
            string passwordApplication = string.Empty;
            try
            {
                driver.Navigate().GoToUrl("https://myaccount.google.com/two-step-verification/authenticator" + url);
                _ = driver.Manage().Timeouts().ImplicitWait;
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                try
                {
                    Thread.Sleep(2000);
                    driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='AeBiU-vQzf8d']"))).Click();
                    Thread.Sleep(2000);
                    driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='mUIrbf-vQzf8d']"))).Click();
                    Thread.Sleep(2000);
                    driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//li[@class='mzEcT']")));
                    List<IWebElement> listName = driver.FindElements(By.XPath("//li[@class='mzEcT']")).Cast<IWebElement>().ToList();
                    Thread.Sleep(2000);
                    foreach (IWebElement li in listName)
                    {
                        string text = li.Text;
                        try
                        {
                            if (text.Contains("Enter your email address and this key (spaces don’t matter):"))
                            {
                                int colonIndex = text.IndexOf(':');

                                // If the ':' character is found, remove everything before it (including the ':')
                                if (colonIndex != -1)
                                {
                                    passwordApplication = text.Substring(colonIndex + 1).Trim();
                                    Console.WriteLine(passwordApplication);
                                }
                            }
                        }
                        catch { }
                    }
                    Thread.Sleep(2000);
                    driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='VfPpkd-vQzf8d']")));
                    listName = driver.FindElements(By.XPath("//span[@class='VfPpkd-vQzf8d']")).Cast<IWebElement>().ToList();
                    Thread.Sleep(2000);
                    foreach (IWebElement btn in listName)
                    {
                        string text = btn.Text;
                        if (text.Contains("Next"))
                        {
                            driver.ExecuteScript("arguments[0].scrollIntoView(true);", btn);
                            Thread.Sleep(2000);
                            driver.ExecuteScript("arguments[0].click();", btn);
                            break;
                        }
                    }
                    Thread.Sleep(2000);
                    string code2FA = getCode2FA(passwordApplication).Result;
                    Thread.Sleep(2000);
                    WebDriverWait driverWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    driverWait1.Until(ExpectedConditions.ElementExists(By.XPath("//input[@placeholder='Enter Code']"))).Click();
                    Thread.Sleep(2000);
                    for (int i = 0; i < code2FA.Length; i++)
                    {
                        char c = code2FA[i];
                        new Actions(driver).SendKeys(c.ToString()).Build().Perform();
                        Thread.Sleep(200);
                    }
                    Thread.Sleep(2000);
                    driverWait1.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='VfPpkd-vQzf8d']")));
                    listName = driver.FindElements(By.XPath("//span[@class='VfPpkd-vQzf8d']")).Cast<IWebElement>().ToList();
                    Thread.Sleep(2000);
                    foreach (IWebElement btn in listName)
                    {
                        string text = btn.Text;
                        if (text.Contains("Verify"))
                        {
                            driver.ExecuteScript("arguments[0].scrollIntoView(true);", btn);
                            Thread.Sleep(2000);
                            driver.ExecuteScript("arguments[0].click();", btn);
                            break;
                        }
                    }
                    Thread.Sleep(2000);
                }
                catch { }
            }
            catch
            {
                passwordApplication = string.Empty;
            }
            Thread.Sleep(1000);
            return passwordApplication;
        }

        public string getAppPassword(WebDriver driver, string url)
        {
            string passwordApplication = string.Empty;
            try
            {
                driver.Navigate().GoToUrl("https://myaccount.google.com/apppasswords" + url);
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                try
                {
                    Thread.Sleep(5000);
                    driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@class='VfPpkd-fmcmS-wGMbrd ']"))).Click();
                    string fakeName = utils.RemoveSpecialCharacters(Faker.Name.First()) + utils.RemoveSpecialCharacters(Faker.Name.Last());
                    foreach(char c in fakeName)
                    {
                        new Actions(driver).SendKeys(c.ToString()).Build().Perform();
                        Thread.Sleep(200);
                    }
                    Thread.Sleep(2000);
                    driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='AeBiU-vQzf8d']"))).Click();
                    Thread.Sleep(2000);
                    IWebElement element = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='lY6Rwe riHXqb']")));
                    if (element != null)
                    {
                        string text = element.Text;
                        Thread.Sleep(2000);
                        passwordApplication = text;
                    }
                    Thread.Sleep(2000);
                    driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='UywwFc-vQzf8d']"))).Click();
                }
                catch { }
            }
            catch
            {
                passwordApplication = string.Empty;
            }
            Thread.Sleep(1000);
            return passwordApplication;
        }

        public bool deletePhone(WebDriver driver, string url)
        {
            try
            {
                driver.Navigate().GoToUrl("https://myaccount.google.com/two-step-verification/phone-numbers" + url);
                _ = driver.Manage().Timeouts().ImplicitWait;
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                try
                {
                    Thread.Sleep(2000);
                    driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(@aria-label,'Delete phone number:')]"))).Click();
                    Thread.Sleep(2000);
                    driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='mUIrbf-vQzf8d']")));
                    List<IWebElement> listName = driver.FindElements(By.XPath("//span[@class='mUIrbf-vQzf8d']")).Cast<IWebElement>().ToList();
                    Thread.Sleep(2000);
                    foreach (IWebElement btn in listName)
                    {
                        string text = btn.Text;
                        if (text.Contains("Remove"))
                        {
                            driver.ExecuteScript("arguments[0].scrollIntoView(true);", btn);
                            Thread.Sleep(2000);
                            driver.ExecuteScript("arguments[0].click();", btn);
                            break;
                        }
                    }
                    Thread.Sleep(2000);
                }
                catch { }
                Thread.Sleep(1000);
                return true;
            }
            catch {
                return false;
            }

        }

        public async Task<string> getCode2FA(string FaCode)
        {
            var options = new RestClientOptions("https://api.code.pro.vn/2fa/v1/get-code?secretKey=" + FaCode);
            var client = new RestClient(options);
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Code2Fa myDeserializedClass = JsonConvert.DeserializeObject<Code2Fa>(response.Content);
                return myDeserializedClass.code;
            }
            else
            {
                return null;
            }
        }
    }
}

public class Code2Fa
{
    public string code { get; set; }

    public int lifetime { get; set; }
}
