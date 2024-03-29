﻿using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;

/// <summary>
/// Summary description for Test
/// </summary>
[WebService(Namespace = "http://sudcz.com/webservice/test")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class TestService : System.Web.Services.WebService {

	public TestService() {
	}

	[WebMethod]
	public TestResult Test(int count, string name, string description) {
		TestResult result = new TestResult();
		result.Name = name;
		result.Description = description;
		if(count > 0) {
			result.Headers = new List<string>();
			for(int i=0;i<count;i++) {
				result.Headers.Add("This is header "+ (i + 1).ToString());
			}
		}
		return result;
	}

	public class TestResult : TestResultBase {
		private int _number = 0;
		private string _name = null;
		private string _description = "";

		public int Number {
			get { return _number; }
			set { _number = value; }
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		public string Description {
			get { return _description; }
			set { _description = value; }
		}
	}

	public class TestResultBase {
		private List<string> _headers = null;

		public List<string> Headers {
			get { return _headers; }
			set { _headers = value; }
		}
	}

}

