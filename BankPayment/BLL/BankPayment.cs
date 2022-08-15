using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankPayment.Models;
using BankPayment.BLL;

namespace BankPayment.BLL
{
    //تابع فقط کاری که ازش خواسته شده رو باید انجام بده نه بیشتر نه کمتر
    //هر تابع باید فقط یک کار رو انجام بده
    //تابع باید راحت قابل خواندن باشه 
    //برای تابع پارامتر خروجی خوب نیست چون  نفر بعدی رو مجبور میکنه برای فهمیدن که وارد تابع های وابسته بشه
    public class BankPayment
    {
        Logger logger = new Logger();
        Sms sms = new Sms();
        public void Payment(Request request)
        {
            PaymentOperation(request);
        }

        private void PaymentOperation(Request request)
        {
            try
            {
                bool check = CheckRequest(request);
                if (check)
                {
                    FinalPayment(request);
                }
                else
                {
                    logger.Log("");
                    sms.Send();
                }
            }
            catch (Exception e)
            {
                logger.Log(e.Message);
                sms.Send();
            }


        }

        private void FinalPayment(Request request)
        {
            try
            {
                bool IsValidPayment = PaymentRequest(request);
                if (IsValidPayment == false)
                {
                    FailPayment(request);
                }
                else
                {
                    logger.Log("");
                }
            }
            catch (Exception e)
            {
                logger.Log(e.Message);
            }
        }

        private void FailPayment(Request request)
        {
            try
            {
                bool IsReverse = Reverse(request);
                if (IsReverse)
                {
                    logger.Log("");
                    sms.Send();
                }
                else
                {
                    logger.Log("");
                    sms.Send();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private bool Reverse(Request request)
        {
            throw new NotImplementedException();
        }

        private bool PaymentRequest(Request request)
        {
            bool Result=false;
            //Result=عملیات پرداخت
            return Result;
        }

        private bool CheckRequest(Request request)
        {
            bool result = false;
            try
            {
                //result=چک کردن صحت اطلاعات
                return result;

            }
            catch (Exception e)
            {
                logger.Log(e.Message);
                sms.Send();
                return result;
            }
        }
    }
}