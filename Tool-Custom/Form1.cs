using AutoItX3Lib;
using ChromeAutomation;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool_Custom
{
    public partial class Form1 : Form
    {
        string MARKETID = "ATVPDKIKX0DER";
        Chrome chrome;
        IWebDriver driver;
        OpenQA.Selenium.Support.UI.WebDriverWait waitDrive;
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            //Process[] chromeInstances = Process.GetProcessesByName("chrome");

            //foreach (Process p in chromeInstances)
            //{
            //    p.Kill();
            //}
            startChrome();

            
        }
        public void startChrome()
        {
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //string arguments = @"/c """"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"" --remote-debugging-port=9222 --profile-directory=""" + tb_linkProfile.Text + "\"\"";
            //startInfo.Arguments = arguments;//@"C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe --remote-debugging-port=9222 --user-data-dir=D:\\Profile\\1";
            //process.StartInfo = startInfo;
            //process.Start();

            ////Start();
            //Thread.Sleep(2000);
            //chrome = new Chrome("http://localhost:9222");

            //var sessions = chrome.GetAvailableSessions();

            //lb_status.Text = "Available debugging sessions";
            //foreach (var s in sessions)
            //{
            //    Console.WriteLine(s.url);
            //}

            //if (sessions.Count == 0)
            //{
            //    lb_status.Text = "All debugging sessions are taken.";
            //    throw new Exception("All debugging sessions are taken.");
            //}

            //// Will drive first tab session
            //var sessionWSEndpoint = sessions[0].webSocketDebuggerUrl;
            //chrome.SetActiveSession(sessionWSEndpoint);



            ChromeOptions options = new ChromeOptions();

            options.AddArgument("user-data-dir=profile");

            driver = new ChromeDriver(options);


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "CSV files|*.csv";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                loadASIN(theDialog.FileName.ToString());
            }
        }
        void loadASIN(string url)
        {
            using (var reader = new StreamReader(url))
            {
                List<Product> products = new List<Product>();
             
                while (!reader.EndOfStream)
                {
                    Product product = new Product();
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    product.ASIN = values[0];
                    product.SKU = values[1];
                    products.Add(product);
                }
                lb_numberProduct.Text = "Có " + products.Count + " sản phẩm";
            }
        }
        string getUrlEditCustom(string sku)
        {
            return "https://sellercentral.amazon.com/gestalt/managecustomization/index.html?sku="+sku;
        }

        private void Btn_start_Click_1(object sender, EventArgs e)
        {
            Actions actions = new Actions(driver);
            string url = getUrlEditCustom("GP-P48T-OTJA");
           //string url = "http://localhost:3000";
            driver.Url = url;
            driver.Navigate();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            Thread.Sleep(5000);

            //IWebElement buttonAddSurface = driver.FindElement(By.XPath("//button[text() = 'Add surface']"));
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", buttonAddSurface);
            ////add color
            //buttonAddSurface.Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//button[text() = 'Add surface']"));
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", buttonAddSurface);
            //// add size
            //buttonAddSurface.Click();
            //Thread.Sleep(2000);
            // 
            IReadOnlyList<IWebElement> listDragOrUploadASquareImage =  driver.FindElements(By.XPath("//span[text() = 'Drag or upload a square image']"));
            //0 -style
            //1 - color
            // 2- size
            js.ExecuteScript("arguments[0].scrollIntoView(true);", listDragOrUploadASquareImage[0]);
            listDragOrUploadASquareImage[0].Click();
            sendKeyToPopupWindow("Open", "D:\\test\\img1.png");

            Thread.Sleep(5000);
            IWebElement DragOrUploadASquareImage;
            IReadOnlyList<IWebElement> AddCustomizationSubmit;
            // tim nut add custom
            IWebElement AddCustomization = driver.FindElement(By.XPath("//button[text() = 'Add customization']"));
            //them style
            //-----------------
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddCustomization);
            AddCustomization.Click();
            Thread.Sleep(1000);
            //chon list option
            DragOrUploadASquareImage  = driver.FindElement(By.XPath("//span[text() = 'Option Dropdown']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", DragOrUploadASquareImage);
            DragOrUploadASquareImage.Click();
            Thread.Sleep(1000);
            AddCustomizationSubmit = driver.FindElements(By.XPath("//button[text() = 'Add customization']"));
            AddCustomizationSubmit[1].Click();
            //--------------
            //them color
            //-----------------
            Thread.Sleep(5000);
            AddCustomization = driver.FindElement(By.XPath("//button[text() = 'Add customization']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddCustomization);
            AddCustomization.Click();
            
            //chon list option
            DragOrUploadASquareImage = driver.FindElement(By.XPath("//span[text() = 'Option Dropdown']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", DragOrUploadASquareImage);
            DragOrUploadASquareImage.Click();
           
            AddCustomizationSubmit = driver.FindElements(By.XPath("//button[text() = 'Add customization']"));
            AddCustomizationSubmit[1].Click();
            //--------------
            //them size
            //-----------------
            Thread.Sleep(5000);
            AddCustomization = driver.FindElement(By.XPath("//button[text() = 'Add customization']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddCustomization);
            AddCustomization.Click();
       
            //chon list option
            DragOrUploadASquareImage = driver.FindElement(By.XPath("//span[text() = 'Option Dropdown']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", DragOrUploadASquareImage);
            DragOrUploadASquareImage.Click();
        
            AddCustomizationSubmit = driver.FindElements(By.XPath("//button[text() = 'Add customization']"));
            AddCustomizationSubmit[1].Click();


            //Add another option
            IReadOnlyList<IWebElement> AddAnotherOptions;
            // co 3 cai
            // cai 1 click 4 lan
            // cai 2 click 4 lan
            // cai 3 click 4 lan

            // them option

            // style = 6 - 2 = 4
            Thread.Sleep(5000);
            //----------------
            AddAnotherOptions = driver.FindElements(By.XPath("//button[text() = 'Add another option']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddAnotherOptions[0]);
            AddAnotherOptions[0].Click();
            //
            AddAnotherOptions = driver.FindElements(By.XPath("//button[text() = 'Add another option']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddAnotherOptions[0]);
            AddAnotherOptions[0].Click();
            //
            AddAnotherOptions = driver.FindElements(By.XPath("//button[text() = 'Add another option']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddAnotherOptions[0]);
            AddAnotherOptions[0].Click();
            //
            AddAnotherOptions = driver.FindElements(By.XPath("//button[text() = 'Add another option']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddAnotherOptions[0]);
            AddAnotherOptions[0].Click();
            Thread.Sleep(2000);
            //----------------
            //1
            //----------------
            AddAnotherOptions = driver.FindElements(By.XPath("//button[text() = 'Add another option']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddAnotherOptions[1]);
            AddAnotherOptions[1].Click();
            //
            AddAnotherOptions = driver.FindElements(By.XPath("//button[text() = 'Add another option']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddAnotherOptions[1]);
            AddAnotherOptions[1].Click();
            //
            AddAnotherOptions = driver.FindElements(By.XPath("//button[text() = 'Add another option']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddAnotherOptions[1]);
            AddAnotherOptions[1].Click();
            //
            AddAnotherOptions = driver.FindElements(By.XPath("//button[text() = 'Add another option']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddAnotherOptions[1]);
            AddAnotherOptions[1].Click();
            Thread.Sleep(2000);
            //----------------
            //2
            //----------------
            AddAnotherOptions = driver.FindElements(By.XPath("//button[text() = 'Add another option']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddAnotherOptions[2]);
            AddAnotherOptions[2].Click();
            //
            AddAnotherOptions = driver.FindElements(By.XPath("//button[text() = 'Add another option']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddAnotherOptions[2]);
            AddAnotherOptions[2].Click();
            //
            AddAnotherOptions = driver.FindElements(By.XPath("//button[text() = 'Add another option']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddAnotherOptions[2]);
            AddAnotherOptions[2].Click();
            //
            AddAnotherOptions = driver.FindElements(By.XPath("//button[text() = 'Add another option']"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddAnotherOptions[2]);
            AddAnotherOptions[2].Click();
            Thread.Sleep(2000);
            //----------------

            IReadOnlyList<IWebElement> inputsStatic = driver.FindElements(By.CssSelector(".building-block-content input"));
            List<IWebElement> inputs = new List<IWebElement>();

            string[] sott = new string[47] {
                "Surface 1",
                "Start Custom your products",
                "Styles",
                "Styles",
                "Choose your style",
                "Tshirt",
                "0",
                "V-Neck",
                "10",
                "Tank Top",
                "10",
                "Hooded Sweatshirt",
                "35",
                "Long sleeve tee",
                "15",
                "Crewneck Sweatshirt",
                "30",
                "Color",
                "Color",
                "Choose your color",
                "Black",
                "0",
                "White",
                "0",
                "Navy",
                "0",
                "Royal",
                "0",
                "Grey",
                "0",
                "Red",
                "0",
                 "Size",
                "Size",
                "Choose your size",
                "Small",
                "0",
                "Medium",
                "2",
                "Large",
                "3",
                "X-Large",
                "4",
                "XX-Large",
                "5",
                "XXX-Large",
                "7"
            };
            

            for(int i = 0; i < inputsStatic.Count; i++)
            {
                IWebElement element = inputsStatic[i];
                if (!element.GetAttribute("class").Contains("hidden") && element.GetAttribute("type") == "text")
                {
                    inputs.Add(element);
                }
            }
            int priceInputIndex = 0;
            for(int i = 0; i < 47; i++)
            {
                try
                {
                    js.ExecuteScript("arguments[0].scrollIntoView(true);", inputs[i]);
                    inputs[i].Clear();
                    inputs[i].SendKeys(sott[i]);
                }
                catch (Exception)
                {
                    
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                    IReadOnlyList<IWebElement> listPrice = wait.Until(drv => driver.FindElements(By.CssSelector(".price-input input")));
                    //IReadOnlyList<IWebElement> listPrice = driver.FindElements(By.XPath("//kat-input[@class='price-input']"));
                    //string id = listPrice[priceInputIndex].GetAttribute("id");

                    Actions action = new Actions(driver);
                    action.MoveToElement(listPrice[priceInputIndex]).DoubleClick().Build().Perform();
                    //action.MoveToElement(listPrice[priceInputIndex]).Perform();
                    Thread.Sleep(1000);
                    AutoItX3 autoIT = new AutoItX3();
                    autoIT.Send(sott[i]);
                    priceInputIndex++;

                }
                

            }
            IWebElement SaveButton = driver.FindElement(By.XPath("//button[text() = 'Save']"));
            SaveButton.Click();
            //IWebElement inputLabelStyle = driver.FindElement(By.XPath("//input[value() = 'Option Dropdown 1']"));
            //inputLabelStyle.Clear();
            //inputLabelStyle.SendKeys("Styles");



            //Add customization
            //



            //IWebElement DragOrUploadASquareImage = driver.FindElement(By.XPath("//span[text() = 'Option Dropdown']"));
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", elem);
            //elem.Click();
            //Thread.Sleep(2000);
            //sendKeyToPopupWindow("Open", "D:\\test\\img1.png");
            //Thread.Sleep(5000);
            //// up xong anh sua face 1

            //IWebElement elemButtonAddCustom = driver.FindElement(By.ClassName("secondary"));
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", elemButtonAddCustom);
            //elemButtonAddCustom.Click();
            //Thread.Sleep(5000);
            //IWebElement elemSpanListOption = driver.FindElement(By.XPath("//span[text() = 'Option Dropdown']"));
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", elemSpanListOption);
            //elemSpanListOption.Click();
            //Thread.Sleep(5000);
            //IWebElement elemAddCustomization = driver.FindElement(By.XPath("//span[text() = 'Add customization']"));
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", elemAddCustomization);
            //elemAddCustomization.Click();
            //Add customization
            //Actions action = new Actions(driver);
            //action.MoveByOffset(elem.Location.X, elem.Location.Y).Perform();
            //elem.Click();
            //elem.SendKeys("D://test//img1.png");
            //js.ExecuteScript(
            //"var element=arguments[0];" +
            //"if ('createEvent' in document) {" +
            //    "var evt = document.createEvent('HTMLEvents');" +
            //    "evt.initEvent('change', false, true);" +
            //    "element.dispatchEvent(evt);" +
            //"} else { " +
            //    "element.fireEvent('onchange')" +
            //"};", elem);
            //js.ExecuteScript("document.querySelector('.image-upload-square').click()");
            ////driver.exe("document.querySelector('#asset-upload-tester1').click()");
            //Thread.Sleep(2000);
            //sendKeyToPopupWindow("Open", "Xin chao");

            //chrome.NavigateTo(url);
            //Thread.Sleep(3000);
            //chrome.Eval("document.querySelector('.image-upload-square').click()");
            //Thread.Sleep(2000);
            //sendKeyToPopupWindow("open", "C:\\Users\\User\\Desktop\\tshirt.png");
            //var x = chrome.Eval("document.querySelector('#click-me').getBoundingClientRect().left + window.scrollX");
            //var y = chrome.Eval("document.querySelector('#click-me').getBoundingClientRect().top + window.scrollY");

            //AutoItX3 autoIT = new AutoItX3();
            //dynamic stuffx = JsonConvert.DeserializeObject(x);
            //dynamic stuffy = JsonConvert.DeserializeObject(y);
            //autoIT.MouseClick("LEFT", stuffx.result.result.value, stuffy.result.result.value, 1);
        }
        void sendKeyToPopupWindow(string title,string key)
        {
            IntPtr zero = IntPtr.Zero;
            for (int i = 0; (i < 60) && (zero == IntPtr.Zero); i++)
            {
                Thread.Sleep(500);
                zero = FindWindow(null, "Open");
            }
            if (zero != IntPtr.Zero)
            {
                SetForegroundWindow(zero);
                SendKeys.SendWait(key);
                SendKeys.SendWait("{ENTER}");
                SendKeys.Flush();
            }
        }

        void sendTextToInput(string id, string text)
        {
            IWebElement input = driver.FindElement(By.Id(id));
            input.Clear();
            input.SendKeys(text);
        }
    }
}
