

    using Jp.Maker1.Vsys3.Tools;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;

public class PlaneGeneral
{
    public String name;
    public String maker;
    public double length;
    public double width;
    public double height;
    public double x_offset;
    public double m;
    public double m0;
    public Vector3D cg;
    public double ixx_m0;
    public double iyy_m0;
    public double izz_m0;
    public double ixy_m0;
    public double iyz_m0;
    public double izx_m0;
    public Vector3D eyePoint;
    public Vector3D[] reference_point;
    public Matrix44 opm;
    public Matrix44 pom;

    public void Init()
    {
        Vector3D pe = new Vector3D(eyePoint).R2l();

        opm = new Matrix44();
        opm.SetTMat(-pe.x, -pe.y, -pe.z);

        pom = new Matrix44();
        pom.SetTMat(pe.x, pe.y, pe.z);
    }

    public void Print()
    {
        Console.Out.WriteLine("��s�@��: " + name);
        Console.Out.WriteLine("���[�J�[: " + maker);
        Console.Out.WriteLine("�S�� [m]: " + length);
        Console.Out.WriteLine("�S�� [m]: " + width);
        Console.Out.WriteLine("�S�� [m]: " + height);
        Console.Out.WriteLine("��[�����_�܂ł̒��� [m]: " + x_offset);
        Console.Out.WriteLine("���K�S���d�� [kg]: " + m);
        Console.Out.WriteLine("���d [kg]: " + m0);
        Console.Out.WriteLine("�d�S [m]: " + cg.ToStringPos());
        Console.Out.WriteLine("Ixx/m0 [m2]: " + ixx_m0);
        Console.Out.WriteLine("Iyy/m0 [m2]: " + iyy_m0);
        Console.Out.WriteLine("Izz/m0 [m2]: " + izz_m0);
        Console.Out.WriteLine("Ixy/m0 [m2]: " + ixy_m0);
        Console.Out.WriteLine("Iyz/m0 [m2]: " + iyz_m0);
        Console.Out.WriteLine("Izx/m0 [m2]: " + izx_m0);
        Console.Out.WriteLine("���_�ʒu [m]: " + eyePoint.ToStringPos());
        Console.Out.WriteLine("�ڐG����_:");
        for (int i = 0; i < reference_point.Length; i++)
        {
            reference_point[i].PrintPos();
            Console.Out.WriteLine("");
        }
        Console.Out.WriteLine("�@�̌n���p�C���b�g���_�n�ϊ��s��");
        opm.Print();
        Console.Out.WriteLine("�p�C���b�g���_�n���@�̌n�ϊ��s��");
        pom.Print();
    }
}