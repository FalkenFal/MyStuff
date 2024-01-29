using System;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Net.Security;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Equation{

    class DoEquationStuff{

        public string Currentdate = DateTime.Now.ToString("yy-MM-dd");
        private string Server = "Data Source=(localdb)\\local;Integrated Security=true;AttachDbFileName=C:\\Users\\Leonovo\\TestDB2.mdf";
        protected string[] Subscribtion = {"Platinum", "Gold", "Silver"};
        public int SubscribtionSelector;
        public float DiscountPoints;
        public float Total;
        protected static void Main(){

            Console.WriteLine("Customer Subscribtion(0 = Platinum | 1 = Gold | 2 = Silver)");
            string[] Subs = new DoEquationStuff().Subscribtion;
            int SubType = new DoEquationStuff().SubscribtionSelector = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Total Belanja");
            float Total = new DoEquationStuff().Total = (float) Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Total Points");
            float Points = new DoEquationStuff().DiscountPoints = (float) Convert.ToDouble(Console.ReadLine());
            
            
            string Server = new DoEquationStuff().Server;

            string CurrentDate = new DoEquationStuff().Currentdate;

            string Query = "INSERT INTO DiscountTable (Date, Subscribtion, Total_Belanja, Points, Discount, Total_Bayar) VALUES ('" + CurrentDate + "','" + Subs[SubType] + "', " + Total + ", " + Points + ",";
            string Query2 = "SELECT ID FROM DiscountTable ORDER BY ID DESC";

            float[] GetReturnValues = CheckSub(Subs[SubType], Points, Total);

            Query += GetReturnValues[0] + "," + GetReturnValues[1] + ")";

            SQLConnectionOpen(Server, Query);
            SQLConnectionOpen(Server,Query2);

        }

        private static void SQLConnectionOpen(string Connectto, string Query){
            using(SqlConnection Connect = new SqlConnection(Connectto)){
                Connect.Open();
                SqlCommand Command = new SqlCommand(Query);
                Command.Connection = Connect;
                using(SqlDataReader ReadData = Command.ExecuteReader()){
                    if(ReadData.Read()){
                        Console.WriteLine("Insert with ID of : " + ReadData["ID"].ToString());
                    }
                }
            }
        }

        static float[] CheckSub(string SubscrbtionType, float Points, float total){

            float Amount = 0f;
            float finalresult = 0f;
            float[] sendreturn = {0f,0f}; 

            switch(SubscrbtionType){
                case "Platinum":
                Amount = PlatDiscountEquations(Points, total);
                break;
                case "Gold":
                Amount = GoldDiscountEquation(Points, total);
                break;
                case "Silver":
                Amount = SilverDiscountEquation(Points, total);
                break;
            }

            finalresult = total - Amount;

            sendreturn[0] = Amount;
            sendreturn[1] = finalresult;

            return sendreturn;

        }

        static float PlatDiscountEquations(float Points, float Cash){

            float FAmount = Points;

            if(Points >= 100f && Points <= 300f){
                FAmount = Cash * (50f/100f) + 35f;
            } else if(Points >= 301f && Points <= 500f){
                FAmount = Cash * (50f/100f) + 50f;
            } else if(Points >= 501f){
                FAmount = Cash * (50f/100f) + 68f;
            }

            return FAmount;
        }

        static float GoldDiscountEquation(float Points, float Cash){

            float FAmount = 0;

            if(Points >= 100f && Points <= 300f){
                FAmount = Cash * (25f/100f) + 25f;
            } else if(Points >= 301f && Points <= 500f){
                FAmount = Cash * (25f/100f) + 34f;
            } else if(Points >= 501f){
                FAmount = Cash * (25f/100f) + 52f;
            }

            return FAmount;
        }

        static float SilverDiscountEquation(float Points, float Cash){

            float FAmount = 0;

            if(Points >= 100f && Points <= 300f){
                FAmount = Cash * (12f/100f) + 12f;
            } else if(Points >= 301f && Points <= 500f){
                FAmount = Cash * (12f/100f) + 27f;
            } else if(Points >= 501){
                FAmount = Cash * (12f/100f) + 39f;
            }

            return FAmount;
        }

    }

}