<%@ Page language="c#" Codebehind="StockQuotes.aspx.cs" AutoEventWireup="false" Inherits="StockQuotes.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Stock Quotes web service 1.0.0 - StrikeIron Marketplace;</title>
		<meta content="Retrieves the latest (20 minutes delayed) stock quote for a stock ticker symbol. To get multiple quotes, enter ticker symbols separated by commas, (e.g. MSFT,YHOO,GE) or spaces (eg. MSFT YHOO GE). The Web services provides the Company Name, Ticker Symbol,"
			name="DESCRIPTION">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Web Service; WSDL;Stock Quotes; ticker; NASDAQ" name="KEYWORDS">
		<meta content="C#?" name="GENERATOR?>&#13;&#10;&#9;&#9;<meta name=" CODE_LANGUAGE>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style>A { COLOR: #3169b5 }
	A:visited { COLOR: #666 }
	BODY { FONT-SIZE: 11px; MARGIN: 0px; COLOR: #333; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #f3f3f3 }
	#appPage { BORDER-RIGHT: #c0c0c0 1px solid; PADDING-RIGHT: 30px; BORDER-TOP: #c0c0c0 1px solid; PADDING-LEFT: 30px; PADDING-BOTTOM: 30px; BORDER-LEFT: #c0c0c0 1px solid; WIDTH: 760px; PADDING-TOP: 30px; BORDER-BOTTOM: #c0c0c0 1px solid; HEIGHT: 1600px; BACKGROUND-COLOR: white; TEXT-ALIGN: left }
	FIELDSET { BORDER-RIGHT: #7f9db9 1px solid; BORDER-TOP: #7f9db9 1px solid; MARGIN-TOP: 2px; BORDER-LEFT: #7f9db9 1px solid; BORDER-BOTTOM: #7f9db9 1px solid; 10px: }
	LEGEND { FONT-WEIGHT: bold; COLOR: #3169b5 }
	H1 { FONT-SIZE: 14px; FONT-FAMILY: Arial }
	H2 { FONT-SIZE: 12px }
	TD { FONT-SIZE: 11px }
	.header { FONT-WEIGHT: bold; COLOR: #3169b5 }
	.style1 { FONT-SIZE: 12px }
	.style2 { FONT-SIZE: 12px }
	.style3 { FONT-WEIGHT: bold; COLOR: #ffffff }
	.style4 { FONT-WEIGHT: bold; FONT-SIZE: 14px; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.style5 { COLOR: #0000cc }
		</style>
	</HEAD>
	<body>
		<div id="appPage">
			<form id="WebForm1" method="post" runat="server">
				<a href="http://www.strikeiron.com/"><IMG style="MARGIN-TOP: 4px; FLOAT: left; MARGIN-BOTTOM: 3px; MARGIN-RIGHT: 10px; POSITION: relative; TOP: -4px"
						height="33" alt="StrikeIron " src="http://www.strikeiron.com/images/Logo_116.gif" width="116" border="0"></a><span class="style4">
					Stock Quotes web service<br>
				</span>Stock Quotes.
				<br>
				<br>
				<fieldset><legend>Enter License Information:</legend>
					<div style="MARGIN: 8px"><b>Unregistered?</b> Enter a valid email address in the 
						text box below to try the service. You will get additional trial hits once you 
						do register.</div>
					<table cellSpacing="4" cellPadding="0" align="center" wborder="0">
						<tr>
							<td vAlign="top" width="283">
								<table style="BORDER-RIGHT: #c0c0c0 1px solid; BORDER-TOP: #c0c0c0 1px solid; BORDER-LEFT: #c0c0c0 1px solid; WIDTH: 270px; BORDER-BOTTOM: #c0c0c0 1px solid; HEIGHT: 122px"
									height="120" cellSpacing="0" cellPadding="3" width="271" bgColor="#f2f3f9" border="0">
									<tr>
										<td style="WIDTH: 46px">&nbsp;</td>
										<td class="label1 style5" height="22">Unregistered User:</td>
									</tr>
									<tr>
										<td style="WIDTH: 46px; HEIGHT: 60px" vAlign="top"><strong>Email:&nbsp;</strong></td>
										<td style="HEIGHT: 60px" vAlign="top"><asp:textbox id="txtTrialUser" runat="server" Columns="30"></asp:textbox></td>
									</tr>
									<tr>
										<td style="WIDTH: 46px" vAlign="top">&nbsp;</td>
										<td vAlign="top">&nbsp;</td>
									</tr>
								</table>
							</td>
							<td class="style5 label1" align="center" width="18">OR</td>
							<td vAlign="top" width="345">
								<table style="BORDER-RIGHT: #c0c0c0 1px solid; BORDER-TOP: #c0c0c0 1px solid; BORDER-LEFT: #c0c0c0 1px solid; WIDTH: 321px; BORDER-BOTTOM: #c0c0c0 1px solid; HEIGHT: 120px"
									height="120" cellSpacing="0" cellPadding="3" width="270" bgColor="#f2f3f9" border="0">
									<tr>
										<td width="70">&nbsp;</td>
										<td class="label1 style5" width="229" height="22">Registered User\License Key:</td>
									</tr>
									<tr>
										<td style="HEIGHT: 23px" align="right"><strong>User ID:&nbsp;</strong></td>
										<td style="HEIGHT: 23px"><asp:textbox id="txtUserID" runat="server" Columns="30"></asp:textbox></td>
									</tr>
									<tr>
										<td style="HEIGHT: 23px" align="right"><br>
										</td>
										<td style="HEIGHT: 23px">(Email or License Key)</td>
									</tr>
									<tr>
										<td style="HEIGHT: 18px" align="right"><strong>Password:&nbsp;</strong></td>
										<td style="HEIGHT: 18px"><asp:textbox id="txtPassword" runat="server" Columns="30" TextMode="Password"></asp:textbox></td>
									</tr>
									<tr>
										<td align="right" height="23"></td>
										<td>(If using email)</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
					<div style="PADDING-RIGHT: 8px; PADDING-LEFT: 8px; PADDING-BOTTOM: 8px; PADDING-TOP: 8px"
						align="center"><asp:label id="lblMessage" runat="server"></asp:label></div>
				</fieldset>
				<FIELDSET><legend>Inputs</legend>
					<!--<div></div>-->
					<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="700" border="0">
						<TR>
							<TD style="WIDTH: 177px; HEIGHT: 26px" align="right"><strong>Quote Ticker:</strong></TD>
							<TD style="WIDTH: 176px; HEIGHT: 26px"><asp:textbox id="txtTicker" runat="server" Width="170px"></asp:textbox></TD>
							<TD style="HEIGHT: 26px">Example:
								<asp:label id="lblExTicker" runat="server" Font-Italic="True">amzn, msft</asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 177px" noWrap align="right"></TD>
							<TD style="WIDTH: 176px"></TD>
							<TD style="HEIGHT: 2px"></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 177px" noWrap align="right"></TD>
							<TD align="center" colSpan="1"><asp:button id="btnGetQuotes" runat="server" Width="104px" Text="Get Quotes"></asp:button>&nbsp;</TD>
						</TR>
					</TABLE>
				</FIELDSET>
				<fieldset style="WIDTH: 697px; HEIGHT: 208px"><legend>Stock Quotes</legend>
					<asp:listbox id="listBoxQuotes" runat="server" Width="688px" Height="160px" Visible="False"></asp:listbox>
					<TR>
						<DIV align="center">
							<asp:button id="btnDisplay" runat="server" Width="104px" Text="Display Quote" Visible="False"></asp:button></DIV>
					</TR>
				</fieldset>
				<fieldset><legend>Stock Quote Results Output</legend>
					<P>
						<!-- output --></P>
					<DIV id="ScrollPane" style="OVERFLOW: auto" runat="server"><asp:panel id="OutputPanel" Width="700px" Runat="server" Visible="False">
							<TABLE id="ResultQuote" cellSpacing="2" cellPadding="3" width="100%" border="0">
								<TR bgColor="#286ab6">
									<TD align="center" colSpan="2"><SPAN class="style3">Stock Quote Information</SPAN></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 17px" align="right" width="30%"><STRONG>Company Name:</STRONG></TD>
									<TD style="HEIGHT: 17px" width="70%">
										<asp:Label id="lblCompanyName" runat="server" Width="100%"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="right" width="30%"><STRONG>Stock Ticker:</STRONG></TD>
									<TD width="70%">
										<asp:Label id="lblStockTicker" runat="server" Width="100%"></asp:Label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 19px" align="right" width="30%"><STRONG>Stock Quote:</STRONG></TD>
									<TD style="HEIGHT: 19px" width="70%">
										<asp:Label id="lblStockQuote" runat="server" Width="100%"></asp:Label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 19px" align="right" width="30%"><STRONG>Last Updated:</STRONG></TD>
									<TD style="HEIGHT: 19px" width="70%">
										<asp:Label id="lblLastUpdated" runat="server" Width="100%"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="right" width="30%"><STRONG>Change:</STRONG></TD>
									<TD width="70%">
										<asp:Label id="lblChange" runat="server" Width="100%"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="right" width="30%"><STRONG>Open Price:</STRONG></TD>
									<TD width="70%">
										<asp:Label id="lblOpenPrice" runat="server" Width="100%"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="right" width="30%"><STRONG>Day High Price:</STRONG></TD>
									<TD width="70%">
										<asp:Label id="lblDayHighPrice" runat="server" Width="100%"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="right" width="30%"><STRONG>Day Low Price:</STRONG></TD>
									<TD width="70%">
										<asp:Label id="lblDayLowPrice" runat="server" Width="100%"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="right" width="30%"><STRONG>Volume:</STRONG></TD>
									<TD width="70%">
										<asp:Label id="lblVolume" runat="server" Width="100%"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="right" width="30%"><STRONG>Market Cap:</STRONG></TD>
									<TD width="70%">
										<asp:Label id="lblMarketCap" runat="server" Width="100%"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="right" width="30%"><STRONG>Year Range:</STRONG></TD>
									<TD width="70%">
										<asp:Label id="lblYearRange" runat="server" Width="100%"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="right" width="30%"><STRONG>Ex-Dividend Date:</STRONG></TD>
									<TD width="70%">
										<asp:Label id="lblExDividendDate" runat="server" Width="100%"></asp:Label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 18px" align="right" width="30%"><STRONG>Dividend Yield:</STRONG></TD>
									<TD style="HEIGHT: 18px" width="70%">
										<asp:Label id="lblDividendYield" runat="server" Width="100%"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="right" width="30%"><STRONG>Dividend Per Share:</STRONG></TD>
									<TD width="70%">
										<asp:Label id="lblDividendPerShare" runat="server" Width="100%"></asp:Label></TD>
								</TR>
							</TABLE> <!-- End result address --></asp:panel></DIV>
					<!-- end output--></fieldset>
				<p class="header"><strong>Service Responses:</strong></p>
				<asp:textbox id="txtServiceOutput" runat="server" TextMode="MultiLine" Width="488px" Height="170px"
					Font-Names="Verdana ,Helvetica,Sans-Serif" Font-Size="11px"></asp:textbox></form>
		</div>
		<!-- www2.hitslink.com/ web tools statistics hit counter code -->
		<script language="javascript" type="text/javascript">
		var data,nhp,ntz,rf,sr;document.cookie='__support_check=1';nhp='http';
		rf=document.referrer;sr=document.location.search;
		if(top.document.location==document.referrer
		|| (document.referrer == '' && top.document.location != ''))
		{rf=top.document.referrer;sr=top.document.location.search}
		ntz=new Date();if((location.href.substr(0,6)=='https:') || 
		(location.href.substr(0,6)=='HTTPS:'))nhp='https'; 
		data='&an='+escape(navigator.appName)+ '&ck='+document.cookie.length+
		'&sr='+escape(sr)+
		'&rf='+escape(rf)+ '&sl='+escape(navigator.systemLanguage)+
		'&av='+escape(navigator.appVersion)+ '&l='+escape(navigator.language)+
		'&pf='+escape(navigator.platform)+ '&pg='+escape(location.pathname);
		if(navigator.appVersion.substring(0,1)>'3') {data=data+'&cd='+
		screen.colorDepth+'&rs='+escape(screen.width+ ' x '+screen.height)+
		'&tz='+ntz.getTimezoneOffset()+'&je='+ navigator.javaEnabled()};
		document.write('<img border=0 hspace=0 '+
		 'vspace=0 width=1 height=1 src="'+nhp+'://counter2.hitslink.com/'+
		 'statistics.asp?v=1&s=207&acct=strikeiron'+data+'">');</script>
		<script language="javascript1.2" type="text/javascript">document.write('<');
		document.write('!--  ');</script>
		<noscript>
			<img height="1" hspace="0" src="http://counter2.hitslink.com/stats-ns.asp?acct=strikeiron&amp;v=1&amp;s=207"
				width="1" vspace="0" border="0">
		</noscript>
		<!--//-->
		<!-- End www2.hitslink.com/ statistics web tools hit counter code -->
	</body>
</HTML>
