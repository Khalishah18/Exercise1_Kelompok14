using System;
using System.Data;
using System.Data.SqlClient;

namespace Insert_and_Get_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("Koneksi Ke Database\n");
                    Console.WriteLine("Masukkan User ID :");
                    string user = Console.ReadLine();
                    Console.WriteLine("Masukkan Password :");
                    string pass = Console.ReadLine();
                    Console.WriteLine("Masukkan Database tujuan :");
                    string db = Console.ReadLine();
                    Console.Write("\nKetik K untuk Terhubung ke Database: ");
                    char chr = Convert.ToChar(Console.ReadLine());
                    switch (chr)
                    {
                        case 'K':
                            {
                                SqlConnection conn = null;
                                string strKoneksi = "Data source = LAPTOP-67G15PD7\\LISAA; " +
                                    "initial catalog = {0}; " +
                                    "User ID = {1}; password = {2}";
                                conn = new SqlConnection(string.Format(strKoneksi, db, user, pass));
                                conn.Open();
                                Console.Clear();
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("\nMenu");
                                        Console.WriteLine("1. Melihat Seluruh Data");
                                        Console.WriteLine("2. Tambah Data");
                                        Console.WriteLine("3. Keluar");
                                        Console.WriteLine("\nEnter your choice (1-3): ");
                                        char ch = Convert.ToChar(Console.ReadLine());
                                        switch (ch)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("DATA PEMBELI\n");
                                                    Console.WriteLine();
                                                    pr.baca(conn);
                                                    conn.Close();
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("INPUT DATA PEMBELI\n");
                                                    Console.WriteLine("Masukkan Id_Pembeli :");
                                                    string Id = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Nama :");
                                                    string Nma = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Alamat :");
                                                    string Almt = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Jenis Kelamin (L/P) :");
                                                    string jk = Console.ReadLine();
                                                    Console.WriteLine("Masukkan No Telepon :");
                                                    string notlpn = Console.ReadLine();
                                                    try
                                                    {
                                                        pr.insert(Id, Nma, Almt, jk, notlpn, conn);
                                                        conn.Close();
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                            "akses untuk menambah data");
                                                    }
                                                }
                                                break;
                                            case '3':
                                                conn.Close();
                                                return;
                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\nInvalid Option");
                                                }
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\nCheck for the value entered. ");
                                    }
                                }
                            }
                    }
                }
        }
        }
    }
    
}