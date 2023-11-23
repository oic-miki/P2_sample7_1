﻿using Microsoft.Data.SqlClient;

// パラメータ用文字列の入力
//Console.Write("Idを入力してください＞");
//int input = int.Parse(Console.ReadLine());

// 接続文字列の設定

// "CompanyData.mdf"
string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\user\OneDrive - すな企画\すな企画\OIC（大阪情報コンピューター専門学校）\2023\プログラミングⅡ\07\P2_sample7_1\P2_sample7_1\CompanyData.mdf"";Integrated Security=True";
// "Database.mdf"
//string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\user\OneDrive - すな企画\すな企画\OIC（大阪情報コンピューター専門学校）\2023\プログラミングⅡ\07\P2_sample7_1\P2_sample7_1\Database.mdf"";Integrated Security=True";
//string connectionString = @"";

// データベースへの接続準備
using (SqlConnection conn = new SqlConnection())
{
    conn.ConnectionString = connectionString;

    // コマンドの準備
    string query = "SELECT Id, name FROM Employees ORDER BY Id ASC;";
    //string query = "SELECT Id, name, value FROM m_shouhin;";
    //string query = "SELECT Id, name, value FROM m_shouhin WHERE Id=@id;";
    using (SqlCommand cmd = new SqlCommand())
    {
        cmd.Connection = conn;
        cmd.CommandText = query;

        // データベース処理は失敗する可能性があるので、例外処理の準備
        try
        {
            // データベースへの接続
            conn.Open();

            // パラメータの設定
            //cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = input;

            // コマンドの実行
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // 行を読む
                while (reader.Read())
                {
                    // 値を取り出す
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    //int value = reader.GetInt32(2);

                    // 取り出した値を画面に書く
                    Console.WriteLine($"Id:{id}, name:{name}");
                    //Console.WriteLine($"Id:{id}, name:{name}, value:{value}");
                }
                // パラメータを使った場合の処理
                //if (reader.HasRows)
                //{
                //    reader.Read();
                //    string name = reader.GetString(1);
                //    Console.WriteLine($"商品は{name}ですね！");
                //}
                //else
                //{
                //    Console.WriteLine("商品が見つかりませんでした。");
                //}

                // 実行結果の後処理
                //reader.Close();
            }
        }
        catch (Exception ex)
        //catch
        {
            // 例外が出た場合の処理
            Console.WriteLine("エラーが発生しました。");

            Console.WriteLine(ex.Message);

        }
        finally
        {

            conn.Close(); // 必ずDBとの接続をクローズする

        }

        // データベースへの接続解除
        //conn.Close();
    }
}
