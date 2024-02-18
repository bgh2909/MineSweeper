using System;
using System.Collections.Generic;
using System.Text;

namespace mineText
{
    class Program
    {
        static void Main(string[] args)
        {
            //Khai báo khởi tạo ma trận 2 chiều với các phần tử là " . " và " * " 
            string[,] matran = 
            {
            {".", ".", ".", "."},
            {"*", ".", "*", "."},
            {".", "*", "*", "."},
            {".", ".", ".", "."}
            };

            //tạo biến gán chiều cao ma trận
            int matran_chieucao = matran.GetLength(0); 
            //tạo biến gán chiều rộng ma trận
            int matran_chieurong = matran.GetLength(1);

            //tạo ma trận mới giống ma trận ban đầu, các phần tử mặc định rỗng
            string[,] kiemtra_matran = new string[matran_chieucao, matran_chieurong]; // <= ma trận mới dùng để nhập các phần tử mới và in ra màn hình
            
            //dùng lệnh vòng lặp lồng nhau để kiểm tra các phần tử trong ma trận ban đầu
            for (int y = 0; y < matran_chieucao; y++)
            {
                for (int x = 0; x < matran.GetLength(0); x++)
                {
                    string ohientai = matran[y, x];
                    if (ohientai.Equals("*")) // <= nếu ô hiện tại có phần tử là " * " thì gán vào ma trận kiemtra_matran
                    {
                        kiemtra_matran[y, x] = "*"; // <= gán vào ma trận kiemtra_matran tại vị trí [y,x] 
                    }
                    else 
                    {
                        //tạo 1 ma trận 3x3 mới với các phần tử là tọa độ xung quanh ô hiện của ma trận ban đầu
                        int[,] matran_xungquanhohientai = 
                            {//ô hiện tại có tọa độ là [y,x]                                  |-1|x |+1|
                        {y - 1, x - 1}, {y - 1, x}, {y - 1, x + 1}, //3 ô nằm phía trên   |-1 |  |  |  |
                        {y, x - 1}, {y,x },{y, x + 1}, // ô bên trái và ô bên phải        |y  |  |O |  |
                        {y + 1, x - 1}, {y + 1, x}, {y + 1, x + 1}, //3 ô nằm phía dưới   |+1 |  |  |  |
                        };

                        int dembom = 0; //khai báo biến đếm bom

                        //kiểm tra các ô xung quanh có nằm trong ma trận ban đầu không
                        //dùng 2 vòng lặp lồng nhau để kiểm tra các phần tử bên trong ma trận matran_xungquanhohientai


                        // ????
                        /* for (int i = 0; i < matran_xungquanhohientai.GetLength(0); i++)
                        {
                            for (int j = 0; j < matran_xungquanhohientai.GetLength(1);j++)
                            {
                                int m = matran_xungquanhohientai[i,j];
                                bool onamngoaimatran = m < 0; 
                                if (onamngoaimatran)
                                {
                                    continue;
                                }
                                bool onamtrongmatran = matran[i, j].Equals("*");
                                if(onamtrongmatran)
                                {
                                    dembom++;
                                }
                            }
                        } */
                        // ????
                        
                        //bắt đầu đoạn copy
                         for (int i = 0; i < matran_xungquanhohientai.GetLength(0); i++)
                        {
                            int m = matran_xungquanhohientai[i, 1];
                            int n = matran_xungquanhohientai[i, 0];

                            bool onamngoaimatran = m < 0 
                                    || m == matran_chieurong
                                    || n < 0
                                    || n == matran_chieucao;
                            if (onamngoaimatran)
                            {
                                continue;
                            }

                            bool onamtrongmatran = matran[n, m].Equals("*");
                            
                           
                            if (onamtrongmatran) 
                            {
                                dembom++;
                            }
                        } 
                         // hết đoạn copy

                        kiemtra_matran[y, x] = dembom.ToString(); // <= gán giá trị của biến dembom vào ma trận kiemtra_matran tại tọa độ [y,x]
                    }
                }
            }


            //dùng 2 vòng lặp để nhập các phần tử mới vào ma trận kiemtra_matran
            for (int g = 0; g < matran_chieucao; g++)
            {
                for (int h = 0; h < matran_chieurong; h++)
                {
                    String ketqua_ohientai = kiemtra_matran[g, h];
                    Console.Write(ketqua_ohientai + "  ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
