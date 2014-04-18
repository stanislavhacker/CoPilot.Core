using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CoPilot.Core.Data
{
    public class NotifyObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Call property change on all
        /// </summary>
        public void CallPropertyChangedOnAll()
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
        }

        /// <summary>
        /// Raise property change
        /// </summary>
        /// <param name="prop"></param>
        public void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
