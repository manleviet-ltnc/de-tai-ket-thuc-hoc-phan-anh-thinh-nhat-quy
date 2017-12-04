using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCongViec.Model
{
    public class CongViec
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public DateTime BatDau { get; set; }
        public DateTime KetThuc { get; set; }
        public int TrangThai { get; set; }// 0: Chưa hoàn thành, 1: Đã hoàn thành
    }
}
