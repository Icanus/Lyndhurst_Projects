using System.ComponentModel.DataAnnotations;
using System;

namespace Blazor_CRUD_test.Entities
{
    public class ProductItem
    {
        public int pibID { get; set; }
        public string JobNumber { get; set; }
        public string OrderNo { get; set; }
        public string Style { get; set; }
        public string Colour { get; set; }
        public string PPOQty { get; set; }
        public string OrderedUnits { get; set; }
        public string ItemSz { get; set; }
        public string ItemQty { get; set; }
        public string BarParentID { get; set; }
        public string BarChildID { get; set; }
        public string BarID { get; set; }
        public int? ProdCount { get; set; }
        public int? QcCount { get; set; }
        public int? PkgCount { get; set; }
        public int? DstrCount { get; set; }
        public int? ProdCountR { get; set; }
        public int? QcCountR { get; set; }
        public int? PkgCountR { get; set; }
        public int? DstrCountR { get; set; }
        public int? StatusID { get; set; }
    }
    public class ProductItemReview
    {
        public string BarID { get; set; }
        public int? StatusID { get; set; }
        public string StatusDesc { get; set; }
        public int? LocationID { get; set; }
        public string LocationDesc { get; set; }
        public string SectionDesc { get; set; }
        public string Factory { get; set; }
        public DateTime TransDt { get; set; }
        public string UserID { get; set; }
        public int? DeviceID { get; set; }
        public string DeviceDesc { get; set; }
        public string Comments { get; set; }
    }
    public class ProductItemLapsed
    {
        public int Nos { get; set; }
        public string BarID { get; set; }
        public int? LocationID { get; set; }
        public int? StatusID { get; set; }
        public DateTime TransDt { get; set; }
        public string LapsedDt { get; set; }      
        public string UserID { get; set; }
        public int? DeviceID { get; set; }
        public string Comments { get; set; }
    }
}