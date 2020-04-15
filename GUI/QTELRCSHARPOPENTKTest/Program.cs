using System;
using System.Drawing;
using System.Windows.Forms;
using QTELR_Interface;

namespace QTELR_Interface

{
    class MyApplication
    {
        // Declared so that other classes can reference these objects
        public static DataReceiverTCP pointCloudReceiver;
        public static KinectManager kinectManager;
        public static QTELRMainWindow mainWindow;

        [STAThread]
        public static void Main()
        {
            //Instantiate objects
            //pointCloudReceiver = new DataReceiverTCP();
            //kinectManager = new KinectManager();
            mainWindow = new QTELRMainWindow(); 
            Application.Run(mainWindow);

            
        }
    }
}