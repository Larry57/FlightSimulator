// --------------------------------------------------------------------------------------------------
// This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
// Version 1.3.6.20110331_01     
// 11/05/19 19:45    
// ${CustomMessageForDisclaimer}                                                                             
// --------------------------------------------------------------------------------------------------
namespace Jp.Maker1.Vsys3.Tools
{

    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class Polygon3D
    {
        internal readonly int MAX_VERTEX;
        internal Vector3D[] vertex;
        internal int n_vertex;

        public Polygon3D()
        {
            MAX_VERTEX = 64;
            vertex = new Vector3D[64];
            n_vertex = 0;
        }

        public Polygon3D(int n, double[] x, double[] y, double[] z)
        {
            MAX_VERTEX = 64;
            vertex = new Vector3D[64];
            n_vertex = 0;
            for (int i = 0; i < n; i++)
            {
                Vector3D v = new Vector3D(x[i], y[i], z[i]);
                AddVertex(v);
            }
        }

        public Polygon3D(Polygon3D pl)
        {
            MAX_VERTEX = 64;
            vertex = new Vector3D[64];
            n_vertex = 0;
            for (int i = 0; i < pl.NVertex(); i++)
                AddVertex(new Vector3D(pl.GetVertex(i)));
        }

        public void AddVertex(Vector3D v)
        {
            if (n_vertex < 64)
            {
                vertex[n_vertex] = v;
                n_vertex += 1;
            }
        }

        public void SetVertex(int i, Vector3D v)
        {
            vertex[i] = v;
        }

        public Vector3D Nomal_vartex1()
        {
            Vector3D ret = new Vector3D();

            if (n_vertex >= 3)
            {
                double x0 = GetVertex(0).x;
                double y0 = GetVertex(0).y;
                double z0 = GetVertex(0).z;
                double x1 = GetVertex(1).x;
                double y1 = GetVertex(1).y;
                double z1 = GetVertex(1).z;
                double x2 = GetVertex(2).x;
                double y2 = GetVertex(2).y;
                double z2 = GetVertex(2).z;

                Vector3D v01 = new Vector3D(x0 - x1, y0 - y1, z0 - z1);
                Vector3D v12 = new Vector3D(x2 - x1, y2 - y1, z2 - z1);
                ret = v01.CrsProd(v12).NmlVec();
            }
            return ret;
        }

        public bool BackfaceCheck()
        {
            if (n_vertex >= 3)
            {
                Vector3D vp = Nomal_vartex1();
                Vector3D ve = new Vector3D(0.0D, 0.0D, 0.0D);
                ve = ve.Sub(GetVertex(1)).NmlVec();
                double c = ve.DotProd(vp);

                return c >= 0.0D;
            }

            return true;
        }

        public Vector3D GetVertex(int i)
        {
            if ((i >= 0) && (i < NVertex()))
            {
                return vertex[i];
            }
            return null;
        }

        public int[] IxArray()
        {
            int[] ret = new int[NVertex()];

            for (int i = 0; i < NVertex(); i++)
            {
                ret[i] = (int)(GetVertex(i).x + 0.5D);
            }
            return ret;
        }

        public int[] IyArray()
        {
            int[] ret = new int[NVertex()];

            for (int i = 0; i < NVertex(); i++)
            {
                ret[i] = (int)(GetVertex(i).y + 0.5D);
            }
            return ret;
        }

        public Point[] xyArray()
        {
            Point[] ret = new Point[NVertex()];

            for (int i = 0; i < NVertex(); i++)
            {
                ret[i].X = (int)(GetVertex(i).x + 0.5D);
                ret[i].Y = (int)(GetVertex(i).y + 0.5D);
            }

            return ret;
        }

        //public int[] IzArray()
        //{
        //    int[] ret = new int[NVertex()];

        //    for (int i = 0; i < NVertex(); i++)
        //    {
        //        ret[i] = (int)(GetVertex(i).z + 0.5D);
        //    }
        //    return ret;
        //}

        public int NVertex()
        {
            return n_vertex;
        }

        public void Print()
        {
            for (int i = 0; i < NVertex(); i++)
            {
                if (i != 0)
                    System.Console.Out.Write("��");
                GetVertex(i).PrintPos();
            }
            System.Console.Out.WriteLine(";");
        }

        public Polygon3D Project(Projector proj)
        {
            Polygon3D ret = new Polygon3D();

            for (int i = 0; i < NVertex(); i++)
            {
                ret.AddVertex(proj.Project(GetVertex(i)));
            }

            return ret;
        }

        public void SetPol(int n, double[] x, double[] y, double[] z)
        {
            for (int i = 0; i < n; i++)
                AddVertex(new Vector3D(x[i], y[i], z[i]));
        }

        public void SetPol(Polygon3D pl)
        {
            for (int i = 0; i < pl.NVertex(); i++)
                AddVertex(new Vector3D(pl.GetVertex(i)));
        }

        public Polygon3D Transform(Matrix44 mat)
        {
            Polygon3D ret = new Polygon3D();
            for (int i = 0; i < NVertex(); i++)
            {
                ret.AddVertex(GetVertex(i).MultMat(mat));
            }

            return ret;
        }

        public double[] XArray()
        {
            double[] ret = new double[NVertex()];

            for (int i = 0; i < NVertex(); i++)
            {
                ret[i] = GetVertex(i).x;
            }
            return ret;
        }

        public double[] YArray()
        {
            double[] ret = new double[NVertex()];

            for (int i = 0; i < NVertex(); i++)
            {
                ret[i] = GetVertex(i).y;
            }
            return ret;
        }

        public double[] ZArray()
        {
            double[] ret = new double[NVertex()];

            for (int i = 0; i < NVertex(); i++)
            {
                ret[i] = GetVertex(i).z;
            }
            return ret;
        }

        public double XMax()
        {
            double xmax = 0.0D;
            int n = NVertex();

            if (n > 0)
            {
                xmax = GetVertex(0).x;
                for (int i = 1; i < n; i++)
                {
                    double x = GetVertex(i).x;
                    if (x <= xmax)
                        continue;
                    xmax = x;
                }
            }
            return xmax;
        }

        public double XMin()
        {
            double xmin = 0.0D;
            int n = NVertex();

            if (n > 0)
            {
                xmin = GetVertex(0).x;
                for (int i = 1; i < n; i++)
                {
                    double x = GetVertex(i).x;
                    if (x >= xmin)
                        continue;
                    xmin = x;
                }
            }
            return xmin;
        }

        public double YMax()
        {
            double ymax = 0.0D;
            int n = NVertex();

            if (n > 0)
            {
                ymax = GetVertex(0).y;
                for (int i = 1; i < n; i++)
                {
                    double y = GetVertex(i).y;
                    if (y <= ymax)
                        continue;
                    ymax = y;
                }
            }
            return ymax;
        }

        public double YMin()
        {
            double ymin = 0.0D;
            int n = NVertex();

            if (n > 0)
            {
                ymin = GetVertex(0).y;
                for (int i = 1; i < n; i++)
                {
                    double y = GetVertex(i).y;
                    if (y >= ymin)
                        continue;
                    ymin = y;
                }
            }
            return ymin;
        }

        public double ZMax()
        {
            double zmax = 0.0D;
            int n = NVertex();

            if (n > 0)
            {
                zmax = GetVertex(0).z;
                for (int i = 1; i < n; i++)
                {
                    double z = GetVertex(i).z;
                    if (z <= zmax)
                        continue;
                    zmax = z;
                }
            }
            return zmax;
        }

        public double ZMin()
        {
            double zmin = 0.0D;
            int n = NVertex();

            if (n > 0)
            {
                zmin = GetVertex(0).z;
                for (int i = 1; i < n; i++)
                {
                    double z = GetVertex(i).z;
                    if (z >= zmin)
                        continue;
                    zmin = z;
                }
            }
            return zmin;
        }

        public void Reverse()
        {
            Polygon3D temp = new Polygon3D(this);

            int n = n_vertex;
            for (int i = 0; i < n; i++)
                SetVertex(i, new Vector3D(temp.GetVertex(n - i - 1)));
        }

        public BoundingBox BoundingBox()
        {
            BoundingBox ret = new BoundingBox();

            int n = n_vertex;
            if (n >= 3)
            {
                for (int i = 0; i < n; i++)
                {
                    ret.Fusion(GetVertex(i));
                }
            }
            return ret;
        }
    }
}
