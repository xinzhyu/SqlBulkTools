﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SqlBulkTools
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UpdateQueryObject<T>
    {
        private readonly T _singleEntity;
        private readonly BulkOperations _ext;
        private int _transactionCount;
        private string _databaseIdentifier;
        private List<string> _concatTrans;
        private List<SqlParameter> _sqlParams;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="singleEntity"></param>
        /// <param name="ext"></param>
        public UpdateQueryObject(T singleEntity, BulkOperations ext, int transactionCount, List<string> concatTrans, List<SqlParameter> sqlParams)
        {
            _ext = ext;
            _singleEntity = singleEntity;
            _transactionCount = transactionCount;
            _databaseIdentifier = Guid.NewGuid().ToString();
            _concatTrans = concatTrans;
            _sqlParams = sqlParams;
        }

        /// <summary>
        /// Set the name of table for operation to take place. Registering a table is Required.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public UpdateQueryTable<T> WithTable(string tableName)
        {
            return new UpdateQueryTable<T>(_singleEntity, tableName, _ext, _transactionCount, _databaseIdentifier, _concatTrans, _sqlParams);
        }
    }
}
