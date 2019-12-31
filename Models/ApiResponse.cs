using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_mobile.Models
{
    public class ApiResponse<T>
    {
        public int error;
        public String message;
        public T data;
    }
}