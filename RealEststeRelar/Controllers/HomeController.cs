using RealEststeRelar.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RealEststeRelar.Controllers
{
    public class HomeController : Controller
    {
        public bool hasAttribute = false;

        //load XML
        XElement root = XElement.Load(System.Web.HttpContext.Current.Server.MapPath(@"\App_Data\434WPentagon.xml"));

        /// <summary>
        /// Method for Page1
        /// </summary>
        /// <returns>Model with Map data and PropQuery Data</returns>
        public ActionResult Index()
        {
            PropQuery propQuery = (PropQuery)Session["propQuery"];
            if (propQuery == null)
            {
                //Call Deserialize method for Xml
                propQuery = DeserializeXml();
                //Session generate
                Session["propQuery"] = propQuery;
            }

            //passing a list to the view
            List<PropQuery> propList = new List<PropQuery>();
            propList.Add(propQuery);

            //Model for Map Display
            List<MapViewModel> mapViewModelList = new List<MapViewModel>();
            MapViewModel mapViewModel = new MapViewModel();
            mapViewModel.Address = propQuery.Address;
            mapViewModel.Lat = propQuery.Lat;
            mapViewModel.Lon = propQuery.Lon;
            mapViewModelList.Add(mapViewModel);

            //Bind data to PageModel
            RelarPageFirstViewModel model = new RelarPageFirstViewModel();
            model.PropQuery = propQuery;

            model.MapViewModelList = mapViewModelList;
            return View(model);
        }

        /// <summary>
        /// Child Action for Header
        /// </summary>
        /// <returns>PartialView for Header Data</returns>
        [ChildActionOnly]
        public ActionResult Header()
        {
            PropQuery propQuery = (PropQuery)Session["propQuery"];

            if (propQuery == null)
                propQuery = DeserializeXml();

            return PartialView("~/Views/Shared/_HeaderPartial.cshtml", propQuery);
        }

        /// <summary>
        /// Deserialize Xml to Object
        /// </summary>
        /// <returns>Class Object of PropQuery</returns>
        public PropQuery DeserializeXml()
        {
            PropQuery propList = new PropQuery();
            try
            {
                string XmlPath = System.IO.Path.GetFullPath(HttpContext.Server.MapPath("~/App_Data/434WPentagon.xml"));
                using (StreamReader r = new StreamReader(XmlPath))
                {
                    XmlSerializer s = new XmlSerializer(typeof(PropQuery));
                    propList = (PropQuery)s.Deserialize(r);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propList;
        }

        /// <summary>
        /// Method for Page2
        /// </summary>
        /// <returns>Model with PropQuery Data</returns>
        public ActionResult Summary()
        {
            PropQuery propQuery = (PropQuery)Session["propQuery"];
            if (propQuery == null)
                propQuery = DeserializeXml();

            return View(propQuery);
        }

        /// <summary>
        /// Get Initial List of Properties Searched
        /// </summary>
        /// <returns>Property List</returns>
        public ActionResult PropertiesSearched()
        {
            PropAlg propAlg = new PropAlg();
            List<Prop> objPropList = new List<Prop>();
            try
            {
                //load XML
                //XElement root = XElement.Load(System.Web.HttpContext.Current.Server.MapPath(@"\App_Data\434WPentagon.xml"));

                //get a list of prop in PropSearched
                var props = (from p in root.Descendants("PropSearched").Descendants("Prop") select p).ToList();
                if (props != null)
                {
                    hasAttribute = true;
                    objPropList = GetPropData(props, hasAttribute);
                    propAlg.Props = objPropList.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.RelarAnalysisTitle = "Initial List of Properties Searched";
            return View(propAlg);
        }

        /// <summary>
        /// Get a list of Comparable Sales Selected by RELAR
        /// </summary>
        /// <returns>Model with prop data</returns>
        public ActionResult ComparableSales()
        {
            PropAlg propAlg = new PropAlg();
            List<Prop> objPropList = new List<Prop>();
            try
            {
                //Query to get a list of Props in PropAlg
                var props = (from p in root.Descendants("PropAlg").Descendants("Prop") select p).ToList();

                if (props != null)
                {
                    hasAttribute = true;
                    objPropList = GetPropData(props, hasAttribute);
                    propAlg.Props = objPropList.ToArray();
                    PropQuery objPropQuery = (PropQuery)Session["propQuery"];
                    Regression regression = new Regression();
                    regression.Price = objPropQuery.HouseWorthVal.value.ToString();
                    regression.Range = objPropQuery.HouseWorthErr.value.ToString();
                    propAlg.Regression = regression;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.RelarAnalysisTitle = "Comparable Sales Selected by RELAR";
            return View(propAlg);
        }
        /// <summary>
        /// Get a list of Sales Used In Price Trend Three Months Previous
        /// </summary>
        /// <returns>Model with prop data</returns>
        public ActionResult SalesThreeMonths()
        {
            PropAlg propAlg = new PropAlg();
            List<Prop> objPropList = new List<Prop>();
            try
            {
                //Query to get a list of Props in PropAlg3Month
                var props = (from p in root.Descendants("PropAlg3Month").Descendants("Prop") select p).ToList();

                if (props != null)
                {
                    hasAttribute = true;
                    objPropList = GetPropData(props, hasAttribute);
                    propAlg.Props = objPropList.ToArray();
                    PropQuery objPropQuery = (PropQuery)Session["propQuery"];
                    Regression regression = new Regression();
                    regression.Price = objPropQuery.HouseWorthVal.value3Month.ToString();
                    regression.Range = objPropQuery.HouseWorthErr.value3Month.ToString();
                    propAlg.Regression = regression;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.RelarAnalysisTitle = "Sales Used In Price Trend Three Months Previous";
            return View(propAlg);
        }
        /// <summary>
        /// Get a list of Sales Used In Price Trend Six Months Previous
        /// </summary>
        /// <returns>Model with prop data</returns>
        public ActionResult SalesSixMonths()
        {
            PropAlg propAlg = new PropAlg();
            List<Prop> objPropList = new List<Prop>();
            try
            {
                //Query to get a list of Props in PropAlg6Month
                var props = (from p in root.Descendants("PropAlg6Month").Descendants("Prop") select p).ToList();

                if (props != null)
                {
                    hasAttribute = true;
                    objPropList = GetPropData(props, hasAttribute);
                    propAlg.Props = objPropList.ToArray();
                    PropQuery objPropQuery = (PropQuery)Session["propQuery"];
                    Regression regression = new Regression();
                    regression.Price = objPropQuery.HouseWorthVal.value6Month.ToString();
                    regression.Range = objPropQuery.HouseWorthErr.value6Month.ToString();
                    propAlg.Regression = regression;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.RelarAnalysisTitle = "Sales Used in Price Trend Six Month Previous";
            return View(propAlg);
        }
        /// <summary>
        /// Get a list of Sales From MLS Searched
        /// </summary>
        /// <returns>Model with prop data</returns>
        public ActionResult SalesMLS()
        {
            PropAlg propAlg = new PropAlg();
            List<Prop> objPropList = new List<Prop>();
            try
            {
                //get a list of prop where DataSource equals MLS
                var props = (from p in (root.Descendants("PropSearched")
                                 .Union(root.Descendants("PropAlg"))
                                 .Union(root.Descendants("PropAlg3Month"))
                                 .Union(root.Descendants("PropAlg6Month"))).Descendants("Prop").Where(d => (d.Attribute("DataSource").Value == "MLS"))
                             select p).ToList();
                if (props != null)
                {
                    hasAttribute = false;
                    objPropList = GetPropData(props, hasAttribute);
                    propAlg.Props = objPropList.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.RelarAnalysisTitle = "Sales From MLS Searched";
            return View(propAlg);
        }
        /// <summary>
        /// Get a list of Sales From MLS Used
        /// </summary>
        /// <returns>Model with prop data</returns>
        public ActionResult SalesMLSUsed()
        {
            PropAlg propAlg = new PropAlg();
            List<Prop> objPropList = new List<Prop>();

            try
            {
                //Query to get a list of Props in PendList
                var props = (from p in root.Descendants("CompSold").Descendants("Prop") select p).ToList();
                if (props != null)
                {
                    objPropList = GetPropData(props, hasAttribute);

                    propAlg.Props = objPropList.ToArray();
                    PropQuery objPropQuery = (PropQuery)Session["propQuery"];
                    Regression regression = new Regression();
                    regression.Price = objPropQuery.HouseWorthVal.valuePending.ToString();
                    regression.Range = objPropQuery.HouseWorthErr.valuePending.ToString();
                    propAlg.Regression = regression;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.RelarAnalysisTitle = "Sales from MLS Used";
            return View(propAlg);
        }
        public ActionResult ContractSearched()
        {
            return View();
        }
        /// <summary>
        /// Get a list of Properties Under Contract Used
        /// </summary>
        /// <returns>Model with prop data</returns>
        public ActionResult ContractUsed()
        {
            PropAlg propAlg = new PropAlg();
            List<Prop> objPropList = new List<Prop>();

            try
            {
                //Query to get a list of Props in PendList
                var props = (from p in root.Descendants("PendList").Descendants("Prop") select p).ToList();
                if (props != null)
                {
                    objPropList = GetPropData(props, hasAttribute);

                    propAlg.Props = objPropList.ToArray();
                    PropQuery objPropQuery = (PropQuery)Session["propQuery"];
                    Regression regression = new Regression();
                    regression.Price = objPropQuery.HouseWorthVal.valuePending.ToString();
                    regression.Range = objPropQuery.HouseWorthErr.valuePending.ToString();
                    propAlg.Regression = regression;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.RelarAnalysisTitle = "Properties Under Contract Used";
            return View(propAlg);
        }
        /// <summary>
        /// Get a list of Expired Properties Used
        /// </summary>
        /// <returns>Model with prop data</returns>
        public ActionResult ExpiredPropertiesUsed()
        {
            PropAlg propAlg = new PropAlg();
            List<Prop> objPropList = new List<Prop>();
            try
            {
                //Query to get a list of Props in ExpList
                var props = (from p in root.Descendants("ExpList").Descendants("Prop") select p).ToList();

                if (props != null)
                {
                    objPropList = GetPropData(props, hasAttribute);
                    propAlg.Props = objPropList.ToArray();
                    PropQuery objPropQuery = (PropQuery)Session["propQuery"];
                    Regression regression = new Regression();
                    regression.Price = objPropQuery.HouseWorthVal.valueExpired.ToString();
                    regression.Range = objPropQuery.HouseWorthErr.valueExpired.ToString();
                    propAlg.Regression = regression;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.RelarAnalysisTitle = "Expired Properties Used";
            return View(propAlg);
        }
        public ActionResult InventorySearched()
        {
            return View();
        }
        /// <summary>
        /// Get a list of Properties In Inventory Used
        /// </summary>
        /// <returns>Model with prop data</returns>
        public ActionResult InventoryUsed()
        {
            PropAlg propAlg = new PropAlg();
            List<Prop> objPropList = new List<Prop>();

            try
            {
                //Query to get a list of Props in CorrOpen
                var props = (from p in root.Descendants("CorrOpen").Descendants("Prop") select p).ToList();

               if (props != null)
                {
                    objPropList = GetPropData(props, hasAttribute);
                    propAlg.Props = objPropList.ToArray();
                    PropQuery objPropQuery = (PropQuery)Session["propQuery"];
                    Regression regression = new Regression();
                    regression.Price = objPropQuery.HouseWorthVal.valueActive.ToString();
                    regression.Range = objPropQuery.HouseWorthErr.valueActive.ToString();
                    propAlg.Regression = regression;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.RelarAnalysisTitle = "Properties In Inventory Used";
            return View(propAlg);
        }
        /// <summary>
        /// Method to get Prop Data
        /// </summary>
        /// <param name="props"></param>
        /// <returns>PropList</returns>
        public List<Prop> GetPropData(List<XElement> props, bool attribute)
        {
            Prop objProp;
            List<Prop> objPropList = new List<Prop>();
            if (props != null)
            {
                props.ForEach(prop =>
                {
                    objProp = new Prop();
                    objProp.Address = prop.Attribute("Address").Value;
                    objProp.APN = prop.Attribute("APN").Value;
                    objProp.Baths = prop.Attribute("Baths").Value;

                    objProp.Beds = prop.Attribute("Beds").Value;
                    objProp.City = prop.Attribute("City").Value;
                    objProp.County = prop.Attribute("County").Value;

                    objProp.Date = prop.Attribute("Date").Value;
                    objProp.Dist = prop.Attribute("Dist").Value;

                    objProp.Lat = prop.Attribute("Lat").Value;
                    objProp.Lon = prop.Attribute("Lon").Value;
                    objProp.Lot = prop.Attribute("Lot").Value;

                    objProp.Price = prop.Attribute("Price").Value;
                    objProp.RelScore = prop.Attribute("RelScore").Value;
                    objProp.Spec = prop.Attribute("Spec").Value;

                    objProp.Sq_Ft = prop.Attribute("Sq_Ft").Value;
                    objProp.State = prop.Attribute("State").Value;
                    objProp.Stories = prop.Attribute("Stories").Value;

                    objProp.Time = prop.Attribute("Time").Value;
                    objProp.Zip = prop.Attribute("Zip").Value;

                    if (attribute)
                    {
                        objProp.Year = prop.Attribute("Year").Value;
                        objProp.DataSource = prop.Attribute("DataSource").Value;
                        ViewBag.IsWithSpecs = false;
                    }
                    else
                    {
                        objProp.FC = objProp.REO = objProp.SS = "N";
                        objProp.Spec = prop.Attribute("Spec").Value;
                        if (objProp.Spec.Contains("FC"))
                        {
                            objProp.FC = "Y";
                        }
                        if (objProp.Spec.Contains("SS"))
                        {
                            objProp.SS = "Y";
                        }
                        if (objProp.Spec.Contains("RE"))
                        {
                            objProp.REO = "Y";
                        }
                        ViewBag.IsWithSpecs = true;
                    }

                    objPropList.Add(objProp);
                });
            }
            return objPropList;
        }
       
        #region Chart Generator Code

        /// <summary>
        /// Create Line Chart
        /// </summary>
        /// <param name="priceTimeToSellList"></param>
        /// <returns>Image File</returns>
        public FileResult CreateLine(PriceTimeToSell priceTimeToSellList)
        {
            System.Web.UI.DataVisualization.Charting.Chart chart = new System.Web.UI.DataVisualization.Charting.Chart();

            chart.Width = 700;
            chart.Height = 300;
            chart.BorderlineWidth = 1;
            chart.BorderlineColor = Color.FromArgb(26, 59, 105);
            chart.RenderType = RenderType.BinaryStreaming;
            chart.AntiAliasing = AntiAliasingStyles.All;
            chart.TextAntiAliasingQuality = TextAntiAliasingQuality.Normal;
            chart.Titles.Add(CreateTitle());
            chart.Legends.Add(CreateLegend());
            chart.Series.Add(CreateSeries(priceTimeToSellList));
            chart.ChartAreas.Add(CreateChartArea());

            for (int i = 0; i < chart.Series["Relar Chart"].Points.Count(); i++)
            {
                chart.Series["Relar Chart"].Points[i].MarkerStyle = MarkerStyle.Circle;
                chart.Series["Relar Chart"].Points[i].MarkerSize = 12;
                chart.Series["Relar Chart"].Points[i].MarkerColor = Color.Green;
                chart.Series["Relar Chart"].Points[i].MarkerBorderWidth = 2;
                chart.Series["Relar Chart"].Points[i].Color = Color.Blue;
            }

            MemoryStream ms = new MemoryStream();
            chart.SaveImage(ms);
            return File(ms.GetBuffer(), @"images/png");
        }
        /// <summary>
        /// Create ChartArea
        /// </summary>
        /// <returns>ChartArea</returns>
        public ChartArea CreateChartArea()
        {
            ChartArea chartArea = new ChartArea();
            chartArea.Name = "Relar Chart";
            chartArea.BackColor = Color.Transparent;
            chartArea.AxisX.IsLabelAutoFit = false;
            chartArea.AxisY.IsLabelAutoFit = false;
            chartArea.AxisX.LabelStyle.Font =
               new Font("Verdana,Arial,Helvetica,sans-serif",
                        8F, FontStyle.Regular);
            chartArea.AxisY.LabelStyle.Font =
               new Font("Verdana,Arial,Helvetica,sans-serif",
                        8F, FontStyle.Regular);
            chartArea.AxisY.LineColor = Color.Black;
            chartArea.AxisX.LineColor = Color.Black;

            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisX.MajorGrid.Enabled = false;

            chartArea.AxisX.Interval = 30;
            chartArea.AxisX.Maximum = 120;
            chartArea.AxisX.Minimum = 0;

            return chartArea;
        }
        /// <summary>
        /// Title for Chart
        /// </summary>
        /// <returns>Title</returns>
        public Title CreateTitle()
        {
            Title title = new Title();
            title.Text = "Relar Chart";
            title.ShadowColor = Color.FromArgb(32, 0, 0, 0);
            title.Font = new Font("Trebuchet MS", 14F, FontStyle.Bold);
            title.ShadowOffset = 3;
            title.ForeColor = Color.FromArgb(26, 59, 105);
            return title;
        }

        /// <summary>
        /// Legend for Chart
        /// </summary>
        /// <returns>Legend</returns>
        public Legend CreateLegend()
        {
            Legend legend = new Legend();

            return legend;
        }

        /// <summary>
        /// Series for Chart
        /// </summary>
        /// <param name="results"></param>
        /// <returns>Series</returns>
        public Series CreateSeries(PriceTimeToSell results)
        {
            Series seriesDetail = new Series();
            seriesDetail.Name = "Relar Chart";
            seriesDetail.IsValueShownAsLabel = false;
            seriesDetail.Color = Color.FromArgb(198, 99, 99);
            seriesDetail.ChartType = SeriesChartType.Line;
            seriesDetail.BorderWidth = 2;
            DataPoint point;


            point = new DataPoint();
            point.AxisLabel = results.price30.ToString();
            point.XValue = new double();
            string yvalue = results.price30.ToString();
            string fyval = yvalue.Substring(3);
            seriesDetail.Points.Add(new DataPoint(30.0, double.Parse(results.price30.ToString())));
            seriesDetail.Points.Add(new DataPoint(60.0, double.Parse(results.price60.ToString())));
            seriesDetail.Points.Add(new DataPoint(90.0, double.Parse(results.price90.ToString())));
            seriesDetail.ChartArea = "Relar Chart";
            return seriesDetail;
        }
        #endregion
    }
}