using Blazor_CRUD_test.Contracts;
using Blazor_CRUD_test.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System;

namespace Blazor_CRUD_test.Concrete
{
    public class ProductItemManager : IProductItemManager
    {
        private readonly IDapperManager1 _dapperManager;

        public ProductItemManager(IDapperManager1 dapperManager)
        {
            this._dapperManager = dapperManager;
        }
              
        public Task<int> Create(ProductItem productItem)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Item", productItem.pibID, DbType.String);
            var productItemId = Task.FromResult(_dapperManager.Insert<int>("[dbo].[SP_Add_Article]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return productItemId;
        }
                
        public Task<ProductItem> GetById(int id)
        {
            var productItem = Task.FromResult(_dapperManager.Get<ProductItem>($"select * from [dbo].[tblBarcodeDetails] where ID = {id}", null,
                    commandType: CommandType.Text));
            return productItem;
        }
                
        public Task<int> Delete(int id)
        {
            var deleteProductItem = Task.FromResult(_dapperManager.Execute($"Delete from [dbo].[tblBarcodeDetails] where ID = {id}", null,
                    commandType: CommandType.Text));
            return deleteProductItem;
        }

        //public Task<int> Count(string search)
        public Task<List<ProductItem>> Count(string search)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("barcode", value: search, DbType.String);

            var countProductItems = Task.FromResult(_dapperManager.GetAll<ProductItem>("[dbo].[SP_GetItemCount]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return countProductItems;
        }
        public Task<List<ProductItem>> ListAll(int skip, int location, int device, string user, string search)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("barcode", value: search, DbType.String);
            dbPara.Add("userid", value: user, DbType.String);
            dbPara.Add("deviceid", value: device, DbType.Int32);
            dbPara.Add("locationid", value: location, DbType.Int32);

            var productItems = Task.FromResult(_dapperManager.GetAll<ProductItem>("[dbo].[SP_GetBarcodeDetails]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return productItems;
        }
        public Task<List<ProductItemReview>> ListAll(string search)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("barcode", value: search, DbType.String);

            var productItemsReview = Task.FromResult(_dapperManager.GetAll<ProductItemReview>("[dbo].[SP_GetBarcodeReviewDetails]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return productItemsReview;
        }
        public Task<List<ProductItemLapsed>> ListAll(string barcode, string orderno)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("barcode", value: barcode, DbType.String);
            dbPara.Add("orderno", value: orderno, DbType.String);

            var productItemsLapsed = Task.FromResult(_dapperManager.GetAll<ProductItemLapsed>("[dbo].[SP_GetItemLapsed]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return productItemsLapsed;
        }
        public Task<string> Insert(string search, int status, int location, string user, int device, string comments)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("barcode", value: search, DbType.String);
            dbPara.Add("statusID", value: status, DbType.Int32);
            dbPara.Add("transDatetime", value: DateTime.Now, DbType.DateTime);
            dbPara.Add("locationID", value: location, DbType.Int32);
            dbPara.Add("userID", value: user, DbType.String);
            dbPara.Add("deviceID", value: device, DbType.Int32);
            dbPara.Add("comments", value: comments, DbType.String);

            var updateProductItem = Task.FromResult(_dapperManager.Update<string>("[dbo].[SP_InsertBarcodeDetails]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return updateProductItem;
        }     
    }
}
