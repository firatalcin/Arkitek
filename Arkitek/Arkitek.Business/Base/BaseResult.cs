using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arkitek.Business.Base
{
    public class BaseResult<T>
    {
        public T? Data { get; set; }

        public IEnumerable<object> Errors { get; set; }


        public bool IsSuccessful => Errors == null || !Errors.Any();


        public bool IsFailure => !IsSuccessful;


        public static BaseResult<T> Success(T? data)
        {
            return new BaseResult<T> { Data = data };
        }

        public static BaseResult<T> Success()
        {
            return new BaseResult<T> { Errors = null };
        }

        public static BaseResult<T> Fail(string errorMessage)
        {
            return new BaseResult<T> { Errors = new[] { new { ErrorMessage = errorMessage, PropertyName = "key" } } };
        }

        //public static BaseResult<T> Fail(List<ValidationFailure> errorMessages)
        //{
        //    IEnumerable<object> errors = (from error in errorMessages
        //                                  select new
        //                                  {
        //                                      PropertyName = error.ToString(),
        //                                      ErrorMessage = error.ToString()
        //                                  }).ToList();

        //    return new BaseResult<T>
        //    {
        //        Errors = errors,
        //    };
        //}

        //public static BaseResult<T> Fail(IEnumerable<IdentityError> errorMessages)
        //{

        //    IEnumerable<object> errors = (from error in errorMessages
        //                                  select new
        //                                  {
        //                                      PropertyName = error.Code,
        //                                      ErrorMessage = error.Description
        //                                  }).ToList();

        //    return new BaseResult<T>
        //    {
        //        Errors = errors,
        //    };
        //}
    }
}
