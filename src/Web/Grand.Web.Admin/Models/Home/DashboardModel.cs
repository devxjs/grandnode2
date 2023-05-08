﻿using Grand.Infrastructure.Models;

namespace Grand.Web.Admin.Models.Home
{
    public class DashboardModel : BaseModel
    {
        public bool IsLoggedInAsVendor { get; set; }
        public bool HideReportGA { get; set; }

    }
    public class DashboardActivityModel : BaseModel
    {
        public int OrdersPending { get; set; }
        public int AbandonedCarts { get; set; }
        public int LowStockProducts { get; set; }
        public int TodayRegisteredCustomers { get; set; }
        public int MerchandiseReturns { get; set; }
    }
}