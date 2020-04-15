//Default
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

//OpenTK
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

// Kinect
using Microsoft.Kinect;


namespace QTELR_Interface
{
    public partial class QTELRMainWindow : Form
    {
        // Variable and Object Declarations
        bool loaded = true;
        //viewingAngle = {angle for X, angle for Y, angle for Z, pan X, pan Y, pan Z, Zoom)
        double[] viewingAngle = new double[7];
        Bitmap img;
        int skipPixels = 4;
        Point[] points;

        //Kinect Stuff
        // Controls resolution
        private int frameWidth = 640, frameHeight = 480;

        // Kinect object
        KinectSensor sensor;

        // This holds depth data
        private short[] pixelData;
    
        // Constructor and Initializer
        // Creates the form/window
        public QTELRMainWindow()
        {
            InitializeComponent();
            SphereCoordinates.setCoordinates(0, 0, 1000);
            SphereCoordinates.setRadius(1000);
            //trackBar_rotateX.Value = 0;
            //trackBar_rotateY.Value = 0;
            //trackBar_rotateZ.Value = 0;
            trackBar_panX.Value = 0;
            trackBar_panY.Value = 0;
            trackBar_panZ.Value = 0;
            //trackBar_zoom.Value = 1000;
            createModelGroup();
            setUpKinect();
        }

        // Functions for File Input
        // Starts the Open File Dialogue
        private void button_OpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        // Once file is selected, file is loaded as the Bitmap
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            textBox_FileDirectory.Clear();
            textBox_FileDirectory.AppendText(openFileDialog.FileName);
            img = new Bitmap(openFileDialog.FileName);
            loaded = true;
            glControl1.Invalidate();
        }

        // Event Methods for Controlling Perspective on GUI
        // RotateX value changed event
        // This method assigns a new value to the angle to be used in calculating camera position on the XZ plane
        private void trackBar_rotateX_ValueChanged(object sender, System.EventArgs e)
        {
            viewingAngle[0] = (trackBar_rotateX.Value / 10000.0);
            SphereCoordinates.updateCoordinates(viewingAngle[0], viewingAngle[1], viewingAngle[2]);
            glControl1.Invalidate();
        }

        // rotateY value changed event
        // This method does nothing, yet
        private void trackBar_rotateY_ValueChanged(object sender, System.EventArgs e)
        {
            viewingAngle[1] = (System.Math.Round(trackBar_rotateY.Value / 10000.0));
            //SphereCoordinates.updateCoordinates(viewingAngle[0], viewingAngle[1], viewingAngle[2]);
            glControl1.Invalidate();
        }

        // rotateZ value changed event
        // This method does nothing yet
        private void trackBar_rotateZ_ValueChanged(object sender, System.EventArgs e)
        {
            viewingAngle[2] = (System.Math.Round(trackBar_rotateZ.Value / 10000.0));
            //SphereCoordinates.updateCoordinates(viewingAngle[0], viewingAngle[1], viewingAngle[2]);
            glControl1.Invalidate();
        }

        // This method is used to move the focus point of the camera along the X axis
        private void trackBar_panX_ValueChanged(object sender, System.EventArgs e)
        {
            viewingAngle[3] = (System.Math.Round((double)trackBar_panX.Value));
            glControl1.Invalidate();
        }

        // This method is used to move the focus point of the camera along the Y axis
        private void trackBar_panY_ValueChanged(object sender, System.EventArgs e)
        {
            viewingAngle[4] = (System.Math.Round((double)trackBar_panY.Value));
            glControl1.Invalidate();
        }

        // This method is used to move the focus point of the camera along the Z axis
        private void trackBar_panZ_ValueChanged(object sender, System.EventArgs e)
        {
            viewingAngle[5] = (System.Math.Round((double)trackBar_panZ.Value));
            glControl1.Invalidate();
        }

        // This method is used to adjust a radius of the sphere the coordinate system of the camera
        // is based on. This means that the larger the radius, the further zoomed out you are.
        private void trackBar_zoom_ValueChanged(object sender, System.EventArgs e)
        {
            viewingAngle[6] = (trackBar_zoom.Value);
            SphereCoordinates.setRadius(viewingAngle[6]);
            SphereCoordinates.updateCoordinates(viewingAngle[0], viewingAngle[1], viewingAngle[2]);
            glControl1.Invalidate();
        }

