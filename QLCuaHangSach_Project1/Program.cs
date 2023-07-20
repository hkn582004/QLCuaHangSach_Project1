using QLCuaHangSach_Project1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangSach_Project1
{
    public class Screen
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Clear();
            Console.WriteLine("\t  ----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t  ----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t  ||                                                                                                      ||");
            Console.WriteLine("\t  ||                              Trường Đại học Sư phạm Kỹ thuật Hưng Yên                                ||");
            Console.WriteLine("\t  ||                                                                                                      ||");
            Console.WriteLine("\t  ||                                      Khoa Công nghệ thông tin                                        ||");
            Console.WriteLine("\t  ||                                      Ngành Kỹ thuật phần mềm                                         ||");
            Console.WriteLine("\t  ||                                                                                                      ||");
            Console.WriteLine("\t  ||                     *******   *******    **      **   ********   **      ********                    ||");
            Console.WriteLine("\t  ||                     *******   *******    **    **     ********   **      ********                    ||");
            Console.WriteLine("\t  ||                     **        **         **  **          **      **         **                       ||");
            Console.WriteLine("\t  ||                     **        *******    ***             **      **         **                       ||");
            Console.WriteLine("\t  ||                     **             **    **  **          **      **         **                       ||");
            Console.WriteLine("\t  ||                     *******   *******    **    **        **      *******    **                       ||");
            Console.WriteLine("\t  ||                     *******   *******    **      **      **      *******    **                       ||");
            Console.WriteLine("\t  ||                                                                                                      ||");
            Console.WriteLine("\t  ||         +----------------------------------------------------------------------------------+         ||");
            Console.WriteLine("\t  ||         |          Chào mừng đến với chương trình Quản lý Cửa hàng sách bằng C#            |         ||");
            Console.WriteLine("\t  ||         +----------------------------------------------------------------------------------+         ||");
            Console.WriteLine("\t  ||                                                                                                      ||");
            Console.WriteLine("\t  ||                                                                                                      ||");
            Console.WriteLine("\t  ||                                  Người thực hiện: Hoàng Kiều Ngân                                    ||");
            Console.WriteLine("\t  ||                                  Mã SV:  12522072                                                    ||");
            Console.WriteLine("\t  ||                                  Mã lớp: 125223                                                      ||");
            Console.WriteLine("\t  ||                                  Giảng viên hướng dẫn: Bùi Đức Thọ                                   ||");
            Console.WriteLine("\t  ||                                                                                                      ||");
            Console.WriteLine("\t  ----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t  __________________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t      Nhấn Enter để tiếp tục");
            Console.ReadKey();
            ChucNang.MainProgram();
            QLSach.MenuQLSach();
            QLNhanVien.MenuQLNhanVien();
        }
    }

    public class ChucNang
    {
        public static void MainProgram()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t ******************************************************");
            Console.WriteLine("\t\t\t\t *                                                    *");
            Console.WriteLine("\t\t\t\t *      +--------------------------------------+      *");
            Console.WriteLine("\t\t\t\t *      |          XIN MỜI LỰA CHỌN            |      *");
            Console.WriteLine("\t\t\t\t *      +--------------------------------------+      *");
            Console.WriteLine("\t\t\t\t *                                                    *");
            Console.WriteLine("\t\t\t\t *      +--------------------------------------+      *");
            Console.WriteLine("\t\t\t\t *      |          1. QUẢN LÝ SÁCH             |      *");
            Console.WriteLine("\t\t\t\t *      +--------------------------------------+      *");
            Console.WriteLine("\t\t\t\t *                                                    *");
            Console.WriteLine("\t\t\t\t *      +--------------------------------------+      *");
            Console.WriteLine("\t\t\t\t *      |         2. QUẢN LÝ NHÂN VIÊN         |      *");
            Console.WriteLine("\t\t\t\t *      +--------------------------------------+      *");
            Console.WriteLine("\t\t\t\t *                                                    *");
            Console.WriteLine("\t\t\t\t *      +--------------------------------------+      *");
            Console.WriteLine("\t\t\t\t *      |               3. THOÁT               |      *");
            Console.WriteLine("\t\t\t\t *      +--------------------------------------+      *");
            Console.WriteLine("\t\t\t\t *                                                    *");
            Console.WriteLine("\t\t\t\t ******************************************************");
            Console.WriteLine();
            Console.Write("\t\t\t\t               👉 Mời nhập lựa chọn: ");

            for (; ; )
            {

                var choose = Console.ReadLine();

                if (choose == "1")
                {

                    Console.Clear();
                    QLSach.MenuQLSach();
                    Console.ReadKey(true);
                }

                else if (choose == "2")
                {

                    Console.Clear();
                    QLNhanVien.MenuQLNhanVien();
                    Console.ReadKey(true);
                }

                else if (choose == "3")
                {
                    Environment.Exit(0);
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\t\t\t     Lựa chọn sai!!! Vui lòng nhập lại");
                    Console.Write("\t\t\t     Mời nhập lại lựa chọn: ");
                }
            }
        }
    }

    // Quản lý Sách
    public class QLSach
    {
        struct Sach
        {
            public string TenSach, Tacgia, NhaXB, ID;
            public int NamXB;
            public double Gia;
        }
        public static string idcanxoa;

        static Sach[] buk;
        static int n;

        // NHẬP SÁCH
        public static void NhapThemvaGhiFile()
        {
            StreamWriter sw = File.CreateText("D:/Sach.txt");

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine("\t\t\t   WELCOME TO FAHASA BOOKSTORE ");
            Console.WriteLine("\t\t\t      -----oooOOOooo-----");
            Console.WriteLine();
            Console.Write("Xin mời nhập số lượng sách: ");
            do
            {
                n = int.Parse(Console.ReadLine());
            } while (n < 0);
            buk = new Sach[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Sách thứ {0}", i + 1);
                Console.Write("Nhập ID sách: ");
                buk[i].ID = Console.ReadLine();
                while (true)
                //while (true) để bắt buộc phải nhập đúng
                {
                    if (buk[i].ID == "")
                    {
                        Console.WriteLine("Không được để trống. Vui lòng nhập lại");
                        buk[i].ID = Console.ReadLine();
                    }
                    else break;
                }

                Console.Write("Nhập tên sách: ");
                buk[i].TenSach = Console.ReadLine();
                while (true)
                {
                    if (buk[i].TenSach == "")
                    {
                        Console.WriteLine("Không được để trống. Vui lòng nhập lại");
                        buk[i].TenSach = Console.ReadLine();
                    }
                    else break;
                }


                Console.Write("Nhập tác giả sách: ");
                buk[i].Tacgia = Console.ReadLine();
                while (true)
                {
                    if (buk[i].Tacgia == "")
                    {
                        Console.WriteLine("Không được để trống. Vui lòng nhập lại");
                        buk[i].Tacgia = Console.ReadLine();
                    }
                    else break;
                }

                Console.Write("Nhập nhà xuất bản sách: ");
                buk[i].NhaXB = Console.ReadLine();
                while (true)
                {
                    if (buk[i].NhaXB == "")
                    {
                        Console.WriteLine("Không được để trống. Vui lòng nhập lại");
                        buk[i].NhaXB = Console.ReadLine();
                    }
                    else break;
                }

                Console.Write("Nhập năm xuất bản sách: ");
                buk[i].NamXB = int.Parse(Console.ReadLine());
                while (true)
                {
                    if (buk[i].NamXB < 0)
                    {
                        Console.WriteLine("Năm xuất bản phải > 0. Vui lòng nhập lại");
                        buk[i].NamXB = int.Parse(Console.ReadLine());
                    }
                    else break;
                }

                Console.Write("Nhập giá sách (nghìn đồng): ");
                buk[i].Gia = double.Parse(Console.ReadLine());
                while (true)
                {
                    if (buk[i].Gia < 0)
                    {
                        Console.WriteLine("Giá sách phải > 0. Vui lòng nhập lại");
                        buk[i].Gia = double.Parse(Console.ReadLine());
                    }
                    else break;
                }
                sw.WriteLine("{0}@{1}@{2}@{3}@{4}@{5}", buk[i].ID, buk[i].TenSach, buk[i].Tacgia, buk[i].NhaXB, buk[i].NamXB, buk[i].Gia);
            }
            sw.Close();
        }

        //ĐỌC VÀ HIỂN THỊ

        public static string filename = "D:/Sach.txt";
        public static void DocFilevaHienthi()
        {
            //Mở file Sach ở chế độ đọc
            FileStream fs = new FileStream(@"D:/Sach.txt", FileMode.Open, FileAccess.Read);
            //Đọc dữ liệu văn bản StreamReader
            StreamReader rd = new StreamReader(fs);
            //Đọc tưng dòng của văn bản
            string line;
            //Lặp đến khi hết tệp( kq đọc được là null)
            while ((line = rd.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            rd.Close();
        }

        // TÌM SÁCH
        public static void TimSach()
        {
            Sach[] buk = new Sach[1];
            int index = 0;
            //Đọc dữ liệu trong tệp rồi gán vào struct,hiển thị theo bảng

            string tenfile = @"D:/Sach.txt";
            using (StreamReader sr = new(tenfile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Array.Resize(ref buk, index + 1);
                    //array.resize để thay đổi kích thước mảng
                    //ref để lấy lại giá trị buk
                    string[] values = line.Split('@');
                    Sach s = new Sach()
                    {
                        ID = values[0],
                        TenSach = values[1],
                        Tacgia = values[2],
                        NhaXB = values[3],
                        NamXB = int.Parse(values[4]),
                        Gia = double.Parse(values[5]),
                    };
                    buk[index] = s;
                    index++;
                }
            }

            Console.WriteLine("\t\t\t   -----------------------------------------");
            Console.WriteLine("\t\t\t   ||            PLEASE CHOOSE            ||");
            Console.WriteLine("\t\t\t   -----------------------------------------");
            Console.WriteLine("\t\t\t        o                             o    ");
            Console.WriteLine("\t\t\t        O                             O    ");
            Console.WriteLine("\t\t\t        o                             o    ");
            Console.WriteLine("\t\t\t   -----------------------------------------");
            Console.WriteLine("\t\t\t   ||          1.Tìm kiếm ID sách         ||");
            Console.WriteLine("\t\t\t   -----------------------------------------");
            Console.WriteLine("\t\t\t   ||       2.Tìm kiếm theo tên sách      ||");
            Console.WriteLine("\t\t\t   -----------------------------------------");
            int choose;
            string ten, id;

            do
            {
                Console.WriteLine();
                Console.Write("\t\t\t       Hãy nhập lựa chọn của bạn:  ");
                choose = int.Parse(Console.ReadLine());
            } while (choose < 1 || choose > 2);
            switch (choose)
            {
                case 1:
                    Console.WriteLine();
                    Console.Write("\t\t\t   Hãy nhập ID sách bạn muốn tìm kiếm: ");
                    id = Console.ReadLine();
                    for (int i = 0; i < buk.Length; i++)
                    {
                        if (buk[i].ID == id)
                        {
                            Console.WriteLine("{0}\t\t|{1}\t\t|{2}\t\t|{3}\t\t|{4}\t\t|{5}", buk[i].ID, buk[i].TenSach, buk[i].Tacgia, buk[i].NhaXB, buk[i].NamXB, buk[i].Gia);
                        }
                        //else { Console.WriteLine("ID bạn nhập không tồn tại "); }
                    }
                    break;
                case 2:
                    Console.WriteLine();
                    Console.Write("\t\t\t   Hãy nhập tên sách bạn muốn tìm kiếm: ");
                    ten = Console.ReadLine();
                    while (true)
                    {
                        if (ten == "")
                        {
                            Console.WriteLine("Không được bỏ trống! Vui lòng nhập lại: ");
                            ten = Console.ReadLine();
                        }
                        else break;
                    }
                    for (int i = 0; i < buk.Length; i++)
                    {
                        if (buk[i].TenSach.IndexOf(ten) >= 0)
                        {
                            Console.WriteLine("{0}\t\t|{1}\t\t|{2}\t\t|{3}\t\t|{4}\t\t|{5}", i + 1, buk[i].ID, buk[i].TenSach, buk[i].Tacgia, buk[i].NhaXB, buk[i].NamXB, buk[i].Gia);
                        }
                        //else
                            //Console.WriteLine("Không tìm thấy!");
                    }
                    break;
            }
        }

        // SỬA SÁCH
        public static void SuaSach()
        {

            Console.Write("Nhập ID sách muốn sửa: ");
            var IDSach = Console.ReadLine()!;
            StreamWriter rd = new StreamWriter(@"D:/Sach.txt");           
            for (int i = 0; i < n; i++)
            {
                if (Equals(buk[i].ID, IDSach))
                //so sánh ID trong tệp với ID vừa nhập. Nếu khớp thì tiến hành sửa
                {

                    Console.Write("Nhập tên sách muốn sửa: ");
                    buk[i].TenSach = Console.ReadLine()!;

                    Console.Write("Nhập tác giả muốn sửa: ");
                    buk[i].Tacgia = Console.ReadLine()!;

                    Console.Write("Nhập tên nhà sản xuất sách muốn sửa: ");
                    buk[i].NhaXB = Console.ReadLine()!;

                    Console.Write("Nhập năm xuất bản muốn sửa: ");
                    buk[i].NamXB = int.Parse(Console.ReadLine()!);

                    Console.Write("Nhập giá tiền muốn sửa: ");
                    buk[i].Gia = double.Parse(Console.ReadLine()!);
                }
                rd.WriteLine("{0}@{1}@{2}@{3}@{4}@{5}", buk[i].ID, buk[i].TenSach, buk[i].Tacgia, buk[i].NhaXB, buk[i].NamXB, buk[i].Gia);
            }
            rd.Close();
        }

        // XÓA SÁCH
        static void XoaSach(Sach[] buk, string idcanxoa)
        {
            Console.Write("Nhập ID sách cần xóa: ");
            idcanxoa = Console.ReadLine();
            StreamWriter sw = new StreamWriter(@"D:/Sach.txt");
            for (int i = 0; i < n; i++)
            {
                if (buk[i].ID == idcanxoa)
                {
                    continue;
                }
                sw.WriteLine("{0}@{1}@{2}@{3}@{4}@{5}", buk[i].ID, buk[i].TenSach, buk[i].Tacgia, buk[i].NhaXB, buk[i].NamXB, buk[i].Gia);
            }
            sw.Close();  
        }

        public static void ThongKe()
        {
            StreamReader rd = new StreamReader(@"D:/Sach.txt");
            int tk = 0;
            string line;
            while ((line = rd.ReadLine()) != null)
            {
                Array.Resize(ref buk, tk + 1);
                //array.resize để thay đổi kích thước mảng
                string[] values = line.Split('@');
                Sach s = new Sach()
                {
                    ID = values[0],
                    TenSach = values[1],
                    Tacgia = values[2],
                    NhaXB = values[3],
                    NamXB = int.Parse(values[4]),
                    Gia = double.Parse(values[5]),
                };
                buk[tk] = s;
                tk++;
            };
            rd.Close();
            for (int i = 0; i < tk; i++)
            {
            
                if (buk[i].Gia > 200000)
                {
                    Console.WriteLine("\t\t\t\t\t   ------------------------");
                    Console.WriteLine("\t\t\t\t\t   |     Sách giá đắt     |");
                    Console.WriteLine("\t\t\t\t\t   ------------------------");
                    Console.WriteLine();
                    Console.WriteLine("{0}\t\t|{1}\t\t|{2}\t\t|{3}\t\t|{4}\t\t|{5}", buk[i].ID, buk[i].TenSach, buk[i].Tacgia, buk[i].NhaXB, buk[i].NamXB, buk[i].Gia);
                }
                else if (buk[i].Gia <= 200000 && buk[i].Gia > 100000)
                {
                    Console.WriteLine("\t\t\t\t\t   ------------------------------");
                    Console.WriteLine("\t\t\t\t\t   |     Sách giá trung bình    |");
                    Console.WriteLine("\t\t\t\t\t   ------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("{0}\t\t|{1}\t\t|{2}\t\t|{3}\t\t|{4}\t\t|{5}", buk[i].ID, buk[i].TenSach, buk[i].Tacgia, buk[i].NhaXB, buk[i].NamXB, buk[i].Gia);
                }
                else if (buk[i].Gia <= 100000 && buk[i].Gia > 30000)
                {
                    Console.WriteLine("\t\t\t\t\t   ------------------------");
                    Console.WriteLine("\t\t\t\t\t   |      Sách giá rẻ     |");
                    Console.WriteLine("\t\t\t\t\t   ------------------------");
                    Console.WriteLine();
                    Console.WriteLine("{0}\t\t|{1}\t\t|{2}\t\t|{3}\t\t|{4}\t\t|{5}", buk[i].ID, buk[i].TenSach, buk[i].Tacgia, buk[i].NhaXB, buk[i].NamXB, buk[i].Gia);
                }
            }
            Console.ReadLine();
        }

        //ĐẾM TỪ
        public static void DemTu()
        {
            StreamReader file = File.OpenText(@"D:/Sach.txt");
            string line;
            int amountOfWords = 0;
            do
            {
                line = file.ReadLine();
                if (line != null)
                {
                    string[] words = line.Split('@');
                    amountOfWords += words.Length;
                }
            }
            while (line != null);
            file.Close();
            Console.WriteLine("\t\t\t   Tổng số từ có trong File Sách là: " + amountOfWords);
            Console.ReadKey();
        }

        // HÓA ĐƠN
        public static void HoaDon()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t *****************************************************************************");
            Console.WriteLine("\t\t\t *                          CỬA HÀNG SÁCH FAHASA                             *");
            Console.WriteLine("\t\t\t *        Địa chỉ: KĐT Lạc Hồng Phúc - Phố Nối - Mỹ Hào - Hưng Yên           *");
            Console.WriteLine("\t\t\t *                            SĐT: 0287 159 447                              *");
            Console.WriteLine("\t\t\t *                             ---oooOOOooo---                               *");
            Console.WriteLine("\t\t\t *                                                                           *");
            Console.WriteLine("\t\t\t *                           HÓA ĐƠN THANH TOÁN                              *");
            Console.WriteLine("\t\t\t *                                                                           *");
            Console.WriteLine("\t\t\t *     Mã khách hàng:                                                        *");
            Console.WriteLine("\t\t\t *     Mã nhân viên thu ngân:                                                *");
            Console.WriteLine("\t\t\t *     Số hóa đơn:                                                           *");
            Console.WriteLine("\t\t\t *     Ngày xuất hóa đơn:                                                    *");
            Console.WriteLine("\t\t\t *                                                                           *");
            Console.WriteLine("\t\t\t *     -----------------------------------------------------------------     *");
            Console.WriteLine("\t\t\t *     |        Sản phẩm       |  Số lượng  |   Giá   |   Thành tiền   |     *");
            Console.WriteLine("\t\t\t *     -----------------------------------------------------------------     *");
            Console.WriteLine("\t\t\t *     |                       |            |         |                |     *");
            Console.WriteLine("\t\t\t *     -----------------------------------------------------------------     *");
            Console.WriteLine("\t\t\t *     |                       |            |         |                |     *");
            Console.WriteLine("\t\t\t *     -----------------------------------------------------------------     *");
            Console.WriteLine("\t\t\t *     |                       |            |         |                |     *");
            Console.WriteLine("\t\t\t *     -----------------------------------------------------------------     *");
            Console.WriteLine("\t\t\t *     |                       |            |         |                |     *");
            Console.WriteLine("\t\t\t *     -----------------------------------------------------------------     *");
            Console.WriteLine("\t\t\t *     |                       |            |         |                |     *");
            Console.WriteLine("\t\t\t *     -----------------------------------------------------------------     *");
            Console.WriteLine("\t\t\t *                                             TỔNG:                         *");
            Console.WriteLine("\t\t\t *                                                                           *");
            Console.WriteLine("\t\t\t *   --------------------------------------------------                      *");
            Console.WriteLine("\t\t\t *   Để biết thêm hông tin về sản phẩm,                                      *");
            Console.WriteLine("\t\t\t *   vui lòng truy cập website: https://www.fahasa.com                       *");
            Console.WriteLine("\t\t\t *                                                                           *");
            Console.WriteLine("\t\t\t *                         XIN CẢM ƠN QUÝ KHÁCH                              *");
            Console.WriteLine("\t\t\t *   CHÚC QUÝ KHÁCH CÓ NHỮNG GIÂY PHÚT MUA SẮM VUI VẺ TẠI FAHASA BOOKSTORE   *");
            Console.WriteLine("\t\t\t *                                                                           *");
            Console.WriteLine("\t\t\t *****************************************************************************");

        }

        //MENU SÁCH
        public static void MenuQLSach()
        {

            Console.Clear();
            Console.WriteLine("\t\t\t                       XIN MỜI LỰA CHỌN                          ");
            Console.WriteLine();
            Console.WriteLine("\t\t\t                +---------------------------------------+       ");
            Console.WriteLine("\t\t\t                +           1. Nhập thêm sách           +       ");
            Console.WriteLine("\t\t\t                +---------------------------------------+       ");
            Console.WriteLine("\t\t\t       +---------------------------------------+                 ");
            Console.WriteLine("\t\t\t       +       2. Đọc và hiển thị sách         +                 ");
            Console.WriteLine("\t\t\t       +---------------------------------------+                 ");
            Console.WriteLine("\t\t\t                +---------------------------------------+       ");
            Console.WriteLine("\t\t\t                +          3. Tìm kiếm sách             +       ");
            Console.WriteLine("\t\t\t                +---------------------------------------+       ");
            Console.WriteLine("\t\t\t       +---------------------------------------+                 ");
            Console.WriteLine("\t\t\t       +             4. Sửa sách               +                 ");
            Console.WriteLine("\t\t\t       +---------------------------------------+                 ");
            Console.WriteLine("\t\t\t                +---------------------------------------+       ");
            Console.WriteLine("\t\t\t                +            5. Xóa sách                +       ");
            Console.WriteLine("\t\t\t                +---------------------------------------+       ");
            Console.WriteLine("\t\t\t       +---------------------------------------+                 ");
            Console.WriteLine("\t\t\t       +           6. Thống kê sách            +                 ");
            Console.WriteLine("\t\t\t       +---------------------------------------+                 ");
            Console.WriteLine("\t\t\t                +---------------------------------------+       ");
            Console.WriteLine("\t\t\t                +          7. Đếm từ trong File         +       ");
            Console.WriteLine("\t\t\t                +---------------------------------------+       ");
            Console.WriteLine("\t\t\t       +---------------------------------------+                 ");
            Console.WriteLine("\t\t\t       +            8. Hóa đơn                 +                 ");
            Console.WriteLine("\t\t\t       +---------------------------------------+                 ");
            Console.WriteLine("\t\t\t                +---------------------------------------+       ");
            Console.WriteLine("\t\t\t                +          9. Thoát chương trình        +       ");
            Console.WriteLine("\t\t\t                +---------------------------------------+       ");
            Console.WriteLine();
            Console.Write("\t\t\t                     Mời nhập lựa chọn: ");

            for (; ; )
            {

                var choose = Console.ReadLine();

                if (choose == "1")
                {
                    Console.Clear();
                    NhapThemvaGhiFile();
                    //GhiFile(buk);
                    Console.ReadKey(true);
                    MenuQLSach();
                }

                if (choose == "2")
                {
                    Console.Clear();
                    DocFilevaHienthi();
                    Console.ReadKey(true);
                    MenuQLSach();
                }

                if (choose == "3")
                {
                    Console.Clear();
                    TimSach();
                    Console.ReadKey(true);
                    MenuQLSach();
                }

                if (choose == "4")
                {
                    Console.Clear();
                    SuaSach();
                    Console.ReadKey(true);
                    MenuQLSach();

                }

                if (choose == "5")
                {
                    Console.Clear();
                    XoaSach(buk, idcanxoa);
                    Console.ReadKey(true);
                    MenuQLSach();

                }

                if (choose == "6")
                {
                    Console.Clear();
                    ThongKe();
                    Console.ReadKey(true);
                    MenuQLSach();

                }

                if (choose == "7")
                {
                    Console.Clear();
                    DemTu();
                    Console.ReadKey(true);
                    MenuQLSach();

                }

                if (choose == "8")
                {
                    Console.Clear();
                    HoaDon();
                    Console.ReadKey(true);
                    MenuQLSach();
                }

                if (choose == "9")
                {
                    Console.Clear();
                    Console.ReadKey(true);
                    ChucNang.MainProgram();
                }
            }
        }
    }


    // Quản lý nhân viên  
    public class QLNhanVien
    {
        struct NhanVien
        {
            public string MaNV, TenNV, SĐT;
            public int  Ngaylam;
            public double Luong;
        }
        public static string mamuonxoa;

        static NhanVien[] nv = new NhanVien[n];
        static int n;

        // NHẬP NV
        public static void NhapThemvaGhiFile()
        {
            StreamWriter file = File.AppendText(@"D:/NhanVien.txt");

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine("\t\t\t   WELCOME TO FAHASA BOOKSTORE ");
            Console.WriteLine("\t\t\t      -----oooOOOooo-----");
            Console.WriteLine();
            Console.Write("Số nhân viên cần nhập: ");
            do
            {
                n = int.Parse(Console.ReadLine());
            } while (n < 0);
            nv = new NhanVien[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhân viên thứ {0}", i + 1);
                Console.Write("Nhập mã nhân viên: ");
                nv[i].MaNV = Console.ReadLine();
                while (true)
                {
                    if (nv[i].MaNV == "")
                    {
                        Console.WriteLine("Không được để trống. Vui lòng nhập lại");
                        nv[i].MaNV = Console.ReadLine();
                    }
                    else break;
                }

                Console.Write("Nhập tên nhân viên: ");
                nv[i].TenNV = Console.ReadLine();
                while (true)
                {
                    if (nv[i].TenNV == "")
                    {
                        Console.WriteLine("Không được để trống. Vui lòng nhập lại");
                        nv[i].TenNV = Console.ReadLine();
                    }
                    else break;
                }

                Console.Write("Nhập số điện thoại nhân viên: ");
                nv[i].SĐT = Console.ReadLine();
                while (true)
                {
                    if (nv[i].SĐT == "")
                    {
                        Console.WriteLine("Không được để trống. Vui lòng nhập lại");
                        nv[i].SĐT = Console.ReadLine();
                    }
                    else break;
                }

                Console.Write("Nhập số ngày làm của nhân viên ( /tháng): ");
                nv[i].Ngaylam = int.Parse(Console.ReadLine());
                while (true)
                {
                    if (nv[i].Ngaylam < 0 && nv[i].Ngaylam > 31)
                    {
                        Console.WriteLine("Số ngày làm phải > 0 và < 31 .Vui lòng nhập lại");
                        nv[i].Ngaylam = int.Parse(Console.ReadLine());
                    }
                    else break;
                }

                Console.Write("Nhập lương (triệu đồng): ");
                nv[i].Luong = double.Parse(Console.ReadLine());
                double Luong = 200 * nv[i].Ngaylam;
                while (true)
                {
                    if (nv[i].Luong < 0)
                    {
                        Console.WriteLine("Lương phải > 0. Vui lòng nhập lại");
                        nv[i].Luong = double.Parse(Console.ReadLine());
                    }
                    else break;
                }
                file.WriteLine("{0}@{1}@{2}@{3}@{4}", nv[i].MaNV, nv[i].TenNV, nv[i].SĐT, nv[i].Ngaylam, nv[i].Luong);
            }
            file.Close();

        }

        public static string filename = "D:/NhanVien.txt";

        // ĐỌC VÀ HIỂN THỊ NV
        public static void DocFilevaHienthi()
        {
            FileStream fs = new FileStream(@"D:/NhanVien.txt", FileMode.Open, FileAccess.Read);
            StreamReader rd = new StreamReader(fs);
            string line;
            while ((line = rd.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            rd.Close();
        }

        // TÌM NV
        public static void TimNV()
        {
            NhanVien[] nv = new NhanVien[1];
            int index = 0;
            //Đọc dữ liệu trong tệp rồi gán vào struct,hiển thị theo bảng

            string tenfile = @"D:/NhanVien.txt";
            using (StreamReader sr = new(tenfile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Array.Resize(ref nv, index + 1);
                    //array.resize để thay đổi kích thước mảng
                    //ref để lấy lại giá trị nv
                    string[] values = line.Split('@');
                    NhanVien mem = new NhanVien()
                    {
                        MaNV = values[0],
                        TenNV = values[1],
                        SĐT = values[2],
                        Ngaylam = int.Parse(values[3]),
                        Luong = double.Parse(values[4]),
                    };
                    nv[index] = mem;
                    index++;
                }
            }

            Console.WriteLine("\t\t\t   -----------------------------------------------");
            Console.WriteLine("\t\t\t   ||                PLEASE CHOOSE              ||");
            Console.WriteLine("\t\t\t   -----------------------------------------------");
            Console.WriteLine("\t\t\t         o                                  o     ");
            Console.WriteLine("\t\t\t         O                                  O     ");
            Console.WriteLine("\t\t\t         o                                  o     ");
            Console.WriteLine("\t\t\t   ------------------------------------------------");
            Console.WriteLine("\t\t\t   ||          1.Tìm kiếm mã nhân viên           ||");
            Console.WriteLine("\t\t\t   ------------------------------------------------");
            Console.WriteLine("\t\t\t   ||   2.Tìm kiếm gần đúng theo tên nhân viên   ||");
            Console.WriteLine("\t\t\t   ------------------------------------------------");
            int choose;
            string ten, ma;
            do
            {
                Console.WriteLine();
                Console.Write("\t\t\t      Hãy nhập lựa chọn của bạn: ");
                choose = int.Parse(Console.ReadLine());
            } while (choose < 1 || choose > 2);
            switch (choose)
            {
                case 1:
                    Console.WriteLine();
                    Console.Write("\t\t\t      Hãy nhập mã nhân viên bạn muốn tìm kiếm: ");
                    ma = Console.ReadLine();
                    for (int i = 0; i < nv.Length; i++)
                    {
                        if (nv[i].MaNV == ma)
                        {
                            Console.WriteLine("|{0}\t\t|{1}\t\t|{2}\t\t|{3}\t\t|{4}", nv[i].MaNV, nv[i].TenNV, nv[i].SĐT, nv[i].Ngaylam, nv[i].Luong);
                        }
                        //else { Console.WriteLine("Mã nhân viên nhập không tồn tại "); }
                    }
                    break;
                case 2:
                    Console.WriteLine();
                    Console.Write("\t\t\t      Hãy nhập tên nhân viên bạn muốn tìm kiếm: ");
                    ten = Console.ReadLine();
                    while (true)
                    {
                        if (ten == "")
                        {
                            Console.WriteLine("Không được bỏ trống! Vui lòng nhập lại: ");
                            ten = Console.ReadLine();
                        }
                        else break;
                    }
                    for (int i = 0; i < nv.Length; i++)
                    {
                        if (nv[i].TenNV.IndexOf(ten) >= 0)
                        {
                            Console.WriteLine("|{0}\t\t|{1}\t\t|{2}\t\t|{3}\t\t|{4}", i + 1, nv[i].MaNV, nv[i].TenNV, nv[i].SĐT, nv[i].Ngaylam, nv[i].Luong);
                        }
                        //else
                            //Console.WriteLine("Không tìm thấy!");
                    }
                    break;
            }
        }

        // SỬA NV
        public static void SuaNV()
        {
            Console.Write("Nhập mã nhân viên muốn sửa: ");
            var StaffCode = Console.ReadLine();
            StreamWriter rd = new StreamWriter(@"D:/NhanVien.txt");
            for (int i = 0; i < nv.Length; i++)
            {
                if (Equals(nv[i].MaNV, StaffCode))
                {

                    Console.Write("Nhập tên nhân viên muốn sửa: ");
                    nv[i].TenNV = Console.ReadLine()!;

                    Console.Write("Nhập số điện thoại muốn sửa: ");
                    nv[i].SĐT = Console.ReadLine()!;

                    Console.Write("Nhập số ngày làm muốn sửa: ");
                    nv[i].Ngaylam = int.Parse(Console.ReadLine()!);

                    Console.Write("Nhập lương muốn sửa: ");
                    nv[i].Luong = double.Parse(Console.ReadLine()!);
                }
                rd.WriteLine($"{nv[i].MaNV}@{nv[i].TenNV}@{nv[i].SĐT}@{nv[i].Ngaylam}@{nv[i].Luong}");
            }
            rd.Close();

        }

        // XÓA NV
        static void XoaNV(NhanVien[] nv, string mamuonxoa)
        {
            Console.Write("Nhập mã nhân viên muốn xóa: ");
            StreamWriter sw = new StreamWriter(@"D:/NhanVien.txt");
            for (int i = 0; i < n; i++)
            {
                if (nv[i].TenNV == mamuonxoa)
                {
                    continue;
                }
                sw.WriteLine("{0}@{1}@{2}@{3}@{4}", nv[i].MaNV, nv[i].TenNV, nv[i].SĐT, nv[i].Ngaylam, nv[i].Luong);
            }
            sw.Close();
        }

        //ĐẾM TỪ
        public static void DemTu()
        {
            StreamReader file = File.OpenText(@"D:/NhanVien.txt");
            string line;
            int amountOfWords = 0;
            do
            {
                line = file.ReadLine();
                if (line != null)
                {
                    string[] words = line.Split('@');
                    amountOfWords += words.Length;
                }
            }
            while (line != null);
            file.Close();
            Console.WriteLine("\t\t\t   Tổng số từ có trong File NhanVien là: " + amountOfWords);
            Console.ReadKey();
        }
    
        public static void MenuQLNhanVien()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t                    XIN MỜI LỰA CHỌN                     ");
            Console.WriteLine();
            Console.WriteLine("\t\t\t                 +---------------------------------------+       ");
            Console.WriteLine("\t\t\t                 +         1. Nhập thêm nhân viên        +       ");
            Console.WriteLine("\t\t\t                 +---------------------------------------+       ");
            Console.WriteLine("\t\t\t       +---------------------------------------+       ");
            Console.WriteLine("\t\t\t       +         2. Đọc File và hiển thị       +       ");
            Console.WriteLine("\t\t\t       +---------------------------------------+       ");
            Console.WriteLine("\t\t\t                 +---------------------------------------+       ");
            Console.WriteLine("\t\t\t                 +         3. Tìm kiếm nhân viên         +       ");
            Console.WriteLine("\t\t\t                 +---------------------------------------+       ");
            Console.WriteLine("\t\t\t       +---------------------------------------+       ");
            Console.WriteLine("\t\t\t       +           4. Sửa nhân viên            +       ");
            Console.WriteLine("\t\t\t       +---------------------------------------+       ");
            Console.WriteLine("\t\t\t                 +---------------------------------------+       ");
            Console.WriteLine("\t\t\t                 +          5. Xóa nhân viên             +       ");
            Console.WriteLine("\t\t\t                 +---------------------------------------+       ");
            Console.WriteLine("\t\t\t       +---------------------------------------+       ");
            Console.WriteLine("\t\t\t       +        6. Đếm số từ trong File        +       ");
            Console.WriteLine("\t\t\t       +---------------------------------------+       ");
            Console.WriteLine("\t\t\t                 +---------------------------------------+       ");
            Console.WriteLine("\t\t\t                 +       7. Thoát chương trình           +       ");
            Console.WriteLine("\t\t\t                 +---------------------------------------+       ");
            Console.WriteLine();
            Console.Write("\t\t\t                   Mời nhập lựa chọn:  ");

            for (; ; )
            {

                var choose = Console.ReadLine();

                if (choose == "1")
                {
                    Console.Clear();
                    NhapThemvaGhiFile();
                    Console.ReadKey(true);
                    MenuQLNhanVien();
                }

                if (choose == "2")
                {

                    Console.Clear();
                    DocFilevaHienthi();
                    Console.ReadKey(true);
                    MenuQLNhanVien();
                }

                if (choose == "3")
                {
                    Console.Clear();
                    TimNV();
                    Console.ReadKey(true);
                    MenuQLNhanVien();
                }

                if (choose == "4")
                {
                    Console.Clear();
                    SuaNV();
                    Console.ReadKey(true);
                    MenuQLNhanVien();
                }

                if (choose == "5")
                {

                    Console.Clear();
                    XoaNV(nv, mamuonxoa);
                    Console.ReadKey(true);
                    MenuQLNhanVien();
                }

                if (choose == "6")
                {
                    Console.Clear();
                    DemTu();
                    Console.ReadKey(true);
                    MenuQLNhanVien();
                }

                if (choose == "7")
                {
                    Console.Clear();
                    Console.ReadKey(true);
                    ChucNang.MainProgram();

                }
            }
        }
    }
}