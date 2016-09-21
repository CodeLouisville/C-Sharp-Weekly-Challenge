using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Configuration;
 
namespace GAPI_Library
{
    /// <summary>
    /// Represents a GAPI_Report.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>

	[Serializable()]
    [DataContract]
    public class GAPI_Report : INotifyPropertyChanged
    {

		public GAPI_Report()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
		
		private int _GAPI_Report_ID;
		[DataMember]
        public int GAPI_Report_ID 
		{ 
			get 
			{
			 
				return _GAPI_Report_ID; 
				
			}
			set
			{
				if (value != this._GAPI_Report_ID)
                {
                    this._GAPI_Report_ID = value;
                    NotifyPropertyChanged("GAPI_Report_ID");
                }
			}
		}
 
		
		private int _GAPI_ReportRequest_ID;
		[DataMember]
        public int GAPI_ReportRequest_ID 
		{ 
			get 
			{
			 
				return _GAPI_ReportRequest_ID; 
				
			}
			set
			{
				if (value != this._GAPI_ReportRequest_ID)
                {
                    this._GAPI_ReportRequest_ID = value;
                    NotifyPropertyChanged("GAPI_ReportRequest_ID");
                }
			}
		}
 
		
		private int _GAPI_ChartType_ID;
		[DataMember]
        public int GAPI_ChartType_ID 
		{ 
			get 
			{
			 
				return _GAPI_ChartType_ID; 
				
			}
			set
			{
				if (value != this._GAPI_ChartType_ID)
                {
                    this._GAPI_ChartType_ID = value;
                    NotifyPropertyChanged("GAPI_ChartType_ID");
                }
			}
		}
 
		
		private int _GAPI_ReportCategory_ID;
		[DataMember]
        public int GAPI_ReportCategory_ID 
		{ 
			get 
			{
			 
				return _GAPI_ReportCategory_ID; 
				
			}
			set
			{
				if (value != this._GAPI_ReportCategory_ID)
                {
                    this._GAPI_ReportCategory_ID = value;
                    NotifyPropertyChanged("GAPI_ReportCategory_ID");
                }
			}
		}
 
		
		private int _Dealer_ID;
		[DataMember]
        public int Dealer_ID 
		{ 
			get 
			{
			 
				return _Dealer_ID; 
				
			}
			set
			{
				if (value != this._Dealer_ID)
                {
                    this._Dealer_ID = value;
                    NotifyPropertyChanged("Dealer_ID");
                }
			}
		}
 
		
		private string _Dimensions;
		[DataMember]
        public string Dimensions 
		{ 
			get 
			{
			 
				if (_Dimensions == null)
				{
						return string.Empty;
				}			
				else 
				{
						return _Dimensions; 
				}
				
			}
			set
			{
				if (value != this._Dimensions)
                {
                    this._Dimensions = value;
                    NotifyPropertyChanged("Dimensions");
                }
			}
		}
 
		
		private string _Metrics;
		[DataMember]
        public string Metrics 
		{ 
			get 
			{
			 
				if (_Metrics == null)
				{
						return string.Empty;
				}			
				else 
				{
						return _Metrics; 
				}
				
			}
			set
			{
				if (value != this._Metrics)
                {
                    this._Metrics = value;
                    NotifyPropertyChanged("Metrics");
                }
			}
		}
 
		
		private string _ChartParams;
		[DataMember]
        public string ChartParams 
		{ 
			get 
			{
			 
				if (_ChartParams == null)
				{
						return string.Empty;
				}			
				else 
				{
						return _ChartParams; 
				}
				
			}
			set
			{
				if (value != this._ChartParams)
                {
                    this._ChartParams = value;
                    NotifyPropertyChanged("ChartParams");
                }
			}
		}
 
		
		private string _ReportTitle;
		[DataMember]
        public string ReportTitle 
		{ 
			get 
			{
			 
				if (_ReportTitle == null)
				{
						return string.Empty;
				}			
				else 
				{
						return _ReportTitle; 
				}
				
			}
			set
			{
				if (value != this._ReportTitle)
                {
                    this._ReportTitle = value;
                    NotifyPropertyChanged("ReportTitle");
                }
			}
		}
 
		
		private string _ReportSubTitle;
		[DataMember]
        public string ReportSubTitle 
		{ 
			get 
			{
			 
				if (_ReportSubTitle == null)
				{
						return string.Empty;
				}			
				else 
				{
						return _ReportSubTitle; 
				}
				
			}
			set
			{
				if (value != this._ReportSubTitle)
                {
                    this._ReportSubTitle = value;
                    NotifyPropertyChanged("ReportSubTitle");
                }
			}
		}
 
		
		private int? _ReportWidth;
		[DataMember]
        public int? ReportWidth 
		{ 
			get 
			{
			 
				return _ReportWidth; 
				
			}
			set
			{
				if (value != this._ReportWidth)
                {
                    this._ReportWidth = value;
                    NotifyPropertyChanged("ReportWidth");
                }
			}
		}
 
		
		private int? _ReportHeight;
		[DataMember]
        public int? ReportHeight 
		{ 
			get 
			{
			 
				return _ReportHeight; 
				
			}
			set
			{
				if (value != this._ReportHeight)
                {
                    this._ReportHeight = value;
                    NotifyPropertyChanged("ReportHeight");
                }
			}
		}
 
		
		private int _CreatedById;
		[DataMember]
        public int CreatedById 
		{ 
			get 
			{
			 
				return _CreatedById; 
				
			}
			set
			{
				if (value != this._CreatedById)
                {
                    this._CreatedById = value;
                    NotifyPropertyChanged("CreatedById");
                }
			}
		}
 
		
		private DateTime _CreatedDate;
		[DataMember]
        public DateTime CreatedDate 
		{ 
			get 
			{
			 
				if (_CreatedDate == DateTime.MinValue)
				{
						return new DateTime(1753, 1, 1);
				}			
				else 
				{
						return _CreatedDate; 
				}
				
			}
			set
			{
				if (value != this._CreatedDate)
                {
                    this._CreatedDate = value;
                    NotifyPropertyChanged("CreatedDate");
                }
			}
		}
 
		
		private int _LastModifiedById;
		[DataMember]
        public int LastModifiedById 
		{ 
			get 
			{
			 
				return _LastModifiedById; 
				
			}
			set
			{
				if (value != this._LastModifiedById)
                {
                    this._LastModifiedById = value;
                    NotifyPropertyChanged("LastModifiedById");
                }
			}
		}
 
		
		private DateTime _LastModifiedDate;
		[DataMember]
        public DateTime LastModifiedDate 
		{ 
			get 
			{
			 
				if (_LastModifiedDate == DateTime.MinValue)
				{
						return new DateTime(1753, 1, 1);
				}			
				else 
				{
						return _LastModifiedDate; 
				}
				
			}
			set
			{
				if (value != this._LastModifiedDate)
                {
                    this._LastModifiedDate = value;
                    NotifyPropertyChanged("LastModifiedDate");
                }
			}
		}
 
		
		private bool _Deleted;
		[DataMember]
        public bool Deleted 
		{ 
			get 
			{
			 
				return _Deleted; 
				
			}
			set
			{
				if (value != this._Deleted)
                {
                    this._Deleted = value;
                    NotifyPropertyChanged("Deleted");
                }
			}
		}
    }
}      
