using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CoPilot.Core.Utils
{
    public class ProgressUpdater : INotifyPropertyChanged
    {
        /// <summary>
        /// Percent
        /// </summary>
        public Double percent = 0;
        public Double Percent
        { 
            get 
            {
                return percent;
            }
            set 
            {
                percent = value;
                RaisePropertyChanged();
            }
       }

        /// <summary>
        /// Speed
        /// </summary>
        public Double speed = 0;
        public Double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Size
        /// </summary>
        public Double size = 0;
        public Double Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Eta
        /// </summary>
        public String eta = "";
        public String Eta
        {
            get
            {
                return eta;
            }
            set
            {
                eta = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// IsIndetermine
        /// </summary>
        public Boolean isIndetermine = false;
        public Boolean IsIndetermine
        {
            get
            {
                return isIndetermine;
            }
            set
            {
                isIndetermine = value;
                RaisePropertyChanged();
            }
        }


        #region PROPERTY CHANGE

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// On property change
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            });
        }

        /// <summary>
        /// Raise proeprty change
        /// </summary>
        /// <param name="caller"></param>
        public void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(caller));
                }
            });
        }


        /// <summary>
        /// Call property change on all
        /// </summary>
        public void CallPropertyChangedOnAll()
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
        }

        #endregion
    }
}
