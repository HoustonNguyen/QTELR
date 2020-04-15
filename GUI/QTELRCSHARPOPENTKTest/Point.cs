using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTELR_Interface
{
    class Point
    {
        private int X, Y, Z;
        private int colour;

        public Point(int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public int getX()
        {
            return this.X;
        }
        public int getY()
        {
            return this.Y;
        }

        public int getZ()
        {
            return this.Z;
        }

        public void setX(int X)
        {
            this.X = X;
        }
        public void setY(int Y)
        {
            this.Y = Y;
        }
        public void setZ(int Z)
        {
            this.Z = Z;
        }
    }
}
