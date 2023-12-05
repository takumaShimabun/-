using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace インボイス番号検索ツール.Model.DB
{
    internal class SqlManager
    {
        public static DataTable SelectInvoiceRegisterNumber(
            string regNum = ""
            , string name = ""
            , string address = ""
            , int status = -1
            , int personality = -1
            , int domesticOrOverseas = -1
            )
        {
            DataTable dtReturn = null;
            string storedProcedureName = "SearchIRN";
            OdbcManager myOdbcManager = new();
            myOdbcManager.Connect();
            myOdbcManager.CreateOdbcCommand(storedProcedureName);
            myOdbcManager.SetCommandType(CommandType.StoredProcedure);
            myOdbcManager.AddParamToOdbcCommand("@regnum", SqlDbType.NVarChar, ParameterDirection.Input, regNum);
            myOdbcManager.AddParamToOdbcCommand("@name", SqlDbType.NVarChar, ParameterDirection.Input, name);
            myOdbcManager.AddParamToOdbcCommand("@address", SqlDbType.NVarChar, ParameterDirection.Input, address);
            myOdbcManager.AddParamToOdbcCommand("@status", SqlDbType.Int, ParameterDirection.Input, status);
            myOdbcManager.AddParamToOdbcCommand("@personality", SqlDbType.Int, ParameterDirection.Input, personality);
            myOdbcManager.AddParamToOdbcCommand("@domestic_or_overseas", SqlDbType.Int, ParameterDirection.Input, domesticOrOverseas);
            try
            {
                dtReturn = myOdbcManager.GetDataTableFromAdapter();
                myOdbcManager.Close();
            }
            finally
            {
                myOdbcManager?.Dispose();
            }
            return dtReturn;
        }

        public static DataTable SelectObicMaster(
            string invoiceNum = ""
            , string kana = ""
            , string officialName = ""
            , string domesticName = ""
            , string code = ""
            , string comCode = ""
            , string deptCode = ""
            , string deptName = ""
            )
        {
            DataTable dtReturn = null;
            string storedProcedureName = "SearchObic";
            OdbcManager myOdbcManager = new(connectObic: true);
            myOdbcManager.Connect();
            myOdbcManager.CreateOdbcCommand(storedProcedureName);
            myOdbcManager.SetCommandType(CommandType.StoredProcedure);
            myOdbcManager.AddParamToOdbcCommand("@invoiceNum", SqlDbType.NVarChar, ParameterDirection.Input, invoiceNum);
            myOdbcManager.AddParamToOdbcCommand("@kana", SqlDbType.NVarChar, ParameterDirection.Input, kana);
            myOdbcManager.AddParamToOdbcCommand("@officialName", SqlDbType.NVarChar, ParameterDirection.Input, officialName);
            myOdbcManager.AddParamToOdbcCommand("@domesticName", SqlDbType.NVarChar, ParameterDirection.Input, domesticName);
            myOdbcManager.AddParamToOdbcCommand("@code", SqlDbType.NVarChar, ParameterDirection.Input, code);
            myOdbcManager.AddParamToOdbcCommand("@comCode", SqlDbType.NVarChar, ParameterDirection.Input, comCode);
            myOdbcManager.AddParamToOdbcCommand("@deptCode", SqlDbType.NVarChar, ParameterDirection.Input, deptCode);
            myOdbcManager.AddParamToOdbcCommand("@deptName", SqlDbType.NVarChar, ParameterDirection.Input, deptName);
            try
            {
                dtReturn = myOdbcManager.GetDataTableFromAdapter();
                myOdbcManager.Close();
            }
            finally
            {
                myOdbcManager?.Dispose();
            }
            return dtReturn; //SearchUser
        }
        public static DataTable SelectUser(
            string userId = ""
            )
        {
            DataTable dtReturn = null;
            string storedProcedureName = "SearchUser";
            OdbcManager myOdbcManager = new();
            myOdbcManager.Connect();
            myOdbcManager.CreateOdbcCommand(storedProcedureName);
            myOdbcManager.SetCommandType(CommandType.StoredProcedure);
            myOdbcManager.AddParamToOdbcCommand("@userId", SqlDbType.NVarChar, ParameterDirection.Input, userId);
            try
            {
                dtReturn = myOdbcManager.GetDataTableFromAdapter();
                myOdbcManager.Close();
            }
            finally
            {
                myOdbcManager?.Dispose();
            }
            return dtReturn;
        }

        public static bool InsertLogin(
            string userId = ""
            , string appVersion = ""
            , string endPoint = ""
            )
        {
            bool state;
            string storedProcedureName = "InsertLogin";
            OdbcManager myOdbcManager = new();
            myOdbcManager.Connect();
            myOdbcManager.BeginTransaction();

            myOdbcManager.CreateOdbcCommand(storedProcedureName);
            myOdbcManager.SetCommandType(CommandType.StoredProcedure);
            myOdbcManager.AddParamToOdbcCommand("@userId", SqlDbType.NVarChar, ParameterDirection.Input, userId);
            myOdbcManager.AddParamToOdbcCommand("@appVersion", SqlDbType.NVarChar, ParameterDirection.Input, appVersion);
            myOdbcManager.AddParamToOdbcCommand("@endPoint", SqlDbType.NVarChar, ParameterDirection.Input, endPoint);
            try
            {
                myOdbcManager.ExecuteNonQuery();
                myOdbcManager.CommitTransaction();
                myOdbcManager.Close();
                state = true;
            }
            catch
            {
                myOdbcManager?.RollbackTransaction();
                state = false;
            }
            finally
            {
                myOdbcManager?.Dispose();
            }
            return state;
        }

        // DELETE =============================================================
        public static bool DeleteWk()
        {
            bool state;
            string sql = "DELETE FROM W_DLDT"; 
            OdbcManager myOdbcManager = new OdbcManager().Connect();
            myOdbcManager.BeginTransaction();
            myOdbcManager.CreateOdbcCommand(sql);
            try
            {
                myOdbcManager.ExecuteNonQuery();
                myOdbcManager.CommitTransaction();
                myOdbcManager.Close();
                state = true;
            }
            catch
            {
                myOdbcManager?.RollbackTransaction();
                state = false;
            }
            finally 
            { 
                myOdbcManager?.Dispose(); 
            }
            return state;
        }

        // BULK INSERT =============================================================
        public static bool BulkInsert(string destDirectoryPath)
        {
            bool state = false;
            string[] files = Directory.GetFiles(destDirectoryPath);
            OdbcManager myOdbcManager = new OdbcManager().Connect();
            
            foreach (string file in files)
            {
                if (File.Exists(file) && Path.GetExtension(file) == ".csv")
                {
                    string sql = $"BULK INSERT [dbo].[W_DLDT] " +
                        $"FROM '{file}' " +
                        $"WITH (" +
                        $"    DATAFILETYPE ='char'" +
                        $"    , FIELDTERMINATOR = ','" +
                        $"    , FORMAT = 'CSV'" +
                        $"    , CODEPAGE = '65001')";
                    myOdbcManager.BeginTransaction();
                    myOdbcManager.CreateOdbcCommand(sql);
                    try
                    {
                        myOdbcManager.ExecuteNonQuery();
                        myOdbcManager.CommitTransaction();
                        state = true;
                    }
                    catch
                    {
                        myOdbcManager?.RollbackTransaction();
                        state = false;
                        return state;
                    }
                }
            }
            myOdbcManager?.Dispose();
            return state;
        }

        // INSERT =============================================================
        public static bool InsertMaster()
        {
            bool state = false;
            OdbcManager myOdbcManager = new OdbcManager().Connect();
            string sql = @"INSERT INTO M_NTADT_IRN SELECT * FROM V_INSERT_TARGET";
            myOdbcManager.BeginTransaction();
            myOdbcManager.CreateOdbcCommand(sql);
            try
            {
                myOdbcManager.ExecuteNonQuery();
                myOdbcManager.CommitTransaction();
                myOdbcManager.Close();
                state = true;
            }
            catch
            {
                myOdbcManager?.RollbackTransaction();
                state = false;
            }
            finally
            {
                myOdbcManager?.Dispose();
            }
            return state;
        }

        // UPDATE =============================================================
        public static bool UpdateMaster()
        {
            bool state = false;
            OdbcManager myOdbcManager = new OdbcManager().Connect();
            string sql = @"
                UPDATE M_NTADT_IRN
                SET
	                事業者処理区分 = V_UPDATE_TARGET.事業者処理区分
	                , 訂正区分 = V_UPDATE_TARGET.訂正区分
	                , 人格区分 = V_UPDATE_TARGET.人格区分
	                , 国内外区分 = V_UPDATE_TARGET.国内外区分
	                , 最新履歴 = V_UPDATE_TARGET.最新履歴
	                , 登録年月日 = V_UPDATE_TARGET.登録年月日
	                , 更新年月日 = V_UPDATE_TARGET.更新年月日
	                , 取消年月日 = V_UPDATE_TARGET.取消年月日
	                , 失効年月日 = V_UPDATE_TARGET.失効年月日
	                , [本店又は主たる事務所の所在地(法人)] = V_UPDATE_TARGET.[本店又は主たる事務所の所在地(法人)]
	                , [本店又は主たる事務所の所在地都道府県コード(法人)] = V_UPDATE_TARGET.[本店又は主たる事務所の所在地都道府県コード(法人)]
	                , [本店又は主たる事務所の所在地市区町村コード(法人)] = V_UPDATE_TARGET.[本店又は主たる事務所の所在地市区町村コード(法人)]
	                , [本店又は主たる事務所の所在地(公表申出)] = V_UPDATE_TARGET.[本店又は主たる事務所の所在地(公表申出)]
	                , [本店又は主たる事務所の所在地都道府県コード(公表申出)] = V_UPDATE_TARGET.[本店又は主たる事務所の所在地都道府県コード(公表申出)]
	                , [本店又は主たる事務所の所在地市区町村コード(公表申出)] = V_UPDATE_TARGET.[本店又は主たる事務所の所在地市区町村コード(公表申出)]
	                , [日本語(カナ)] = V_UPDATE_TARGET.[日本語(カナ)]
	                , 氏名または名称 = V_UPDATE_TARGET.氏名または名称
	                , [国内において行う資産の譲渡等に係る事務所、事業所その他これらに準ずるものの所在地] = V_UPDATE_TARGET.[国内において行う資産の譲渡等に係る事務所、事業所その他これらに準ずるものの所在地]
	                , [国内において行う資産の譲渡等に係る事務所、事業所その他これらに準ずるものの所在地都道府県コード] = V_UPDATE_TARGET.[国内において行う資産の譲渡等に係る事務所、事業所その他これらに準ずるものの所在地都道府県コード]
	                , [国内において行う資産の譲渡等に係る事務所、事業所その他これらに準ずるものの所在地市区町村コード] = V_UPDATE_TARGET.[国内において行う資産の譲渡等に係る事務所、事業所その他これらに準ずるものの所在地市区町村コード]
	                , 主たる屋号 = V_UPDATE_TARGET.主たる屋号
	                , 通称・旧姓 = V_UPDATE_TARGET.通称・旧姓
                FROM V_UPDATE_TARGET
                WHERE M_NTADT_IRN.登録番号 = V_UPDATE_TARGET.登録番号";
            myOdbcManager.BeginTransaction();
            myOdbcManager.CreateOdbcCommand(sql);
            try
            {
                myOdbcManager.ExecuteNonQuery();
                myOdbcManager.CommitTransaction();
            }
            catch
            {
                myOdbcManager?.RollbackTransaction();
                return state;
            }
            sql = @"
                -- 氏名と住所はnullだと検索で不都合があるので空文字に置き換える
                UPDATE M_NTADT_IRN
                SET 
	                氏名または名称 = CASE WHEN 氏名または名称 is null THEN '' ELSE 氏名または名称 END
	                , [本店又は主たる事務所の所在地(法人)] = CASE WHEN [本店又は主たる事務所の所在地(法人)] is null THEN '' ELSE [本店又は主たる事務所の所在地(法人)] END
                WHERE
	                (氏名または名称 is null) OR ([本店又は主たる事務所の所在地(法人)] is null)";
            myOdbcManager.BeginTransaction();
            myOdbcManager.CreateOdbcCommand(sql);
            try
            {
                myOdbcManager.ExecuteNonQuery();
                myOdbcManager.CommitTransaction();
            }
            catch
            {
                myOdbcManager?.RollbackTransaction();
                return state;
            }
            finally
            {
                myOdbcManager?.Dispose();
            }
            state = true;
            return state;
        }
    }
}
