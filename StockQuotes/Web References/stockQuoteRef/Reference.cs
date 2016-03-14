﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.2032.
// 
namespace StockQuotes.stockQuoteRef {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="StockQuotesSoap", Namespace="http://swanandmokashi.com")]
    public class StockQuotes : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        public LicenseInfo LicenseInfoValue;
        
        public SubscriptionInfo SubscriptionInfoValue;
        
        /// <remarks/>
        public StockQuotes() {
            this.Url = "http://ws.strikeiron.com/SwanandMokashi/StockQuotes";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SubscriptionInfoValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.Out)]
        [System.Web.Services.Protocols.SoapHeaderAttribute("LicenseInfoValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://swanandmokashi.com/GetQuotes", RequestElementName="GetQuotes", RequestNamespace="http://swanandmokashi.com", ResponseElementName="GetQuotesResponse", ResponseNamespace="http://swanandmokashi.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("GetQuotesResult")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public Quote[] GetStockQuotes(string QuoteTicker) {
            object[] results = this.Invoke("GetStockQuotes", new object[] {
                        QuoteTicker});
            return ((Quote[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetStockQuotes(string QuoteTicker, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetStockQuotes", new object[] {
                        QuoteTicker}, callback, asyncState);
        }
        
        /// <remarks/>
        public Quote[] EndGetStockQuotes(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Quote[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SubscriptionInfoValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.Out)]
        [System.Web.Services.Protocols.SoapHeaderAttribute("LicenseInfoValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.strikeiron.com/SwanandMokashi/StockQuotes/GetRemainingHits", RequestNamespace="http://ws.strikeiron.com", ResponseNamespace="http://ws.strikeiron.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void GetRemainingHits() {
            this.Invoke("GetRemainingHits", new object[0]);
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetRemainingHits(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetRemainingHits", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public void EndGetRemainingHits(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.strikeiron.com")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://ws.strikeiron.com", IsNullable=false)]
    public class SubscriptionInfo : System.Web.Services.Protocols.SoapHeader {
        
        /// <remarks/>
        public int LicenseStatusCode;
        
        /// <remarks/>
        public string LicenseStatus;
        
        /// <remarks/>
        public int LicenseActionCode;
        
        /// <remarks/>
        public string LicenseAction;
        
        /// <remarks/>
        public int RemainingHits;
        
        /// <remarks/>
        public System.Decimal Amount;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://swanandmokashi.com")]
    public class Quote {
        
        /// <remarks/>
        public string CompanyName;
        
        /// <remarks/>
        public string StockTicker;
        
        /// <remarks/>
        public string StockQuote;
        
        /// <remarks/>
        public string LastUpdated;
        
        /// <remarks/>
        public string Change;
        
        /// <remarks/>
        public string OpenPrice;
        
        /// <remarks/>
        public string DayHighPrice;
        
        /// <remarks/>
        public string DayLowPrice;
        
        /// <remarks/>
        public string Volume;
        
        /// <remarks/>
        public string MarketCap;
        
        /// <remarks/>
        public string YearRange;
        
        /// <remarks/>
        public string ExDividendDate;
        
        /// <remarks/>
        public string DividendYield;
        
        /// <remarks/>
        public string DividendPerShare;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.strikeiron.com")]
    public class RegisteredUser {
        
        /// <remarks/>
        public string UserID;
        
        /// <remarks/>
        public string Password;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.strikeiron.com")]
    public class UnregisteredUser {
        
        /// <remarks/>
        public string EmailAddress;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.strikeiron.com")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://ws.strikeiron.com", IsNullable=false)]
    public class LicenseInfo : System.Web.Services.Protocols.SoapHeader {
        
        /// <remarks/>
        public UnregisteredUser UnregisteredUser;
        
        /// <remarks/>
        public RegisteredUser RegisteredUser;
    }
}
