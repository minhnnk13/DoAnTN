using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace computer_store_API.Api
{

    public class DbConnector
    {
        #region Declare
        string _connectionString = @"Data Source=DESKTOP-PKUIBUI;Initial Catalog=ComputerStore;Integrated Security=True";
        SqlConnection _dbConnection;
        #endregion

        #region Constructor
        public DbConnector()
        {
            _dbConnection = new SqlConnection(_connectionString);
        }
        #endregion

        /// <summary>
        /// Lấy thông tin tất cả bản ghi trong bảng
        /// </summary>
        /// <typeparam name="HaUIEntity"></typeparam>
        /// <returns></returns>
        #region Method
        public IEnumerable<HaUIEntity> Get<HaUIEntity>()
        {
            string tableName = typeof(HaUIEntity).Name;
            var entities = _dbConnection.Query<HaUIEntity>($"Proc_Get{tableName}s", commandType: CommandType.StoredProcedure);
            return entities;
        }

        

        /// <summary>
        /// Lấy bản ghi nổi bật
        /// </summary>
        /// <typeparam name="HaUIEntity"></typeparam>
        /// <returns></returns>
        public IEnumerable<HaUIEntity> GetHighlight<HaUIEntity>()
        {
            string tableName = typeof(HaUIEntity).Name;
            var entities = _dbConnection.Query<HaUIEntity>($"Proc_Get{tableName}sHighlight", commandType: CommandType.StoredProcedure);
            return entities;
        }
        /// <summary>
        /// Lấy tất cả bản ghi theo danh mục sản phẩm
        /// </summary>
        /// <typeparam name="HaUIEntity"></typeparam>
        /// <param name="ProductCategoryId"></param>
        /// <returns></returns>
        public IEnumerable<HaUIEntity> GetProductsByCategory<HaUIEntity>(int productCategoryId)
        {
            string tableName = typeof(HaUIEntity).Name;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add(("@id"), productCategoryId);
            var entities = _dbConnection.Query<HaUIEntity>($"Proc_Get{tableName}sBycategoryId", commandType: CommandType.StoredProcedure, param: dynamicParameters);
            return entities;
        }

        /// <summary>
        /// Lấy thông tin bản ghi theo Id
        /// </summary>
        /// <typeparam name="HaUIEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public object Get<HaUIEntity>(int id)
        {
            string _tableName = typeof(HaUIEntity).Name;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add(("@id"), id);
            var entities = _dbConnection.Query<HaUIEntity>($"Proc_Get{_tableName}ById", commandType: CommandType.StoredProcedure, param: dynamicParameters);
            var result = entities.FirstOrDefault<HaUIEntity>();
            return result;
        }

        private int GetBiggestId<HaUIEntity>()
        {
            string _tableName = typeof(HaUIEntity).Name;
            SqlCommand cmd = new SqlCommand($"Proc_Get{_tableName}BiggestId", _dbConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            _dbConnection.Open();
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            _dbConnection.Close();
            return id;
        }

        public object Post<HaUIEntity>(HaUIEntity entity)
        {
            // Khởi tạo HaUIEntity
            dynamic result = new object();
            
            
            DynamicParameters dynamicParameters = new DynamicParameters();
            string _tableName = typeof(HaUIEntity).Name;
            var fieldId = _tableName + "Id";
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                if(propertyName == fieldId)
                {
                    propertyValue = null;
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var recordAffect = _dbConnection.Execute($"Proc_Create{_tableName}", commandType: CommandType.StoredProcedure, param: dynamicParameters);

            if (recordAffect == 1)
            {
           
                result = entity;
                switch (_tableName)
                {
                    case "Product": result.ProductId = GetBiggestId<HaUIEntity>(); break;
                    case "Param": result.ParamId = GetBiggestId<HaUIEntity>(); break;
                    case "Account": result.AccountId = GetBiggestId<HaUIEntity>(); break;
                    case "News": result.NewsId = GetBiggestId<HaUIEntity>(); break;
                    case "Banner": result.BannerId = GetBiggestId<HaUIEntity>(); break;
                    case "Order": result.OrderId = GetBiggestId<HaUIEntity>(); break;

                };
                return result;
            }
            else
            {
                return result;
            }
        }

        public int Put<HaUIEntity>(HaUIEntity entity, int id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            string _tableName = typeof(HaUIEntity).Name;
            string fieldId = _tableName + "Id";
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                if (propertyName == fieldId)
                {
                    propertyValue = id;
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var recordAffect = _dbConnection.Execute($"Proc_Update{_tableName}", commandType: CommandType.StoredProcedure, param: dynamicParameters);
            return recordAffect;
        }

        public int Delete<HaUIEntity>(int id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            string _tableName = typeof(HaUIEntity).Name;
            string fieldId = _tableName + "Id";
            dynamicParameters.Add(fieldId, id) ;
            var recordAffect = _dbConnection.Execute($"Proc_Delete{_tableName}", commandType: CommandType.StoredProcedure, param: dynamicParameters);
            return recordAffect;
        }
        #endregion
    }
}
