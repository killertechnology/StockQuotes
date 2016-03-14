using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Collections.Specialized;
using System.Configuration;

using System.Web.Services.Protocols;
using StockQuotes.stockQuoteRef;

namespace StockQuotes
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtTrialUser;
		protected System.Web.UI.WebControls.TextBox txtUserID;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnDisplay;
		protected System.Web.UI.WebControls.TextBox txtServiceOutput;
		protected System.Web.UI.WebControls.Button btnGetQuotes;
		protected System.Web.UI.WebControls.Label lblCompanyName;
		protected System.Web.UI.WebControls.Label lblStockTicker;
		protected System.Web.UI.WebControls.Label lblStockQuote;
		protected System.Web.UI.WebControls.Label lblLastUpdated;
		protected System.Web.UI.WebControls.Label lblChange;
		protected System.Web.UI.WebControls.Label lblOpenPrice;
		protected System.Web.UI.WebControls.Label lblDayHighPrice;
		protected System.Web.UI.WebControls.Label lblDayLowPrice;
		protected System.Web.UI.WebControls.Label lblVolume;
		protected System.Web.UI.WebControls.Label lblMarketCap;
		protected System.Web.UI.WebControls.Label lblYearRange;
		protected System.Web.UI.WebControls.Label lblExDividendDate;
		protected System.Web.UI.WebControls.Label lblDividendYield;
		protected System.Web.UI.WebControls.Label lblDividendPerShare;		
		protected System.Web.UI.HtmlControls.HtmlGenericControl ScrollPane;
		protected System.Web.UI.WebControls.TextBox txtTicker;
		protected System.Web.UI.WebControls.ListBox listBoxQuotes;
		protected System.Web.UI.WebControls.Panel OutputPanel;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Div1;
		protected System.Web.UI.WebControls.Label lblExTicker;

		private string WsUrl = "";		
		private stockQuoteRef.StockQuotes siService = null;		
		private Quote[] quotes;

		private void Page_Load(object sender, System.EventArgs e)
		{
			//Required license
			if(Request.Params["l"] != null)	this.txtUserID.Text = Request.Params["l"];

			
			//Instance of global address verification
			siService = new stockQuoteRef.StockQuotes();
			
			//Set config file
			WsUrl = SetWebConfig("WebSamples","StockQuotes");
			siService.Url =  WsUrl;
		}

		/// <summary>
		/// Config service name and service url in Web.config
		/// </summary>
		/// <param name="serviceName">A service name</param>
		/// <param name="serviceUrl">A service url</param>
		/// <returns>The service url for the service name</returns>
		private string SetWebConfig(string serviceName, string serviceUrl) 
		{
			string wsUrl = "";
			NameValueCollection collection = (NameValueCollection)ConfigurationSettings.GetConfig(serviceName);
			wsUrl = (string)collection.Get(serviceUrl);
			return wsUrl;
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnGetQuotes.Click += new System.EventHandler(this.btnGetQuotes_Click);
			this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// Invokes stock quote retrieval.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGetQuotes_Click(object sender, System.EventArgs e)
		{
			UnregisteredUser myunregistereduser = new UnregisteredUser();
			RegisteredUser myreguser = new RegisteredUser();
			
			myreguser.UserID = this.txtUserID.Text; 
			myreguser.Password = txtPassword.Text;
			myunregistereduser.EmailAddress = txtTrialUser.Text.Trim();
		
			//Set the license
			LicenseInfo header = new LicenseInfo();
			header.RegisteredUser = myreguser;
			header.UnregisteredUser =  myunregistereduser;
	
			siService.LicenseInfoValue = header;
			
			//Resets output fields.
			reset();

			try
			{
				string ticker = txtTicker.Text;

				if(ticker.Equals(""))
				{
					this.lblMessage.Text = BuildErrorMessagePane("Stock quote ticker must be provided. ");// clear error panel
					return;
				}
				
				//Executes service
				quotes = siService.GetStockQuotes(ticker);

				DisplayServiceResponses();
				
				this.lblMessage.Text = BuildErrorMessagePane("The stock quotes were retrieved successfully with the output below: ");// clear error panel
				displayQuotes(quotes);
				listBoxQuotes.Visible = true;
				
			}
			catch(SoapException ex) 
			{
				txtServiceOutput.Text = string.Format("Error: {0}\r\n", ex.Message); 
				
				lblMessage.Text = this.lblMessage.Text = BuildErrorMessagePane(ex.Message);
				listBoxQuotes.Items.Clear();
			}
			catch(Exception ex) 
			{
				txtServiceOutput.Text = "Error: please try again. \r\n\r\n" + ex.Message;
			}
		}

		/// <summary>
		/// Displays the service responses into the Service Output textbox.
		/// </summary>
		private void DisplayServiceResponses()
		{
			SubscriptionInfo subInfo = siService.SubscriptionInfoValue;
			if (subInfo == null)
			{
				this.txtServiceOutput.Text = "Error: please try again.";
				return;
			}			

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			
			sb.Append( string.Format( "Subscription Activity:\r\n" ));
			sb.Append( string.Format( "Amount: {0}\r\n",subInfo.Amount)); 
			sb.Append( string.Format( "License Action: {0}\r\n",subInfo.LicenseAction)); 
			sb.Append( string.Format( "License Action Code: {0}\r\n",subInfo.LicenseActionCode)); 
			sb.Append( string.Format( "License Status: {0}\r\n",subInfo.LicenseStatus));
			sb.Append( string.Format( "License Status Code: {0}\r\n",subInfo.LicenseStatusCode)); 
			sb.Append( string.Format( "Remaining Hits: {0}\r\n",subInfo.RemainingHits));
						
			this.txtServiceOutput.Text = sb.ToString();
			
		}
		
		/// <summary>
		/// Displays the selected stock quote information
		/// </summary>
		/// <param name="q"></param>
		private void displayQuotes(Quote[] q)
		{
			for (int m = 0; m < q.Length; m++)
			{
				String name = q[m].CompanyName;
				listBoxQuotes.Items.Insert(m,name);
				//build string and separate with ;
				listBoxQuotes.Items[m].Value = q[m].CompanyName + ";" + q[m].StockTicker + ";" + 
					q[m].StockQuote + ";" + q[m].LastUpdated + ";" + q[m].Change + ";" + 
					q[m].OpenPrice  + ";" +  q[m].DayHighPrice + ";" + q[m].DayLowPrice  + ";" + 
					q[m].Volume + ";" + q[m].MarketCap  + ";" + q[m].YearRange + ";" + 
					q[m].ExDividendDate + ";" + q[m].DividendYield  + ";" + q[m].DividendPerShare;
			}
			
			listBoxQuotes.SelectedIndex = 0;
			listBoxQuotes.Visible = true;
			btnDisplay.Visible = true;
		}

		/// <summary>
		/// Clears the output fields.
		/// </summary>
		private void ClearOutputInfo()
		{
			foreach (object ctrl in this.OutputPanel.Controls)
			{
				if (ctrl is Label)
				{
					Label lbl = (Label)ctrl;
					lbl.Text = String.Empty;
				}
			}						  
		}
		
		/// <summary>
		/// Displays the stock quote information.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDisplay_Click(object sender, System.EventArgs e)
		{
			int index = listBoxQuotes.SelectedIndex;
			int count = 0;
			string toParse = listBoxQuotes.Items[index].Value;
			char[] seps = {';'}; 
			string[] tokens = toParse.Split(seps);
			for (int x = 0; x < 14; x++)
			{				
				switch(count)
				{
					case 0: lblCompanyName.Text = tokens[x];
						count++;
						break;
					case 1:	lblStockTicker.Text = tokens[x];
						count++;
						break;
					case 2: lblStockQuote.Text = tokens[x];
						count++;
						break;
					case 3: lblLastUpdated.Text = tokens[x];
						count++;
						break;
					case 4: lblChange.Text = tokens[x];
						count++;
						break;
					case 5: lblOpenPrice.Text = tokens[x];
						count++;
						break;
					case 6: lblDayHighPrice.Text = tokens[x];
						count++;
						break;
					case 7: lblDayLowPrice.Text = tokens[x];
						count++;
						break;
					case 8:	lblVolume.Text = tokens[x];
						count++;
						break;
					case 9: lblMarketCap.Text = tokens[x];
						count++;
						break;
					case 10: lblYearRange.Text = tokens[x];
						count++;
						break;
					case 11: lblExDividendDate.Text = tokens[x];
						count++;
						break;
					case 12: lblDividendYield.Text = tokens[x];
						count++;
						break;
					default: lblDividendPerShare.Text = tokens[x];
						count++;
						break;
				}
			}
			OutputPanel.Visible = true;
		}

		/// <summary>
		/// Resets the output fields.
		/// </summary>
		private void reset()
		{
			listBoxQuotes.Items.Clear();
			listBoxQuotes.Visible = false;
			btnDisplay.Visible = false;

			ClearOutputInfo();
			OutputPanel.Visible = false;

			txtServiceOutput.Text = "";
		}

		/// <summary>
		/// Builds error message.
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public string BuildErrorMessagePane(string message)
		{
			return "<table cellspacing=1 cellpadding=0 bgcolor=#c0c0c0 width=90%><tr><td><table cellspacing=15 cellpadding=5 width=100% bgcolor=#FFFFE0><tr><td align=center><font color=red>"
				+ message +
				"</td></tr></table></td></tr></table>"; 
		}
	}
}
