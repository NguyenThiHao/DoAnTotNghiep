using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class Chart
    {
        public DateTime date;
        public int create;
        public int inprogress;
        public int done;

    }
}


//trong biểu đồ có:
//cột y là ngày
//    cột x có 3 giá trị: create, inprogress và done
//    t lưu ra 1 bảng riêng đây
//    trong controller thì xử lý tính toán create, inprogess, done theo ngày rồi. k biêt đúng k nhưng cứ xem là đúng rồi đi
//        giờ biểu diễn mấy cái này trên biểu đồ nữa ok