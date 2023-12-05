using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace インボイス番号検索ツール.Model.DB
{
    internal class OdbcManager: IDisposable
    {
        private SqlConnection SqlConn { get; set; } // DBと接続するときのオブジェクト
        private SqlTransaction SqlTrnsct { get; set; } // トランザクションを保持するオブジェクト
        private SqlCommand SqlCmd { get; set; } // SQLコマンドを保持するオブジェクト
        private SqlConnectionStringBuilder SqlConnStr { get; set; }

        private static int IntTimeOut { get; } = -1;
        private static bool Debug { get; } = false;
        private bool _disposed = false; // Track whether Dispose has been called.

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OdbcManager(SqlConnectionStringBuilder odbcConnStr = null, bool connectObic = false)
        {
            // ODBC接続文字列の作成
            if (odbcConnStr == null)
            {
                if (connectObic)
                {
                    SqlConnStr = new SqlConnectionStringBuilder
                    {
                        [@"SERVER"] = @"SMS114",
                        [@"UID"] = @"sa",
                        [@"PWD"] = @"dell@413",
                        [@"Database"] = @"OBIC7_MASTER"
                    };
                }
                else
                {
                    SqlConnStr = new SqlConnectionStringBuilder
                    {
                        [@"SERVER"] = @"DEV001\SQLEXPRESS",
                        [@"UID"] = @"sa",
                        [@"PWD"] = @"dell@413",
                        [@"Database"] = @"適格請求書発行事業者DB"
                    };
                }

                if (IntTimeOut > 0) // タイムアウト設定（必要であれば）
                {
                    SqlConnStr[@"Connect Timeout"] = IntTimeOut;
                }
            }
            else
            {
                SqlConnStr = odbcConnStr;
            }
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~OdbcManager()
        {
            Dispose(false); // アンマネージドリソースのみを解放（マネージドリソースの解放はGCに任せる）
        }

        /// <summary>
        /// 保持しているOdbcCommandオブジェクトにパラメータを追加するメソッド。
        /// </summary>
        /// <param name="strParamName">パラメータ名</param>
        /// <param name="odbcType">データ型を表すOdbctTypeオブジェクト</param>
        /// <param name="paramDirection">パラメータの方向（入力か出力か両方か）</param>
        /// <param name="objValue">値</param>
        /// <exception cref="Exception">OdbcCommandオブジェクトを保持していない場合などはエラー。</exception>
        public void AddParamToOdbcCommand(
            string strParamName, SqlDbType odbcType, ParameterDirection paramDirection, object objValue)
        {
            try
            {
                SqlParameter odbcParameter = new SqlParameter
                {
                    ParameterName = strParamName,
                    SqlDbType = odbcType,
                    Direction = paramDirection,
                    Value = objValue
                };

                SqlCmd.Parameters.Add(odbcParameter);
            }
            catch (Exception ex)
            {
                throw new Exception("AddParamToCommand Error", ex);
            }
        }

        /// <summary>
        /// Odbc接続においてトランザクションを始めるメソッド。
        /// </summary>
        /// <exception cref="Exception">OdbcConnectionオブジェクトがなかったり、接続が始まっていなかったらエラー</exception>
        public void BeginTransaction()
        {
            try
            {
                SqlTrnsct = SqlConn.BeginTransaction();
                if (Debug) { Console.WriteLine(SqlTrnsct.Connection.State); }
            }
            catch (Exception ex)
            {
                throw new Exception("BeginTransaction Error", ex);
            }
        }

        public void Close()
        {
            try
            {
                SqlConn?.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Close Error", ex);
            }
        }

        /// <summary>
        /// Odbc接続において、トランザクションをコミットするメソッド。
        /// </summary>
        /// <exception cref="Exception">OdbcTransactionオブジェクトがない場合などはエラー</exception>
        public void CommitTransaction()
        {
            try
            {
                SqlTrnsct.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("CommitTransaction Error", ex);
            }
            finally
            {
                SqlTrnsct.Dispose();
                SqlTrnsct = null;
            }
        }

        /// <summary>
        /// ODBC接続を開始するメソッド。
        /// </summary>
        /// <exception cref="Exception"></exception>
        public OdbcManager Connect()
        {
            try
            {
                // ODBC接続 =================================================================
                if (SqlConn != null) // すでに接続があった場合、一度リセット
                {
                    SqlConn.Dispose();
                    SqlConn = null;
                }
                // ODBC接続用インスタンス生成
                SqlConn = new SqlConnection
                {
                    ConnectionString = SqlConnStr.ConnectionString
                };

                // ODBC接続を開く
                if (Debug) { Console.WriteLine(SqlConn.State); }
                SqlConn.Open();

                // サーバのバージョン確認
                if (Debug) { Console.WriteLine(SqlConn.State); }
                if (Debug) { Console.WriteLine($@"Server Version: {SqlConn.ServerVersion}"); }
                return this;

            }
            catch (Exception ex)
            {
                throw new Exception("Connect Error", ex);
            }
        }

        /// <summary>
        /// OdbcCommandオブジェクトを作成するメソッド。
        /// </summary>
        /// <param name="strSql">SQL文。パラメータありも許容。</param>
        /// <exception cref="Exception"></exception>
        public void CreateOdbcCommand(string strSql)
        {
            try
            {
                // すでにコマンドがあれば一度リセット
                if (SqlCmd != null)
                {
                    SqlCmd.Dispose();
                    SqlCmd = null;
                }

                SqlCmd = new SqlCommand(strSql, SqlConn, SqlTrnsct);
            }
            catch (Exception ex)
            {
                throw new Exception("CreateOdbcCommand Error", ex);
            }
        }

        /// <summary>
        /// リソースの解放を明示的に行うためのメソッド。アンマネージドリソースおよびマネージドリソースを解放。
        /// </summary>
        public void Dispose() // リソースの解放を明示的に行うためのメソッド
        {
            if (Debug) { Console.WriteLine($@"Dispose前のOdbcConnチェック: {SqlConn?.State}"); }
            Dispose(true); // マネージドリソースおよびアンマネージドリソースを解放
            if (Debug) { Console.WriteLine($@"Dispose後のOdbcConnチェック: {SqlConn?.State}"); }
        }

        /// <summary>
        /// アンマネージドおよびマネージドリソースの解放を行うメソッド。引数に応じてマネージドリソース解放処理の有無を切り替える。
        /// </summary>
        /// <param name="disposing">マネージドリソースの解放も行う場合はTrue</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) // 引数がtrueのときはマネージドリソースの解放も行う
                {
                    // TODO: Dispose managed resources here.
                    SqlConn?.Dispose();
                    SqlTrnsct?.Dispose();
                    SqlCmd?.Dispose();

                    if (Debug) { Console.WriteLine("マネージドリソースを解放"); }
                }

                // アンマネージドリソースの開放
                // TODO: Free unmanaged resources here.
                FreeUnmanagedResources();

                _disposed = true;
            }
        }

        public void ExecuteNonQuery()
        {
            try
            {
                SqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery Error", ex);
            }
        }

        /// <summary>
        /// 形だけ作成したメソッド。アンマネージドリソースの解放用
        /// </summary>
        protected static void FreeUnmanagedResources()
        {
            // アンマネージドリソースを（もしあれば）解放
            if (Debug)
            {
                Console.WriteLine("アンマネージドリソースを解放");
            }

            // アンマネージドリソース・・・ポインターがさす外部リソースなど
        }

        /// <summary>
        /// OdbcDataAdapterからDataTableにデータを取得するメソッド。
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DataTable GetDataTableFromAdapter()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter odbcDataAdapter = new SqlDataAdapter(SqlCmd);
                odbcDataAdapter.Fill(dt);
                if (Debug) { Console.WriteLine(dt.Rows.Count); }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("GetDataTableFromAdapter Error", ex);
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                SqlTrnsct.Rollback();
            }
            catch (Exception ex)
            {
                throw new Exception("RollbackTransaction Error", ex);
            }
            finally
            {
                SqlTrnsct.Dispose();
                SqlTrnsct = null;
            }
        }

        public void SetCommandType(CommandType commandType)
        {
            try
            {
                if (SqlCmd != null)
                {
                    SqlCmd.CommandType = commandType;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SetCommandType Error", ex);
            }
            finally { }
        }
    }
}