        // Function for loading the canvas/game window/3D view
        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.Black);
            SetupViewport();
        }

        // Function determines what happens when the window is resized. 
        // Does nothing, yet.
        private void glControl1_Resize(object sender, EventArgs e)
        {
            // Recalculate positions of components in Form
        }

        // This is the main function for determining what will be rendered
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Basic Setup for viewing
            Matrix4d perspective = Matrix4d.CreatePerspectiveFieldOfView(1.04f, 3/4f, 1f, 100000f);

            //Setup Perspective
            //the first argument (Set of 3) is the location of your camera, so m_eye seems correct
            //the second argument (Set of 3) is the point the camera centers on, so you'll want a 
            //location relative to your eye location or you'll always be focused on a single point in space
            //the third argument (Set of 3) is to indicate what direction should be considered "up"
            Matrix4d lookat = Matrix4d.LookAt(SphereCoordinates.getX(),
                SphereCoordinates.getY(), SphereCoordinates.getZ(), viewingAngle[3], viewingAngle[4], viewingAngle[5], 
                0, -1, 0);
            
            //Set labels
            cameraPositionLabel.Text = "<" + Math.Round(SphereCoordinates.getX()) + ", " + Math.Round(SphereCoordinates.getY()) + ", " + 
                Math.Round(SphereCoordinates.getZ()) + "> with Radius: " + SphereCoordinates.getRadius();
            lookingAtLabel.Text = "<" + Math.Round(viewingAngle[3]) + ", " + Math.Round(viewingAngle[4]) + ", " +
                Math.Round(viewingAngle[5]) + ">";

            //Setup camera
            GL.MatrixMode(MatrixMode.Projection);

            //Load Perspective
            GL.LoadIdentity();
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);

            //Load Camera
            GL.LoadIdentity();
            GL.LoadMatrix(ref lookat);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);

            //Size of window
            GL.Enable(EnableCap.DepthTest);

            //Enable correct Z Drawings
            GL.DepthFunc(DepthFunction.Less);

           // GL.Rotate(1, 0, 1, 0);

            GL.PushMatrix();

            //Rotating
            //GL.Rotate(1, 0, 0, 1);
            //GL.Rotate(1, 0, 1, 0);
            // Translation of object across axii
            //GL.Translate(new Vector3((float)this.viewingAngle[3], (float)this.viewingAngle[4], (float)this.viewingAngle[5]));

            
        
            // Objects to be displayed go here.
            //Draw pyramid, Y is up and down, Z is towards you, X is left and right
            //Vertex goes (X,Y,Z)
            GL.Begin(PrimitiveType.Points);
            paintVertices();
            GL.End();


            GL.Begin(PrimitiveType.Lines);
            //Line X
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(100, 0, 0);

            //Line Y
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 100, 0);

            //Line Z
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 100);
           
            GL.End();

            GL.PopMatrix();

            //Rotating
            //GL.Rotate(1, 0, 0, 1);
            //GL.Rotate(1, 0, 1, 0);

            glControl1.SwapBuffers();
        }

        ////This method scans the input image and instaiates vertices based on colour
        //private void methodConversion()
        //{
        //    if (loaded)
        //    {
        //        for (int i = 0; i < img.Width; i += skipPixels)
        //        {
        //            for (int j = 0; j < img.Height; j += skipPixels)
        //            {
        //                GL.Color3(Color.White);
        //                GL.Vertex3(i - img.Width / 2, j - img.Height / 2,
        //                    ((double)img.GetPixel(i, j).R + (double)img.GetPixel(i, j).G + (double)img.GetPixel(i, j).B) / 3);
        //            }
        //        }
        //    }             
        //}

        // This function setups the parameters of the canvas/game window/3D view
        private void SetupViewport()
        {
            int w = glControl1.Width;
            int h = glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
        }

        //This allows another class to reference the picturebox in the form
        //and updates it with a bitmap.
        public void updatePictureBox(Bitmap bmp)
        {
            bitmapDisplayBox.Image = bmp;
        }

        public void createModelGroup()
        {
            points = new Point[frameWidth * frameHeight];
            int i = 0;
            for (int y = 0; y < frameHeight; y += skipPixels)
            {
                for (int x = 0; x < frameWidth; x += skipPixels)
                {
                    points[i] = new Point(x, y, 0);
                    i++;
                }
            }
        }

        // Update depth data
        public void inputDepthData(short[] input)
        {
            int temp = 0;
            int i = 0;
            //Go through the whole array and reassign depth
            for (int y = 0; y < frameHeight; y += skipPixels)
            {
                for (int x = 0; x < frameWidth; x += skipPixels)
                {
                    //I don't know what the operation below does, but changing the 5 seriously messes up the depths
                    //temp = ((ushort)input[x + y * frameWidth]) >> 5; //original
                    temp = ((short)input[x + y * frameWidth]) >> 5;
                    //temp = (short)input[x + y * frameWidth]
                    //((TranslateTransform3D)points[i].Transform).OffsetZ = temp; //Original formula
                    points[i].setZ(temp);
                    i++;
                }
            }
        }

        //updateVertice Positions
        public void paintVertices()
        {
            int i = 0;
            if (loaded)
            {
                for (int y = 0; y < frameHeight; y += skipPixels)
                {
                    for (int x = 0; x < frameWidth; x += skipPixels)
                    {
                        GL.Color3(Color.White);
                        GL.Vertex3(points[i].getX() - frameWidth / 2, // Assigns X value
                            points[i].getY() - frameHeight/2, // Assigns Y value
                            points[i].getZ() - ((frameHeight+frameWidth)/2)/2); //Assigns Z value
                        i++;
                    }
                }
            }
            glControl1.Invalidate();
        }

        private void setUpKinect()
        {
            //Initialize the Kinect Sensor
            sensor = KinectSensor.KinectSensors[0];
            //Detect Resolution
            if (frameWidth == 640 && frameHeight == 480)
            {
                sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
            }
            else if (frameWidth == 320 && frameHeight == 240)
            {
                sensor.DepthStream.Enable(DepthImageFormat.Resolution320x240Fps30);
            }
            else if (frameWidth == 80 && frameHeight == 60)
            {
                sensor.DepthStream.Enable(DepthImageFormat.Resolution80x60Fps30);
            }
            else
            {
                Console.WriteLine("Invalid Resolution. Shutting Down Application.");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

            sensor.DepthFrameReady += DepthFrameReady;
            sensor.Start();
            Console.WriteLine("Kinect Sensor Ready.");
            loaded = true;
        }

        //Event Kinect New Frame
        void DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            DepthImageFrame imageFrame = e.OpenDepthImageFrame();
            if (imageFrame != null && loaded)
            {
                pixelData = new short[imageFrame.PixelDataLength];
                imageFrame.CopyPixelDataTo(pixelData);
                inputDepthData(pixelData);

                //add a.....bool to stop this thingngkrhgaekohnrgjenagjrerngv
                //Save to file pixelData
                //Console.WriteLine("New file");
                //FileWriter.writeShort2TXT(pixelData);
            }
        }
    }
}