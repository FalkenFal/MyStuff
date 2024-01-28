using System;

namespace Equation{

    class DoEquationStuff{
        protected string[] Subscribtion = {"Platinum", "Gold", "Silver"};

        protected int SubscribtionSelector = 0; //input
        protected float DiscountPoints = 396; //Input
        protected float Total = 100; //Input
        static void Main(){

            string[] Subs = new DoEquationStuff().Subscribtion;
            float Points = new DoEquationStuff().DiscountPoints;
            float Total = new DoEquationStuff().Total;
            int SubType = new DoEquationStuff().SubscribtionSelector;

            Console.WriteLine(CheckSub(Subs[SubType], Points, Total));

        }

        static string CheckSub(string SubscrbtionType, float Points, float total){

            float Amount = 0;
            float finalresult;

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

            return " Customer Subscribtion : "  + SubscrbtionType +"\n Points : " + Points + "\n Total belanja : " + total + "\n Discount :" + Amount + "\n Total bayar : " + finalresult;

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