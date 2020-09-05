using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProvaILab
{
    class Teste
    {
        IWebDriver driver;
        

        [TestFixture]
        public class NomeDoProjeto
        {
            public IWebDriver driver;
            private string baseURL;
            public string screenshotsPasta;
            int contador = 1;


            //Método para capturar screenshot da tela
            public void Screenshot(IWebDriver driver, string screenshotsPasta)
            {
                ITakesScreenshot camera = driver as ITakesScreenshot;
                Screenshot foto = camera.GetScreenshot();
                foto.SaveAsFile(screenshotsPasta, ScreenshotImageFormat.Png);
            }

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("D:\\User\\ProvaILab\\ProvaILab\\chromedriver.exe");
            driver.Url = "http://www.google.com/";
            driver.Manage().Window.Maximize();
            screenshotsPasta = @"D:\User\ProvaILab\Evidencias\";
        }

        public void capturaImagem()
        {
           Screenshot(driver, screenshotsPasta + "Imagem_" + contador++ + ".png");
           Thread.Sleep(500);
        }

        [Test]

            IWebelement element;
        public void test()
        {
            element = (IWebelement)driver.FindElement(By.Id("realbox"));
            element.SendKeys("iLAB Quality");

            element = (IWebelement)driver.FindElement(By.Id("realbox-icon")); element.Click();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
