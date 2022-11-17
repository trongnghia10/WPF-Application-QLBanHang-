using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QLSanPham.Models;
namespace QLSanPham
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        QLBanHangContext db = new QLBanHangContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThi();
        }

        private void HienThi()
        {
            
            var query = from lsp in db.LoaiSanPhams
                        select lsp;
            // Hiển thị dữ liệu
            dataGrid.ItemsSource = query.ToList();
        }

        private void btnthem_Click(object sender, RoutedEventArgs e)
        {
            LoaiSanPham lspmoi = new LoaiSanPham();
            lspmoi.MaLoai = txtmaloai.Text;
            lspmoi.TenLoai = txttenloai.Text;
            if (!db.LoaiSanPhams.Contains(lspmoi))
            {
                db.LoaiSanPhams.Add(lspmoi);
                db.SaveChanges();
                HienThi();
            }
            else
            {
                MessageBox.Show("Đã có sản phẩm này!","Thêm dữ liệu",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            var lspSua = (from lsp in db.LoaiSanPhams
                          where lsp.MaLoai == txtmaloai.Text
                          select lsp).SingleOrDefault();
            if (lspSua != null)
            {
                lspSua.TenLoai = txttenloai.Text;
                db.SaveChanges();
                HienThi();
            }
            else
            {
                MessageBox.Show("Không có sản phẩm này!", "Sửa dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {
            var lspxoa = (from lsp in db.LoaiSanPhams
                          where lsp.MaLoai == txtmaloai.Text
                          select lsp).SingleOrDefault();
            if (lspxoa != null)
            {
                db.LoaiSanPhams.Remove(lspxoa);
                db.SaveChanges();
                HienThi();
            }
            else
            {
                MessageBox.Show("Không có sản phẩm này!", "Xoá dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnthoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
