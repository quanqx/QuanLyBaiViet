using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogManagement.Models
{
    public class User
    {
        //internal không cho kế thừa chỉ dành riêng cho lớp
        internal sealed class UserMetadata
        {

            public int ID { get; set; }
            //[Display(Name = "Tên người dùng:")]
            public string UserName { get; set; }
            //[Display(Name = "Email:")]
            public string Email { get; set; }
            //[Display(Name = "Thay đổi hình ảnh:")]
            public string Image { get; set; }
        }
    }
}