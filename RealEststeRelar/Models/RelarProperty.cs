using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace RealEststeRelar.Models
{
    /// <summary>
    /// Class for Page1
    /// </summary>
    public class RelarPageFirstViewModel
    {
        public PropQuery PropQuery { get; set; }
        public IEnumerable<MapViewModel> MapViewModelList { get; set; }
    }

    /// <summary>
    /// Class for Map Display in Page1
    /// </summary>
    public class MapViewModel
    {
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Address { get; set; }
    }

    /// <summary>
    /// Xml To Object Class
    /// Base Class
    /// </summary>
    public class PropQuery
    {
        [XmlAttribute]
        public string AnalysisDate { get; set; } 
        [XmlAttribute]
        public string APN { get; set; }
        [XmlAttribute]
        public string County { get; set; }
        [XmlAttribute]
        public string State { get; set; }
        [XmlAttribute]
        public string City { get; set; }
        [XmlAttribute]
        public string Zip { get; set; }
        [XmlAttribute]
        public int Bedrooms { get; set; }
        [XmlAttribute]
        public int Bathrooms { get; set; }
        [XmlAttribute]
        public int Garages { get; set; }
        [XmlAttribute]
        public int Rooms { get; set; }
        [XmlAttribute]
        public int Fireplaces { get; set; }
        [XmlAttribute]
        public int YearBuilt { get; set; }
        [XmlAttribute]
        public int Size { get; set; }
        [XmlAttribute]
        public string Pool { get; set; }
        [XmlAttribute]
        public int LotSize { get; set; }

        [XmlAttribute]
        public string Lat { get; set; }
        [XmlAttribute]
        public string Lon { get; set; }
        [XmlAttribute]
        public string Address { get; set; }
        [XmlAttribute]
        public DateTime LastSaleDate { get; set; }
        [XmlAttribute]
        public decimal LastSalePrice { get; set; }
        
        public PropTitle PropTitle { get; set; }
        public HouseWorthVal HouseWorthVal { get; set; }
        public HouseWorthErr HouseWorthErr { get; set; }
        public TimeSellVal TimeSellVal { get; set; }
        public TimeSellErr TimeSellErr { get; set; }
        public PriceTimeToSell PriceTimeToSell { get; set; }
        public ConfidenceScoreListCurrent ConfidenceScoreListCurrent { get; set; }
        public ConfidenceScoreListThree ConfidenceScoreListThree { get; set; }
        public ConfidenceScoreListSix ConfidenceScoreListSix { get; set; }
        public PropSearched PropSearched { get; set; }
    }

    /// <summary>
    ///XML Prop Title Class
    /// </summary>
    public class PropTitle
    {
        [XmlAttribute]
        public int Size { get; set; }
        [XmlAttribute]
        public int Bedrooms { get; set; }
        [XmlAttribute]
        public int Bathrooms { get; set; }
        [XmlAttribute]
        public int Rooms { get; set; }
        [XmlAttribute]
        public int LotSize { get; set; }
        [XmlAttribute]
        public int YearBuilt { get; set; }
        [XmlAttribute]
        public int Garages { get; set; }
        [XmlAttribute]
        public int Fireplaces { get; set; }
        [XmlAttribute]
        public string Pool { get; set; }
    }

    /// <summary>
    ///XML HouseWorthVal Class
    /// </summary>
    public class HouseWorthVal
    {
        [XmlAttribute]
        public decimal valuePredicted { get; set; }
        [XmlAttribute]
        public decimal confidenceScoreCurrent { get; set; }
        [XmlAttribute]
        public decimal PriceToSalesRatio { get; set; }
        [XmlAttribute]
        public decimal DailyListToSaleChange { get; set; }
        [XmlAttribute]
        public decimal value { get; set; }
        [XmlAttribute]
        public decimal value3Month { get; set; }
        [XmlAttribute]
        public decimal value6Month { get; set; }
        [XmlAttribute]
        public decimal valuePending { get; set; }
        [XmlAttribute]
        public decimal valueActive { get; set; }
        [XmlAttribute]
        public decimal valueExpired { get; set; }

    }

    /// <summary>
    ///XML HouseWorthErr Class
    /// </summary>
    public class HouseWorthErr
    {
        [XmlAttribute]
        public decimal valuePredicted { get; set; }
        [XmlAttribute]
        public decimal value { get; set; }
        [XmlAttribute]
        public decimal value3Month { get; set; }
        [XmlAttribute]
        public decimal value6Month { get; set; }
        [XmlAttribute]
        public decimal valuePending { get; set; }
        [XmlAttribute]
        public decimal valueActive { get; set; }
        [XmlAttribute]
        public decimal valueExpired { get; set; }
    }

    /// <summary>
    /// XML TimeSellVal Class
    /// </summary>
    public class TimeSellVal
    {
        [XmlAttribute]
        public decimal valuePredicted { get; set; }
    }

    /// <summary>
    /// XML TimeSellErr
    /// </summary>
    public class TimeSellErr
    {
        [XmlAttribute]
        public decimal valuePredicted { get; set; }
    }

    /// <summary>
    /// XML PriceTimeToSell
    /// </summary>
    public class PriceTimeToSell
    {
        [XmlAttribute]
        public decimal price30 { get; set; }
        [XmlAttribute]
        public decimal price60 { get; set; }
        [XmlAttribute]
        public decimal price90 { get; set; }
        [XmlAttribute]
        public decimal price30Var { get; set; }
        [XmlAttribute]
        public decimal price60Var { get; set; }
        [XmlAttribute]
        public decimal price90Var { get; set; }
    }

    /// <summary>
    /// XML ConfidenceScoreListCurrent Class contains ConfidenceScoreItem
    /// </summary>
    [Serializable()]
    [XmlRootAttribute("ConfidenceScoreListCurrent")]
    public class ConfidenceScoreListCurrent
    {
        [XmlElement("ConfidenceScoreItem")]
        public ConfidenceScoreItem[] ConfidenceScoreItems { get; set; }
    }

    
    ///  <summary>
    /// XML ConfidenceScoreListThree Class contains ConfidenceScoreItem
    /// </summary>
    [Serializable()]
    [XmlRootAttribute("ConfidenceScoreListThree")]
    public class ConfidenceScoreListThree
    {
        [XmlElement("ConfidenceScoreItem")]
        public ConfidenceScoreItem[] ConfidenceScoreItems { get; set; }
    }

    /// <summary>
    /// XML ConfidenceScoreListSix Class contains ConfidenceScoreItem
    /// </summary>
    [Serializable()]
    [XmlRootAttribute("ConfidenceScoreListSix")]
    public class ConfidenceScoreListSix
    {
        [XmlElement("ConfidenceScoreItem")]
        public ConfidenceScoreItem[] ConfidenceScoreItems { get; set; }
    }

    /// <summary>
    ///  XML ConfidenceScoreItem Class
    /// </summary>
    public class ConfidenceScoreItem
    {
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string Message { get; set; }
    }
    /// <summary>
    /// XML PropSearched 
    /// </summary>
    ///  [Serializable()]
    [XmlRootAttribute("PropQuery")]
    public class PropSearched
    {
        [XmlAttribute]
        public string numProps { get; set; }
        [XmlArray("PropList")]
        [XmlArrayItem("Prop")]
        public Prop[] Props { get; set; }
    }
    /// <summary>
    /// XML PropAlg
    /// </summary>
    [Serializable()]
    [XmlRootAttribute("PropQuery")]
    public class PropAlg
    {
        [XmlAttribute]
        public string numProps { get; set; }
        [XmlElement("Prop")]
        public Prop[] Props { get; set; }
        public Regression Regression { get; set; }
    }

    /// <summary>
    /// Regression data
    /// </summary>
    public class Regression
    {
        public string Price { get; set; }
        public string Range { get; set; }
    }
    /// <summary>
    /// XML Prop
    /// </summary>
    public class Prop
    {
        [XmlAttribute]
        public string Rooms { get; set; }
        [XmlAttribute]
        public string Garages { get; set; }
        [XmlAttribute]
        public string Fireplaces { get; set; }
        [XmlAttribute]
        public string YearBuilt { get; set; }
        [XmlAttribute]
        public string Address { get; set; }
        [XmlAttribute]
        public string City { get; set; }
        [XmlAttribute]
        public string County { get; set; }
        [XmlAttribute]
        public string State { get; set; }
        [XmlAttribute]
        public string Zip { get; set; }
        [XmlAttribute]
        public string APN { get; set; }
        [XmlAttribute]
        public string Price { get; set; }
        [XmlAttribute]
        public string Date { get; set; }
        [XmlAttribute]
        public string Time { get; set; }
        [XmlAttribute]
        public string Dist { get; set; }
        [XmlAttribute]
        public string Sq_Ft { get; set; }
        [XmlAttribute]
        public string Beds { get; set; }
        [XmlAttribute]
        public string Baths { get; set; }
        [XmlAttribute]
        public string Stories { get; set; }
        [XmlAttribute]
        public string Year { get; set; }
        [XmlAttribute]
        public string Lot { get; set; }
        [XmlAttribute]
        public string Lat { get; set; }
        [XmlAttribute]
        public string Lon { get; set; }
        [XmlAttribute]
        public string Spec { get; set; }
        [XmlAttribute]
        public string DataSource { get; set; }
        [XmlAttribute]
        public string RelScore { get; set; }
        public string FC { get; set; }
        public string REO { get; set; }
        public string SS { get; set; }
    }
    
}