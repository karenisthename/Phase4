using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;
using System.Xml;
using System.Net;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Phase4
{
    public partial class MainForm : MetroForm
    {
        private static string filePath2;
        public static string[] files;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file = string.Empty;
            this.folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                DirectoryInfo di = new DirectoryInfo(folderBrowserDialog1.SelectedPath);

                try
                {
                    //loopFolders(di);
                    for (int i = 0; i < files.Count(); i++)
                    {
                        //CopyURL(Path.GetFullPath(files[i]));
                        //perform process
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                file = Path.GetFileName(folderBrowserDialog1.SelectedPath);
            }

            webBrowser1.Navigate("file:///F:/VIPER%20JOBS/PHASE%203/A/standard-1-5068-52157-100582.html");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //ProcessOutput(webBrowser1);  
        }

        public void ProcessOutput(string filename)
        {
            using (StreamReader htmlReader = new System.IO.StreamReader("F:\\VIPER JOBS\\PHASE 3\\A\\standard-1-5068-52157-100582.html"))
            {
                HtmlAgilityPack.HtmlDocument newhtml = new HtmlAgilityPack.HtmlDocument();
                newhtml.Load(htmlReader);

                var _compName = newhtml.DocumentNode.SelectNodes("//*[@class=\"col-xs-8\"]");
                var _companyDetails = newhtml.DocumentNode.SelectNodes("//*[@class=\"search-result-text\"]");

                var _companyServices2 = newhtml.DocumentNode.SelectNodes("//*[@class=\"services\"]");

                var _CompanyEngineers = newhtml.DocumentNode.Descendants("div")
                                    .Where(d => d.Attributes.Contains("class")
                                    &&
                                    d.Attributes["class"].Value.Contains("col-xs-10"));

                string CompanyName;

                string PostCode;

                //Company Details
                CompanyName = _compName[0].ChildNodes["h4"].InnerText;
                PostCode = _companyDetails[0].ChildNodes[8].InnerText.Replace("\r\n                                            ", string.Empty);
                Phase4.Address newCompanyAddress = new Phase4.Address(_companyDetails[0].ChildNodes[0].InnerText.Replace("\r\n                                            ", string.Empty),
                                                        _companyDetails[0].ChildNodes[2].InnerText.Replace("\r\n                                            ", string.Empty),
                                                        _companyDetails[0].ChildNodes[4].InnerText.Replace("\r\n                                            ", string.Empty),
                                                        _companyDetails[0].ChildNodes[6].InnerText.Replace("\r\n                                            ", string.Empty));


                CompanyServices companyServices;
                CompanyServiceList companyServicesList = new CompanyServiceList();
                //Services services;
                ServiceCollection listofServices = new ServiceCollection();
                DomesticNaturalGasServicesList domNatGasList = new DomesticNaturalGasServicesList();
                DomesticLPGServicesList domLPGList = new DomesticLPGServicesList();
                NonDomesticNaturalGasServicesList nonDomNatGasList = new NonDomesticNaturalGasServicesList();
                NonDomesticLPGServicesList nonLPGList = new NonDomesticLPGServicesList();

                var compSvcDom = _companyServices2[0].ChildNodes[1].ChildNodes[1];
                var compSvcNonDom = _companyServices2[0].ChildNodes[1].ChildNodes[3];

                string compServices = string.Empty;
                //string SrvcsNode;
                int domlpg = 0, domnatGas = 0;
                int nondomlpg = 0, nondomnatGas = 0;
                int ctr = 0;
                //Company Service Domestic
                foreach (var node in compSvcDom.ChildNodes[1].ChildNodes[3].ChildNodes)
                {
                    #region Get Dom Services
                    if (node.HasChildNodes)
                    {
                        if (node.ChildNodes[1].InnerText.Contains("+"))
                        {
                            compServices = node.ChildNodes[1].ChildNodes[2].InnerText;
                            if (node.ChildNodes.Count > 0)
                            {
                                if (node.ChildNodes[3].InnerHtml == "<i class=\"fa fa-check\"></i>")
                                {
                                    domnatGas = 1;
                                }
                                if (node.ChildNodes[5].InnerHtml == "<i class=\"fa fa-check\"></i>")
                                {
                                    domlpg = 1;
                                }
                            }
                        }
                        else
                        {
                            if (node.ChildNodes[1].ChildNodes[1].InnerText != "")
                            {
                                var pre = node.ChildNodes[1].Descendants("div").FirstOrDefault();
                                var links = pre.Descendants("p");
                                domLPGList = new DomesticLPGServicesList();
                                domNatGasList = new DomesticNaturalGasServicesList();

                                foreach (var s in links)
                                {
                                    var href = s.GetAttributeValue("p", string.Empty);
                                    var svcs = s.InnerText;

                                    //services = new Services(svcs);
                                    if (domlpg == 1 && domnatGas == 1)
                                    {
                                        DomesticLPGServices domlpgsvc = new DomesticLPGServices(svcs);
                                        DomesticNaturalGasServices domnatgassvc = new DomesticNaturalGasServices(svcs);


                                        domLPGList.Add(domlpgsvc);
                                        domNatGasList.Add(domnatgassvc);
                                    }
                                    else if (domlpg == 1 && domnatGas == 0)
                                    {
                                        DomesticLPGServices domlpgsvc = new DomesticLPGServices(svcs);
                                        //domLPGList = new DomesticLPGServicesList();
                                        domLPGList.Add(domlpgsvc);
                                    }
                                    else if (domlpg == 0 && domnatGas == 1)
                                    {
                                        DomesticNaturalGasServices domnatgassvc = new DomesticNaturalGasServices(svcs);
                                        //domNatGasList = new DomesticNaturalGasServicesList();
                                        domNatGasList.Add(domnatgassvc);
                                    }
                                }
                                ctr++;
                            }
                        }
                    }
                    #endregion
                    if (ctr == 1)
                    {   //Adding Domestic Services to Company Services list
                        companyServices = new CompanyServices(compServices, domNatGasList, domLPGList, null, null);
                        companyServicesList.Add(companyServices);
                        domnatGas = 0;
                        domlpg = 0;
                        ctr = 0;
                    }
                }

                //Company Service Non Domestic
                foreach (var node in compSvcNonDom.ChildNodes[1].ChildNodes[3].ChildNodes)
                {
                    #region Get NonDom Services
                    if (node.HasChildNodes)
                    {
                        if (node.ChildNodes[1].InnerText.Contains("+"))
                        {
                            compServices = node.ChildNodes[1].ChildNodes[2].InnerText;
                            if (node.ChildNodes.Count > 0)
                            {
                                if (node.ChildNodes[3].InnerHtml == "<i class=\"fa fa-check\"></i>")
                                {
                                    nondomnatGas = 1;
                                }
                                if (node.ChildNodes[5].InnerHtml == "<i class=\"fa fa-check\"></i>")
                                {
                                    nondomlpg = 1;
                                }
                            }
                        }
                        else
                        {
                            if (node.ChildNodes[1].ChildNodes[1].InnerText != "")
                            {
                                var pre = node.ChildNodes[1].Descendants("div").FirstOrDefault();
                                var links = pre.Descendants("p");
                                nonLPGList = new NonDomesticLPGServicesList();
                                nonDomNatGasList = new NonDomesticNaturalGasServicesList();

                                foreach (var s in links)
                                {
                                    var href = s.GetAttributeValue("p", string.Empty);
                                    var svcs = s.InnerText;
                                    if (nondomlpg == 1 && nondomnatGas == 1)
                                    {
                                        NonDomesticLPGServices nondomlpgsvc = new NonDomesticLPGServices(svcs);
                                        NonDomesticNaturalGasServices nondomnatgassvc = new NonDomesticNaturalGasServices(svcs);

                                        nonDomNatGasList.Add(nondomnatgassvc);
                                        nonLPGList.Add(nondomlpgsvc);
                                    }
                                    else if (nondomlpg == 1 && nondomnatGas == 0)
                                    {
                                        NonDomesticLPGServices nondomlpgsvc = new NonDomesticLPGServices(svcs);
                                        nonLPGList.Add(nondomlpgsvc);
                                    }
                                    else if (nondomlpg == 0 && nondomnatGas == 1)
                                    {
                                        NonDomesticNaturalGasServices nondomnatgassvc = new NonDomesticNaturalGasServices(svcs);
                                        nonDomNatGasList.Add(nondomnatgassvc);
                                    }
                                }
                                ctr++;
                            }
                        }
                    }
                    #endregion
                    if (ctr == 1)
                    {   //Adding Domestic Services to Company Services list
                        companyServices = new CompanyServices(compServices, null, null, nonDomNatGasList, nonLPGList);
                        companyServicesList.Add(companyServices);
                        domnatGas = 0;
                        domlpg = 0;
                        ctr = 0;
                    }
                }

                #region Engineers
                EngineerServiceList EngineersServicesList = new EngineerServiceList();
                EngineerServices EngineerServices;
                Engineers Engineer = new Engineers();
                EngineerCollection CompanyEngineers = new EngineerCollection();
                foreach (var node in _CompanyEngineers)
                {
                    string engineerName = string.Empty;
                    string _engineerSvs = string.Empty;
                    engineerName = node.ChildNodes[1].InnerText;

                    var EngineerSvcDom = node.ChildNodes[7].ChildNodes[1].ChildNodes[3].ChildNodes;
                    var EngineerSvcNonDom = node.ChildNodes[9].ChildNodes[1].ChildNodes[3].ChildNodes;

                    //Engineers Domestic Services
                    foreach (var innerNode in EngineerSvcDom)
                    {
                        #region Domestic Services
                        if (innerNode.HasChildNodes)
                        {
                            if (innerNode.ChildNodes[1].InnerText.Contains("+"))
                            {
                                _engineerSvs = innerNode.ChildNodes[1].ChildNodes[2].InnerText;
                                if (innerNode.ChildNodes.Count > 0)
                                {
                                    if (innerNode.ChildNodes[3].InnerHtml == "<i class=\"fa fa-check\"></i>")
                                    {
                                        domnatGas = 1;
                                    }
                                    if (innerNode.ChildNodes[5].InnerHtml == "<i class=\"fa fa-check\"></i>")
                                    {
                                        domlpg = 1;
                                    }
                                }
                            }
                            else
                            {
                                if (innerNode.ChildNodes[1].ChildNodes[1].InnerText != "")
                                {
                                    var pre = innerNode.ChildNodes[1].Descendants("div").FirstOrDefault();
                                    var links = pre.Descendants("p");
                                    domLPGList = new DomesticLPGServicesList();
                                    domNatGasList = new DomesticNaturalGasServicesList();

                                    foreach (var s in links)
                                    {
                                        var href = s.GetAttributeValue("p", string.Empty);
                                        var svcs = s.InnerText;

                                        //services = new Services(svcs);
                                        if (domlpg == 1 && domnatGas == 1)
                                        {
                                            DomesticLPGServices domlpgsvc = new DomesticLPGServices(svcs);
                                            DomesticNaturalGasServices domnatgassvc = new DomesticNaturalGasServices(svcs);


                                            domLPGList.Add(domlpgsvc);
                                            domNatGasList.Add(domnatgassvc);
                                        }
                                        else if (domlpg == 1 && domnatGas == 0)
                                        {
                                            DomesticLPGServices domlpgsvc = new DomesticLPGServices(svcs);
                                            //domLPGList = new DomesticLPGServicesList();
                                            domLPGList.Add(domlpgsvc);
                                        }
                                        else if (domlpg == 0 && domnatGas == 1)
                                        {
                                            DomesticNaturalGasServices domnatgassvc = new DomesticNaturalGasServices(svcs);
                                            //domNatGasList = new DomesticNaturalGasServicesList();
                                            domNatGasList.Add(domnatgassvc);
                                        }
                                    }
                                    ctr++;
                                }
                            }
                        }
                        #endregion
                        if (ctr == 1)
                        {   //Adding Domestic Services to Engineer Services list
                            EngineerServices = new EngineerServices(_engineerSvs, domNatGasList, domLPGList, null, null);
                            EngineersServicesList.Add(EngineerServices);
                            domnatGas = 0;
                            domlpg = 0;
                            ctr = 0;
                        }
                    }

                    foreach (var innerNode in EngineerSvcNonDom)
                    {
                        #region NonDomestic Services
                        if (innerNode.HasChildNodes)
                        {
                            if (innerNode.ChildNodes[1].InnerText.Contains("+"))
                            {
                                _engineerSvs = innerNode.ChildNodes[1].ChildNodes[2].InnerText;
                                if (node.ChildNodes.Count > 0)
                                {
                                    if (innerNode.ChildNodes[3].InnerHtml == "<i class=\"fa fa-check\"></i>")
                                    {
                                        nondomnatGas = 1;
                                    }
                                    if (innerNode.ChildNodes[5].InnerHtml == "<i class=\"fa fa-check\"></i>")
                                    {
                                        nondomlpg = 1;
                                    }
                                }
                            }
                            else
                            {
                                if (innerNode.ChildNodes[1].ChildNodes[1].InnerText != "")
                                {
                                    var pre = innerNode.ChildNodes[1].Descendants("div").FirstOrDefault();
                                    var links = pre.Descendants("p");
                                    nonLPGList = new NonDomesticLPGServicesList();
                                    nonDomNatGasList = new NonDomesticNaturalGasServicesList();

                                    foreach (var s in links)
                                    {
                                        var href = s.GetAttributeValue("p", string.Empty);
                                        var svcs = s.InnerText;

                                        if (nondomlpg == 1 && nondomnatGas == 1)
                                        {
                                            NonDomesticLPGServices nondomlpgsvc = new NonDomesticLPGServices(svcs);
                                            NonDomesticNaturalGasServices nondomnatgassvc = new NonDomesticNaturalGasServices(svcs);

                                            nonDomNatGasList.Add(nondomnatgassvc);
                                            nonLPGList.Add(nondomlpgsvc);
                                        }
                                        else if (nondomlpg == 1 && nondomnatGas == 0)
                                        {
                                            NonDomesticLPGServices nondomlpgsvc = new NonDomesticLPGServices(svcs);
                                            nonLPGList.Add(nondomlpgsvc);
                                        }
                                        else if (nondomlpg == 0 && nondomnatGas == 1)
                                        {
                                            NonDomesticNaturalGasServices nondomnatgassvc = new NonDomesticNaturalGasServices(svcs);
                                            nonDomNatGasList.Add(nondomnatgassvc);
                                        }
                                    }
                                    ctr++;
                                }
                            }
                        }
                        #endregion
                        if (ctr == 1)
                        {   //Adding Domestic Services to Engineer Services list
                            EngineerServices = new EngineerServices(_engineerSvs, null, null, nonDomNatGasList, nonLPGList);
                            EngineersServicesList.Add(EngineerServices);
                            nondomnatGas = 0;
                            nondomlpg = 0;
                            ctr = 0;
                        }
                    }
                    Engineer = new Engineers(engineerName, "sample last", EngineersServicesList);
                    CompanyEngineers.Add(Engineer);
                }
                #endregion

                Company newCompany = new Company(CompanyName, 1, 2, 3, PostCode, 5, null, newCompanyAddress, companyServicesList, CompanyEngineers);

                WebClient webClient = new WebClient();

                var _compServiceTable = newhtml.DocumentNode.SelectNodes("//*[@class=\"serviceTable\"]");
                string table = _companyServices2[0].InnerHtml;

                string companydetails = JsonConvert.SerializeObject(newCompany, Newtonsoft.Json.Formatting.Indented);

                System.IO.File.WriteAllText(@"F:\Company.json", companydetails);
            }

        }


    }
}
