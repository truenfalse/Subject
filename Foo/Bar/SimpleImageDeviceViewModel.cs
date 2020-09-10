using Bar.Abstract;
using Bar.Devices;
using Bar.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Bar
{
    public class SimpleImageDeviceViewModel : ViewModelBase
    {
        #region Fields
        Bitmap m_OutputImage;
        #endregion
        #region Properties
        public SimpleImageDevice Device { get; set; }
        public Bitmap OutputImage 
        {
            get
            {
                return m_OutputImage;
            }
            set
            {
                Set<Bitmap>(ref m_OutputImage, value);
            }
        }
        public ICommand GrabCommand { get; set; }
        public ICommand BrowseCommand { get; set; }
        #endregion
        public SimpleImageDeviceViewModel()
        {
            GrabCommand = new RelayCommand(GrabAction, GrabPredicate);
            BrowseCommand = new RelayCommand(BrowseAction, BrowsePredicate);
        }
        private bool BrowsePredicate(object obj)
        {
            if (Device == null)
                return false;
            return true;
        }
        private void BrowseAction(object obj)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(dialog.SelectedPath);
                var imagefiles = (from filename in files
                                 where System.IO.Path.GetExtension(filename) == ".bmp" || System.IO.Path.GetExtension(filename) == ".png"
                                  select filename).ToList();

                (Device.Params as SimpleImageDeviceParams).ImagePathCollection = imagefiles;
            }
        }
        private bool GrabPredicate(object obj)
        {
            if (Device == null)
                return false;
            return true;
        }
        private void GrabAction(object obj)
        {
            IImage image;
            Device.Grab(out image);
            if(Device.ErrorCode == 0)
            { 
                OutputImage = image.ToBitmap();
            }
        }
    }
}
