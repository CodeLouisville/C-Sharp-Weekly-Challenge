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
    /// Represents a GAPI_DealerSetting.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>

	[Serializable()]
    [DataContract]
    public class GAPI_DealerSetting : INotifyPropertyChanged
    {

		public GAPI_DealerSetting()
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
		
		private int _GAPI_DealerSetting_ID;
		[DataMember]
        public int GAPI_DealerSetting_ID 
		{ 
			get 
			{
			 
				return _GAPI_DealerSetting_ID; 
				
			}
			set
			{
				if (value != this._GAPI_DealerSetting_ID)
                {
                    this._GAPI_DealerSetting_ID = value;
                    NotifyPropertyChanged("GAPI_DealerSetting_ID");
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
 
		
		private string _DefaultAccountId;
		[DataMember]
        public string DefaultAccountId 
		{ 
			get 
			{
			 
				if (_DefaultAccountId == null)
				{
						return string.Empty;
				}			
				else 
				{
						return _DefaultAccountId; 
				}
				
			}
			set
			{
				if (value != this._DefaultAccountId)
                {
                    this._DefaultAccountId = value;
                    NotifyPropertyChanged("DefaultAccountId");
                }
			}
		}
 
		
		private string _DefaultPropertyId;
		[DataMember]
        public string DefaultPropertyId 
		{ 
			get 
			{
			 
				if (_DefaultPropertyId == null)
				{
						return string.Empty;
				}			
				else 
				{
						return _DefaultPropertyId; 
				}
				
			}
			set
			{
				if (value != this._DefaultPropertyId)
                {
                    this._DefaultPropertyId = value;
                    NotifyPropertyChanged("DefaultPropertyId");
                }
			}
		}
 
		
		private string _DefaultViewId;
		[DataMember]
        public string DefaultViewId 
		{ 
			get 
			{
			 
				if (_DefaultViewId == null)
				{
						return string.Empty;
				}			
				else 
				{
						return _DefaultViewId; 
				}
				
			}
			set
			{
				if (value != this._DefaultViewId)
                {
                    this._DefaultViewId = value;
                    NotifyPropertyChanged("DefaultViewId");
                }
			}
		}
 
		
		private int _DefaultReportId;
		[DataMember]
        public int DefaultReportId 
		{ 
			get 
			{
			 
				return _DefaultReportId; 
				
			}
			set
			{
				if (value != this._DefaultReportId)
                {
                    this._DefaultReportId = value;
                    NotifyPropertyChanged("DefaultReportId");
                }
			}
		}
    }
}      
