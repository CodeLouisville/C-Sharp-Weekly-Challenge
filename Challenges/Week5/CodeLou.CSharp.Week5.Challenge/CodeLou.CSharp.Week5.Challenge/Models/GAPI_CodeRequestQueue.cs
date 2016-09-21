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
    /// Represents a GAPI_CodeRequestQueue.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>

	[Serializable()]
    [DataContract]
    public class GAPI_CodeRequestQueue : INotifyPropertyChanged
    {

		public GAPI_CodeRequestQueue()
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
		
		private int _GAPI_CodeRequestQueue_ID;
		[DataMember]
        public int GAPI_CodeRequestQueue_ID 
		{ 
			get 
			{
			 
				return _GAPI_CodeRequestQueue_ID; 
				
			}
			set
			{
				if (value != this._GAPI_CodeRequestQueue_ID)
                {
                    this._GAPI_CodeRequestQueue_ID = value;
                    NotifyPropertyChanged("GAPI_CodeRequestQueue_ID");
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
 
		
		private bool _Verified;
		[DataMember]
        public bool Verified 
		{ 
			get 
			{
			 
				return _Verified; 
				
			}
			set
			{
				if (value != this._Verified)
                {
                    this._Verified = value;
                    NotifyPropertyChanged("Verified");
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
 
		
		private string _ErrorType;
		[DataMember]
        public string ErrorType 
		{ 
			get 
			{
			 
				if (_ErrorType == null)
				{
						return string.Empty;
				}			
				else 
				{
						return _ErrorType; 
				}
				
			}
			set
			{
				if (value != this._ErrorType)
                {
                    this._ErrorType = value;
                    NotifyPropertyChanged("ErrorType");
                }
			}
		}
 
		
		private bool _HasError;
		[DataMember]
        public bool HasError 
		{ 
			get 
			{
			 
				return _HasError; 
				
			}
			set
			{
				if (value != this._HasError)
                {
                    this._HasError = value;
                    NotifyPropertyChanged("HasError");
                }
			}
		}
    }
}      
