﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Sprint
    {
        [Display(Name = "ID Sprint")]    //Thuộc tính Display để đặt lại tên cho cột
        [Required(ErrorMessage = "{0} must not be empty")]    //Kiểm tra rỗng
        public int id_sprint { get; set; }

        [Display(Name = "Sprint Name")]    //Thuộc tính Display để đặt lại tên cho cột
        [Required(ErrorMessage = "{0} must not be empty")]    //Kiểm tra rỗng
        public string name_sprint { get; set; }

        [Display(Name = "Phase")]    //Thuộc tính Display để đặt lại tên cho cột
        [Required(ErrorMessage = "{0} must not be empty")]    //Kiểm tra rỗng
        public string id_phase { get; set; }

        [Display(Name = "Plan Start Date")]    //Thuộc tính Display để đặt lại tên cho cột
        [Required(ErrorMessage = "{0} must not be empty")]    //Kiểm tra rỗng
        public System.DateTime plan_start_date { get; set; }

        [Display(Name = "Plan End Date")]    //Thuộc tính Display để đặt lại tên cho cột
        [Required(ErrorMessage = "{0} must not be empty")]    //Kiểm tra rỗng
        public System.DateTime plan_end_date { get; set; }

        [Display(Name = "Estimate Time")]    //Thuộc tính Display để đặt lại tên cho cột
        [Required(ErrorMessage = "{0} must not be empty")]    //Kiểm tra rỗng
        public int estimate_time { get; set; }

        public System.DateTime real_start_date { get; set; }
        public System.DateTime real_end_date { get; set; }

        [Display(Name = "Reporter")]    //Thuộc tính Display để đặt lại tên cho cột
        [Required(ErrorMessage = "{0} must not be empty")]    //Kiểm tra rỗng
        public int reporter { get; set; }

        [Display(Name = "Description")]    //Thuộc tính Display để đặt lại tên cho cột
        [Required(ErrorMessage = "{0} must not be empty")]    //Kiểm tra rỗng
        public string description { get; set; }

        [Display(Name = "Type of Sprint")]    //Thuộc tính Display để đặt lại tên cho cột
        [Required(ErrorMessage = "{0} must not be empty")]    //Kiểm tra rỗng
        public int type { get; set; }
        public string link { get; set; }

        [Display(Name = "Status")]    //Thuộc tính Display để đặt lại tên cho cột
        [Required(ErrorMessage = "{0} must not be empty")]    //Kiểm tra rỗng
        public int status { get; set; }
    }
}
