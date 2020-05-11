using AutoItX3Lib;
using ChromeAutomation;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
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
            Process[] chromeInstances = Process.GetProcessesByName("chrome");

            foreach (Process p in chromeInstances)
            {
                p.Kill();
            }
            startChrome();

            
        }
        public void startChrome()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            string arguments = @"/c """"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"" --remote-debugging-port=9222 --profile-directory=""" + tb_linkProfile.Text + "\"\"";
            startInfo.Arguments = arguments;//@"C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe --remote-debugging-port=9222 --user-data-dir=D:\\Profile\\1";
            process.StartInfo = startInfo;
            process.Start();

            //Start();
            Thread.Sleep(2000);
            chrome = new Chrome("http://localhost:9222");

            var sessions = chrome.GetAvailableSessions();

            lb_status.Text = "Available debugging sessions";
            foreach (var s in sessions)
            {
                Console.WriteLine(s.url);
            }

            if (sessions.Count == 0)
            {
                lb_status.Text = "All debugging sessions are taken.";
                throw new Exception("All debugging sessions are taken.");
            }

            // Will drive first tab session
            var sessionWSEndpoint = sessions[0].webSocketDebuggerUrl;
            chrome.SetActiveSession(sessionWSEndpoint);



            //ChromeOptions options = new ChromeOptions();

            //options.AddArgument("user-data-dir=profile");

            //driver = new ChromeDriver(options);

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
        string getUrlEditCustom(string marketplaceID,string sku,string asin)
        {
            return "https://sellercentral.amazon.com/customization/manageListing?marketplaceID=" + marketplaceID + "&ref=xx_myicust_cont_myifba&sku=" + sku + "&asin=" + asin;
        }

        private void Btn_start_Click_1(object sender, EventArgs e)
        {
            string url = getUrlEditCustom(MARKETID, "TK-XHJ8-1UST", "B087V51Q8Q");
            //string url = "http://localhost:3000";
            //driver.Url = url;
            //driver.Navigate();
            //Thread.Sleep(5000);
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //IWebElement elem = driver.FindElement(By.Id("b1"));
            //elem.Click();
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
            //js.ExecuteScript("setTimeout(() => {document.querySelector('#asset-upload-tester1').click()}, 3000);");
            ////driver.exe("document.querySelector('#asset-upload-tester1').click()");
            //Thread.Sleep(2000);
            //sendKeyToPopupWindow("Open", "Xin chao");

            chrome.NavigateTo(url);
            Thread.Sleep(5000);
            var x = chrome.Eval("document.querySelector('#click-me').getBoundingClientRect().left + window.scrollX");
            var y = chrome.Eval("document.querySelector('#click-me').getBoundingClientRect().top + window.scrollY");

            AutoItX3 autoIT = new AutoItX3();
            dynamic stuffx = JsonConvert.DeserializeObject(x);
            dynamic stuffy = JsonConvert.DeserializeObject(y);
            autoIT.MouseClick("LEFT", stuffx.result.result.value, stuffy.result.result.value, 1);
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
    }
}
