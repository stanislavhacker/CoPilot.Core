
using CoPilot.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoPilot.Core.Utils
{
    public class MediaWithProgress : INotifyPropertyChanged
    {
        public Video Preview { get; set; }
        public Picture Picture { get; set; }
        public Video Video { get; set; }
        public ProgressUpdater Progress { get; set; }
        public Boolean IsChecked { get; set; }
        public String Size { get; set; }

        #region PROPERTY CHANGE

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

        #endregion PROPERTY CHANGE

    }
}
