using Blazor_CRUD_test.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Blazor_CRUD_test.Contracts
{
    public interface IProductItemManager
    {
        Task<int> Create(ProductItem productItem);
        Task<int> Delete(int Id);
        Task<List<ProductItem>> Count(string search);
        //Task<int> Update(ProductItem productItem);
        Task<string> Insert(string search, int status, int location, string user, int device, string comments);
        Task<ProductItem> GetById(int Id);
        Task<List<ProductItem>> ListAll(int skip,int location, int device, string user, string search);
        Task<List<ProductItemReview>> ListAll(string search);
        Task<List<ProductItemLapsed>> ListAll(string barcode, string orderno);
    }
}
