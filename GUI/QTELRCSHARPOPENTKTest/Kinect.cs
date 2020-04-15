using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

/*
 * This class manages the Kinect.
 * It provides all of the functions necessary to
 * use the Kinect aand to get data from it.
 * It is no currectly being used because, for some reason, the WPF form class 
 * won't accept data from the Kinect Manager or something.
 */
namespace QTELR_Interface
{
    class KinectManager
    {

        //Variable declarations
        private KinectSensor sensor;
        private DepthImagePixel[] depthPixels;
        private byte[] colorPixels;
        private WriteableBitmap colorBitmap;
        private DepthImageFrame depthFrame;
        private Thread kinectManagementThread;

        //Just used for testing WPF
        //Contaisn depth data
        private short[] pixelData;

        // Constructor
        public KinectManager()
        {
            // Kinect manager has its own thread so that
            // It can do stuff while
            // the app is listening for connections and
            // doing form stuff
            kinectManagementThread = new Thread(startUp);
            kinectManagementThread.Start();
        }

        // Initialization
        // Goes through the process of starting
        // the Kinect
        private void startUp()
        {
            Console.WriteLine("Attempting to start Kinect...");
            getSensor();
            if(sensor != null)
            {
                prepareSensor();
                startSensor();
            }
            else
                // Something went wrong and the Kinect couldn't be started.
                Console.WriteLine("Kinect could not be started.");
        }

        // Instantiate sensor with device
        // Looks for the physical Kinect
        private void getSensor()
        {
            Console.WriteLine("Looking for Kinect...");
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    Console.WriteLine("Kinect Found and Connected.");
                    break;
                }
                else
                    Console.WriteLine("Kinect not found.");
            }
        }

        // This starts all of the streams
        // Right now, only the depth stream is started for testing.
        private void prepareSensor()
        {
            Console.WriteLine("Attempting to prepare Kinect sensors...");
            if (this.sensor != null)
            { 
                //this.sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                //this.sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                this.sensor.DepthStream.Enable(DepthImageFormat.Resolution320x240Fps30);
                //this.sensor.SkeletonStream.Enable();
                //this.sensor.ColorStream.Enable(ColorImageFormat.InfraredResolution640x480Fps30);
                // Register an event that fires when data is ready
                this.sensor.DepthFrameReady += SensorDepthFrameReady;
                Console.WriteLine("Kinect Sensors Ready.");
            }
        }

        // Starts the device.
        private void startSensor()
        {
            Console.WriteLine("Starting Kinect...");
            if (this.sensor != null)
            {
                this.sensor.Start();
                Console.WriteLine("Kinect Started.");
            }
        }

        // Event handler for when data is ready
        private void SensorDepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            //Console.WriteLine("Depth Sensor Ready Event Fired.");
            // Get the data
            //using (depthFrame = e.OpenDepthImageFrame())
            //{
            //    if (depthFrame != null)
            //    {
            //        //Console.WriteLine("DepthFrame is not null.");
            //        allocateStorage();
            //        if (depthPixels != null)
            //        {
            //            //Console.WriteLine("DepthPixels is not null.");
            //            //depthFrame.CopyDepthImagePixelDataTo(this.depthPixels);

            //            if(MyApplication.mainWindowWPF.isReadyToReceive())
            //            {
            //                pixelData = new short[depthFrame.PixelDataLength];
            //                depthFrame.CopyPixelDataTo(pixelData);
            //                //Console.WriteLine("Event Firing. Updating field");
            //                QTELR_Interface.MyApplication.mainWindowWPF.inputDepthData(pixelData);
            //            }
                        
                        
            //            //createBitmap();
            //            //depth2RGB();
            //            //store2Bitmap();

            //            ////Testing displaying generated Bitmap to PictureBox
            //            //Bitmap bmp;
            //            //bmp = bitmapWriter.BitmapFromWriteableBitmap(colorBitmap);
            //            //MyApplication.mainWindow.updatePictureBox(bmp);
            //            ////bmp.Dispose();
            //        }
            //    }
            //    else
            //    {
            //        // depthFrame is null because the request did not arrive in time
            //        //Console.WriteLine("DepthFrame is null.");
            //    }

                // Take the Depth frame and...
                DepthImageFrame imageFrame = e.OpenDepthImageFrame();
                if (imageFrame != null)
                {
                    // Checks to see if the WPF window is ready
                    
                        // Writes the depth frame data into an array of short ints
                        // Which represent depths
                        pixelData = new short[imageFrame.PixelDataLength];
                        imageFrame.CopyPixelDataTo(pixelData);
                        // Passes it to the WPF form
                        //QTELR_Interface.MyApplication.mainWindowWPF.inputDepthData(pixelData);
                }
            //}
        }

        //Allocate storage for the data
        private void allocateStorage()
        {
            this.depthPixels = new DepthImagePixel[this.sensor.DepthStream.FramePixelDataLength];
            this.colorPixels = new byte[this.sensor.DepthStream.FramePixelDataLength * sizeof(int)];
        }

        //Create a bitmap
        //Create a bitmap to store the new pixel data.
        //You could create a Bitmap every frame, but you will get much better performance 
        //creating a WriteableBitmap only when the pixel format changes, such as when you start the application.
        private void createBitmap()
        {
            this.colorBitmap = new WriteableBitmap(this.sensor.DepthStream.FrameWidth, this.sensor.DepthStream.FrameHeight, 96.0,
                96.0, PixelFormats.Bgr32, null);
        }

        private void depth2RGB()
        {
            // Get the min and max reliable depth for the current frame
            int minDepth = depthFrame.MinDepth;
            int maxDepth = depthFrame.MaxDepth;

            // Convert the depth to RGB
            int colorPixelIndex = 0;
            for (int i = 0; i < this.depthPixels.Length; ++i)
            {
                // Get the depth for this pixel
                short depth = depthPixels[i].Depth;

                // To convert to a byte, we're discarding the most-significant
                // rather than least-significant bits.
                // We're preserving detail, although the intensity will "wrap."
                // Values outside the reliable depth range are mapped to 0 (black).

                // Note: Using conditionals in this loop could degrade performance.
                // Consider using a lookup table instead when writing production code.
                // See the KinectDepthViewer class used by the KinectExplorer sample
                // for a lookup table example.
                byte intensity = (byte)(depth >= minDepth && depth <= maxDepth ? depth : 0);

                // Write out blue byte
                this.colorPixels[colorPixelIndex++] = intensity;

                // Write out green byte
                this.colorPixels[colorPixelIndex++] = intensity;

                // Write out red byte                        
                this.colorPixels[colorPixelIndex++] = intensity;

                // We're outputting BGR, the last byte in the 32 bits is unused so skip it
                // If we were outputting BGRA, we would write alpha here.
                ++colorPixelIndex;
            }
      
        }

        //Store the data in the bitmap
        //After you get the color data and save it locally, use the WriteableBitmap to display the mapped depth data.
        private void store2Bitmap()
        {
           this.colorBitmap.WritePixels(new Int32Rect(0, 0, this.colorBitmap.PixelWidth, this.colorBitmap.PixelHeight),
           this.colorPixels, this.colorBitmap.PixelWidth * sizeof(int), 0);
        }
    }
}
